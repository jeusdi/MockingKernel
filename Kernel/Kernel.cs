using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Core.Identity;
using System;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using Core.Communication;

namespace Core
{
    public partial class Kernel : Core.IKernel
    {

        #region Nested Classes

        private enum KernelState
        {
            initializing,
            initialized
        }

        //TESTING PURPOSE
        [System.Flags]
        internal enum InitializeSettings
        {
            Mappings,
            Observables,
            SOAP
        }

        #endregion

        #region Fields

        private KernelState state;

        private Core.Configuration.ICoreConfiguration configuration;
        private Core.Communication.ICoreService service;

        private IList<Extensibility.IProducerPlugin> producers;
        private IDictionary<Core.Identity.DomainIdentity, Backend.Infrastructure.IBackend> backends;

        private System.ServiceModel.ServiceHost serviceHost;

        private AutoMapper.MapperConfiguration autoMapperConfiguration;
        private AutoMapper.IMapper mapper;

        private ObservableCollection<Core.Identity.UserIdentity> observableUserIdentities;

        #endregion

        #region Properties

        public virtual Configuration.ICoreConfiguration Configuration
        {
            get { return this.configuration; }
        }

        public ICoreService CoreService
        {
            get { return this.service; }
        }

        public IEnumerable<UserIdentity> UserIdentities
        {
            get { return this.observableUserIdentities; }
        }

        #endregion

        #region Constructors & Initializers

        public Kernel(Configuration.ICoreConfiguration configuration)
            : this(configuration, null)
        {

        }

        public Kernel(Configuration.ICoreConfiguration configuration, Communication.ICoreService service)
        {
            if (configuration == null)
                throw new ArgumentException("configuration object must be provided", "configuration");


            this.state = KernelState.initializing;

            this.configuration = configuration;
            this.service = service ?? this;

            this.backends = new Dictionary<Core.Identity.DomainIdentity, Backend.Infrastructure.IBackend>();
            this.observableUserIdentities = new ObservableCollection<Identity.UserIdentity>();
        }

        public void Initialize()
        {
            this.InitializeMappings();
            this.InitializeConfiguration();

            this.state = KernelState.initialized;
        }

        private void InitializeConfiguration()
        {
            IObservable<NotifyCollectionChangedEventArgs> eventsObservable = Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                h => this.observableUserIdentities.CollectionChanged += h,
                h => this.observableUserIdentities.CollectionChanged -= h
            )
            .Select(evt => evt.EventArgs);

            eventsObservable
                .Where(item => item.Action == NotifyCollectionChangedAction.Add)
                .SelectMany(item => item.NewItems.Cast<Core.Identity.UserIdentity>())
                .Subscribe(userIdentity => this.AddUser(userIdentity));

            eventsObservable
                .Where(item => item.Action == NotifyCollectionChangedAction.Remove)
                .SelectMany(item => item.NewItems.Cast<Core.Identity.UserIdentity> ())
                .Subscribe(userIdentity => this.RemoveUser(userIdentity));

            foreach (Configuration.UserIdentity userIdentity in this.configuration.UserIdentities)
                this.observableUserIdentities.Add(
                    this.mapper.Map<Core.Configuration.UserIdentity, Core.Identity.UserIdentity>(userIdentity)
                );
        }

