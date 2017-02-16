using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Communication.Entities
{
    public class UserIdentity
    {

        private string userId;
        private string password;

        #region Properties

        public string UserId
        {
            get { return this.userId; }
            set { this.userId = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        #endregion

        #region Constructors

        public UserIdentity()
            : this(null, null)
        {
            
        }

        public UserIdentity(string id, string password)
        {
            this.userId = id;
            this.password = password;
        }

        #endregion
    }
}
