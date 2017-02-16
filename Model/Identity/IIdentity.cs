using System;

namespace Domain.Identity
{
    public interface IIdentity<T>
    {

        T Id { get; }
        String Name { get; }

    }
}
