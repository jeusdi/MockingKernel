
namespace Core.Mapping.Profile.Communication
{
    internal class UserIdentityProfile : AutoMapper.Profile
    {

        protected override void Configure()
        {
            this.CreateMap<Core.Communication.Entities.UserIdentity, Core.Identity.UserIdentity>()
                .ConstructUsing(
                    (System.Func<Core.Communication.Entities.UserIdentity, Core.Identity.UserIdentity>)
                    (comm => Identity.UserIdentity.Create(comm.UserId, comm.UserId, comm.Password))
                );
        }
    }
}
