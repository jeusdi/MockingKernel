using System;

namespace Core.IoC
{
    /*public sealed class NinjectServiceLocator : INinjectServiceLocator
    {

        public const string DOMAIN_IDENTITY_PARAMETER = "domainIdentity";

        private static readonly Lazy<NinjectServiceLocator> lazy = new Lazy<NinjectServiceLocator>(() => new NinjectServiceLocator());
    
        public static NinjectServiceLocator Instance { get { return lazy.Value; } }

        public Ninject.IKernel Kernel { get; private set; }

        private NinjectServiceLocator()
        {
            this.Kernel = new Ninject.StandardKernel(
                new Modules.BackendModule(),
                new Modules.PluginsModule()
            );
        }

    }*/
}
