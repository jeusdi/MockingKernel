
namespace Domain.Identity
{
    public class ClientIdentity : Identity.IIdentity<string>
    {
        private string client_id;
        private string name;

        #region Properties

        public string Id
        {
            get { return this.client_id; }
        }

        public string Name
        {
            get { return this.name; }
        }

        #endregion

        #region Constructors

        public ClientIdentity(string id, string name)
        {
            this.client_id = id;
            this.name = name;
        }

        #endregion
    }
}
