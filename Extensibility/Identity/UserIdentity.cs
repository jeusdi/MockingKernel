namespace Core.Identity
{
    public class UserIdentity
    {

        private string userId;
        private string username;
        private string password;

        #region Properties

        public string UserId
        {
            get { return this.userId; }
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

        internal UserIdentity(string id, string username, string password)
        {
            this.userId = id;
            this.username = username;
            this.password = password;
        }

        public static UserIdentity Create(string id, string username, string password)
        {
            return new UserIdentity(id, username, password);
        }

        #endregion

        #region Equals & GetHashCode

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().IsAssignableFrom(obj.GetType()))
                return false;

            UserIdentity other = (UserIdentity)obj;
            return this.userId.Equals(other.UserId);
        }

        public override int GetHashCode()
        {
            return (this.userId == null) ? (base.GetHashCode()) : (this.userId.GetHashCode());
        }

        #endregion
    }
}