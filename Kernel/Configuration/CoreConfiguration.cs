using System;
using System.Collections.Generic;

namespace Core.Configuration
{
    public class CoreConfiguration : Core.Configuration.ICoreConfiguration
    {
        private List<UserIdentity> userIdentities;
        private List<Type> producerTypes;

        public IEnumerable<UserIdentity> UserIdentities
        {
            get { return userIdentities; }
        }

        public IEnumerable<Type> ProducerTypes
        {
            get
            {
                return this.producerTypes;
            }
        }

        public CoreConfiguration()
        {
            this.userIdentities = new List<UserIdentity>();
            this.producerTypes = new List<Type>();
        }
    }
}
