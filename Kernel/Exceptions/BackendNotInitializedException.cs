using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class BackendNotInitializedException : Exception
    {

        private Core.Identity.UserIdentity userIdentity;
        private Core.Identity.ClientIdentity clientIdentity;

        public BackendNotInitializedException(Core.Identity.UserIdentity userIdentity, Core.Identity.ClientIdentity clientIdentity)
        {
            this.userIdentity = userIdentity;
            this.clientIdentity = clientIdentity;
        }

        public override string Message
        {
            get
            {
                return String.Format("There is no initialized backend for identity (user: id - {0}, name - {1} / client: id - {2}, name - {3})", this.userIdentity.UserId, this.userIdentity.Name, this.clientIdentity.ClientId, this.clientIdentity.Name);
            }
        }
    }
}
