
namespace Core.Configuration
{
    public class UserIdentity
    {
        private string userId;
        private string password;

        #region Properties

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        #endregion

        internal UserIdentity()
            : this(null, null)
        {
            
        }

        internal UserIdentity(string userId, string passwd)
        {
            this.userId = userId;
            this.password = passwd;
        }

        public static UserIdentity Create(string userId, string passwd)
        {
            return new UserIdentity(userId, passwd);
        }
    }
}
