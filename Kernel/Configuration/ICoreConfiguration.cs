using System;
using System.Collections.Generic;

namespace Core.Configuration
{
    public interface ICoreConfiguration
    {
        IEnumerable<UserIdentity> UserIdentities { get; }
        IEnumerable<Type> ProducerTypes { get; }
    }
}
