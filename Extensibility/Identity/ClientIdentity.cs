namespace Core.Identity
{
    public class ClientIdentity
    {
        private string clientId;
        private string name;

        #region Properties

        public string ClientId
        {
            get { return this.clientId; }
        }

        public string Name
        {
            get { return this.name; }
        }

        #endregion

        #region Constructors

        public ClientIdentity(string id, string name)
        {
            this.clientId = id;
            this.name = name;
        }

        #endregion
    }
}