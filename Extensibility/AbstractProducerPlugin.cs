using System;
using System.Collections.Generic;
using Core.Extensibility.Events;

namespace Core.Extensibility
{
    public abstract class AbstractProducerPlugin : IProducerPlugin
    {

        private Core.Identity.UserIdentity userIdentity;

        public Core.Identity.UserIdentity UserIdentity
        {
            get { return userIdentity; }
        }

        public AbstractProducerPlugin(Core.Identity.UserIdentity userIdentity)
        {
            this.userIdentity = userIdentity;
        }

        public abstract IEnumerable<Backend.Domain.DigitalInput> GetDigitalInputs();
        public abstract IEnumerable<string> GetChannels();

        public abstract event Events.NotifyNewDigitalInputsEventHandler notifyNewDigitalInputs;
        public abstract event Events.NotifyRemovedSourcesEventHandler notifyRemovedSources;

        public abstract ProducerInfo ProducerInfo { get; }

        public abstract object Configuration  { get; }

        public abstract void Initialize();

        public abstract IEnumerable<Guid> TypeGuids { get; }
    }
}
