using System.Linq;
using System;
using Ninject.Activation;

namespace Core.IoC.Modules
{
    public class BackendModule : Ninject.Modules.NinjectModule
    {

        public override void Load()
        {
            /*string backendsDirectoryPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Backends");
            IEnumerable<string> backendDirectoryPaths = System.IO.Directory.EnumerateDirectories(backendsDirectoryPath);
            foreach (string backendDirectoryPath in backendDirectoryPaths)
            {
                this.Bind(b => b.FromAssembliesInPath(backendDirectoryPath, p => p.ManifestModule.Name.Contains("Backend"))
                    .SelectAllClasses()
                    .InheritedFrom(typeof(Backend.Infrastructure.IBackend))
                    .Where(t => !String.IsNullOrEmpty(t.GetAttributeValue<Backend.Infrastructure.BackendKeyAttribute, string>(backendkey => backendkey.Key)))
                    .BindAllInterfaces()
                    .Configure((syntax, type) => syntax.Named(type.GetAttributeValue<Backend.Infrastructure.BackendKeyAttribute, string>(backendkey => backendkey.Key)))
                );
            }*/

            this.Bind<Backend.Infrastructure.IBackend>().To<Backend.Implementations.Lest.LESTBackend>();
            this.Bind<Backend.Infrastructure.Identity.UserIdentity>().ToProvider<UserIdentityProvider>();
            this.Bind<Backend.Infrastructure.Identity.ClientIdentity>().ToProvider<ClientIdentityProvider>();
        }

    }

    internal class UserIdentityProvider : Ninject.Activation.IProvider<Backend.Infrastructure.Identity.UserIdentity>
    {

        public object Create(IContext context)
        {
            Ninject.Parameters.IParameter domainIdentityParameter = context.Parameters.FirstOrDefault(p => p.Name.Equals(Kernel.DOMAIN_IDENTITY_PARAMETER));
            Core.Identity.DomainIdentity domainIdentity = domainIdentityParameter.GetValue(context, null) as Core.Identity.DomainIdentity;

            return new Backend.Infrastructure.Identity.UserIdentity(
                domainIdentity != null ? domainIdentity.UserIdentity.UserId : string.Empty,
                domainIdentity != null ? domainIdentity.UserIdentity.Name : string.Empty,
                domainIdentity != null ? domainIdentity.UserIdentity.Password : string.Empty
            );
        }

        public Type Type
        {
            get { return typeof(Backend.Infrastructure.Identity.UserIdentity); }
        }
    }

    internal class ClientIdentityProvider : Ninject.Activation.IProvider<Backend.Infrastructure.Identity.ClientIdentity>
    {

        public object Create(IContext context)
        {
            Ninject.Parameters.IParameter domainIdentityParameter = (Ninject.Parameters.IParameter)context.Parameters.FirstOrDefault(p => p.Name.Equals(Kernel.DOMAIN_IDENTITY_PARAMETER));
            Core.Identity.DomainIdentity domainIdentity = domainIdentityParameter.GetValue(context, null) as Core.Identity.DomainIdentity;

            return new Backend.Infrastructure.Identity.ClientIdentity(
                domainIdentity != null ? domainIdentity.ClientIdentity.ClientId : string.Empty,
                domainIdentity != null ? domainIdentity.ClientIdentity.Name : string.Empty
            );
        }

        public Type Type
        {
            get { return typeof(Backend.Infrastructure.Identity.ClientIdentity); }
        }
    }
}
