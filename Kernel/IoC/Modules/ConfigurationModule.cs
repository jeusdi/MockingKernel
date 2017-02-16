using Ninject.Activation;

namespace Core.IoC.Modules
{
    public class ConfigurationModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            this.Bind<Core.Configuration.ICoreConfiguration>().ToProvider<ConfigurationProvider>();
        }
    }

    public class ConfigurationProvider : IProvider<Core.Configuration.ICoreConfiguration>
    {

        private const string CONFIGURATION_FILENAME = "core_configuration.xml";

        public object Create(IContext context)
        {
            return this.ReadConfiguration() ?? new Configuration.CoreConfiguration();
        }

        public System.Type Type
        {
            get { throw new System.NotImplementedException(); }
        }

        #region Configuration

        public Configuration.CoreConfiguration ReadConfiguration()
        {
            if (System.IO.File.Exists(ConfigurationProvider.CONFIGURATION_FILENAME))
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Configuration.CoreConfiguration));
                System.IO.StreamReader file = new System.IO.StreamReader(ConfigurationProvider.CONFIGURATION_FILENAME);
                Configuration.CoreConfiguration configuration = (Configuration.CoreConfiguration)reader.Deserialize(file);
                file.Close();

                return configuration;
            }

            return null;
        }

        public void WriteConfiguration(Configuration.CoreConfiguration configuration)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Configuration.CoreConfiguration));
            System.IO.Stream file = System.IO.File.Open(ConfigurationProvider.CONFIGURATION_FILENAME, System.IO.FileMode.OpenOrCreate);
            writer.Serialize(file, configuration);
            file.Close();
        }

        #endregion
    }

}
