using System;
using System.Collections.Generic;

namespace Domain.Identity
{
    public class DomainIdentity : IIdentity<KeyValuePair<UserIdentity, ClientIdentity>>
    {
        private UserIdentity userIdentity;
        private ClientIdentity clientIdentity;

        #region Properties

        public KeyValuePair<UserIdentity, ClientIdentity> Id
        {
            get { return new KeyValuePair<UserIdentity, ClientIdentity>(this.userIdentity, this.clientIdentity); }
        }

        public string Name
        {
            get { return String.Empty; }
        }

        #endregion

        public DomainIdentity(string userId, string userName, string password, string clientId, string clientName)
        {
            this.userIdentity = new UserIdentity(userId, userName, password);
            this.clientIdentity = new ClientIdentity(clientId, clientName);
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            DomainIdentity p = obj as DomainIdentity;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this.clientIdentity.Id == p.clientIdentity.Id) && (this.userIdentity.Id == p.userIdentity.Id);
        }

        //add this code to class ThreeDPoint as defined previously
        //
        public static bool operator ==(DomainIdentity a, DomainIdentity b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(DomainIdentity a, DomainIdentity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return this.userIdentity.Id.GetHashCode() + this.clientIdentity.Id.GetHashCode();
        }

    }
}
