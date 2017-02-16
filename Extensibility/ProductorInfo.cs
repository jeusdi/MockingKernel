namespace Core.Extensibility
{
    public class ProducerInfo
    {
        private string name;
        private string description;
        private string version;
        private Core.Identity.ClientIdentity identity;

        #region Properties

        public Core.Identity.ClientIdentity Identity
        {
            get { return identity; }
            set { identity = value; }
        }

        public string Version
        {
            get { return version; }
            set { version = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

        public ProducerInfo(string name, string description, string version, Core.Identity.ClientIdentity identity)
        {
            this.name = name;
            this.description = description;
            this.version = version;
            this.identity = identity;
        }

    }
}
