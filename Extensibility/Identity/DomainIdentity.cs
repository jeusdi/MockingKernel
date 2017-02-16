using System;
using System.Collections.Generic;

namespace Core.Identity
{
    public class DomainIdentity
    {
        private readonly UserIdentity userIdentity;
        private readonly ClientIdentity clientIdentity;

        #region Properties

        public UserIdentity UserIdentity
        {
            get { return userIdentity; }
        }

        public ClientIdentity ClientIdentity
        {
            get { return clientIdentity; }
        }

        #endregion

        private DomainIdentity(string userId, string userName, string password, string clientId, string clientName)
        {
            this.userIdentity = new UserIdentity(userId, userName, password);
            this.clientIdentity = new ClientIdentity(clientId, clientName);
        }

        public static DomainIdentity Create(UserIdentity userIdentity, ClientIdentity clientIdentity)
        {
            return new DomainIdentity(userIdentity.UserId, userIdentity.Name, userIdentity.Password, clientIdentity.ClientId, clientIdentity.Name);
        }

        #region Equals & HashCode overridings

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
            return (this.clientIdentity.ClientId == p.clientIdentity.ClientId) && (this.userIdentity.UserId == p.userIdentity.UserId);
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
            return this.userIdentity.UserId.GetHashCode() + this.clientIdentity.ClientId.GetHashCode();
        }

        #endregion

    }
}
