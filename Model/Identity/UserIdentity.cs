
namespace Domain.Identity
{
    public class UserIdentity : Identity.IIdentity<string>
    {

        private string user_id;
        private string username;
        private string password;

        #region Properties

        public string Id
        {
            get { return this.user_id; }
        }

        public string Name
        {
            get { return this.username; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        #endregion

        #region Constructors

        public UserIdentity(string id, string username, string password)
        {
            this.user_id = id;
            this.username = username;
            this.password = password;
        }

        #endregion
    }
}
