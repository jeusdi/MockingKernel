namespace Core.Extensibility
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class ClientIdAttribute : System.Attribute
    {
        private string client_id;
        public double version;

        public string ClientId
        {
            get { return client_id; }
            set { client_id = value; }
        }

        public ClientIdAttribute(string client_id)
        {
            this.client_id = client_id;
            version = 1.0;
        }
    }
}
