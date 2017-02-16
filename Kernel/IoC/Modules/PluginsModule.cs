using System.Linq;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using System.Collections.Generic;

namespace Core.IoC.Modules
{
    public class PluginsModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            string pluginsDirectoryPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Plugins");
            if (System.IO.Directory.Exists(pluginsDirectoryPath))
            {
                IEnumerable<string> pluginDirectoryPaths = System.IO.Directory.EnumerateDirectories(pluginsDirectoryPath);
                foreach (string pluginDirectoryPath in pluginDirectoryPaths)
                {
                    this.Bind(b => b.FromAssembliesInPath(pluginDirectoryPath, p => p.ManifestModule.Name.Contains("Plugin"))
                        .SelectAllClasses()
                        .InheritedFrom(typeof(Extensibility.AbstractProducerPlugin))
                        .BindAllBaseClasses()
                    );
                }

                this.Bind<Core.Identity.UserIdentity>().ToProvider<ProducerProvider>().WhenInjectedInto<Extensibility.AbstractProducerPlugin>();
            }
        }
    }

    public class ProducerProvider : IProvider<Core.Identity.UserIdentity>
    {



        public object Create(IContext context)
        {
            
            Ninject.Parameters.IParameter identityParameter = context.Parameters.FirstOrDefault(p => p.Name.Equals(Kernel.USER_IDENTITY_PARAMETER));
            Core.Identity.UserIdentity identity = (Core.Identity.UserIdentity)identityParameter.GetValue(context, null);

            return identity;
        }

        public System.Type Type
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