        private void InitializeMappings()
        {
            log4net.LogManager.GetLogger("").Info("Configuring Kernel Mappings");

            this.autoMapperConfiguration = new AutoMapper.MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<Core.Mapping.Profile.Communication.PluginProfile>();
                    cfg.AddProfile<Core.Mapping.Profile.Communication.UserIdentityProfile>();
                    cfg.AddProfile<Core.Mapping.Profile.Communication.ChannelPluginProfile>();
                    cfg.AddProfile<Core.Mapping.Profile.Configuration.UserIdentityProfile>();
                }
            );

            this.mapper = this.autoMapperConfiguration.CreateMapper();

            log4net.LogManager.GetLogger("").Info("Kernel Mappings Configured");
        }

        

        #endregion

        #region Identities

        internal virtual IEnumerable<Extensibility.IProducerPlugin> ActivateProducers(Core.Identity.UserIdentity userIdentity)
        {
            List<Extensibility.IProducerPlugin> activatedProducers = new List<Extensibility.IProducerPlugin>();

            foreach (Type producerType in this.configuration.ProducerTypes)
                activatedProducers.Add((Extensibility.IProducerPlugin)Activator.CreateInstance(producerType, userIdentity));

            return activatedProducers;
        }

        internal virtual void AddUser(Core.Identity.UserIdentity userIdentity)
        {
            IEnumerable<Extensibility.IProducerPlugin> producers = this.ActivateProducers(userIdentity);
            foreach (Extensibility.IProducerPlugin producer in producers)
            {
                //producer.notifyNewDigitalInputs += handleNewDigitalInputsNotification;
                Observable.FromEventPattern<Core.Extensibility.Events.NotifyNewDigitalInputsEventHandler, Core.Extensibility.Events.NewDigitalInputsEventArgs>(
                    h => producer.notifyNewDigitalInputs += h,
                    h => producer.notifyNewDigitalInputs -= h
                )
                .Subscribe(
                    evt =>
                    {
                        Backend.Infrastructure.IBackend backend = this.LookForBackend(evt.EventArgs.UserIdentity, evt.EventArgs.ClientIdentity);
                        backend.saveDigitalInputs(evt.EventArgs.DigitalInputs);
                    }
                );

                //producer.notifyDeletedSources += handleDeletedSourcesNotification;
                Observable.FromEventPattern<Core.Extensibility.Events.NotifyRemovedSourcesEventHandler, Core.Extensibility.Events.RemovedDigitalInputsEventArgs>(
                    h => producer.notifyRemovedSources += h,
                    h => producer.notifyRemovedSources -= h
                )
                .Subscribe(
                    evt =>
                    {
                        Backend.Infrastructure.IBackend backend = this.LookForBackend(evt.EventArgs.UserIdentity, evt.EventArgs.ClientIdentity);
                        backend.deleteSources(evt.EventArgs.Sources);
                    }
                );

                this.BindBackendFor(userIdentity, producer.ProducerInfo.Identity);// userIdentity.BackendKey);

                log4net.LogManager.GetLogger("").Info(string.Format("Configuring (prod: {0} - user: {1})", producer.ProducerInfo.Name, userIdentity.UserId));

                producer.Initialize();
                this.producers.Add(producer);
            }
        }

        internal virtual void RemoveUser(Core.Identity.UserIdentity userIdentity)
        {

        }

        #endregion

        #region Backend-Identities

        private void BindBackendFor(Core.Identity.UserIdentity userIdentity, Core.Identity.ClientIdentity clientIdentity)
        {
            if (userIdentity == null)
                throw new ArgumentException("userIdentity must be provided", "userIdentity");

            if (clientIdentity == null)
                throw new ArgumentException("clientIdentity must be provided", "clientIdentity");

            Core.Identity.DomainIdentity domainIdentity = DomainIdentity.Create(userIdentity, clientIdentity);

            Backend.Infrastructure.IBackend backend = new Backend.Implementations.Lest.LESTBackend(
                new Backend.Infrastructure.Identity.UserIdentity(userIdentity.UserId, userIdentity.Name, userIdentity.Password),
                new Backend.Infrastructure.Identity.ClientIdentity(clientIdentity.ClientId, clientIdentity.Name)
            );

            this.backends.Add(domainIdentity, backend);
        }

        protected Backend.Infrastructure.IBackend LookForBackend(Core.Identity.UserIdentity userIdentity, Core.Identity.ClientIdentity clientIdentity)
        {
            Core.Identity.DomainIdentity domainIdentity = DomainIdentity.Create(userIdentity, clientIdentity);

            Backend.Infrastructure.IBackend backend = null;

            if (this.state != KernelState.initialized)
                throw new Core.Exceptions.CoreNotInitializedException();

            this.backends.TryGetValue(domainIdentity, out backend);

            return backend;
        }

        #endregion

    }
}
