namespace Core.Mapping.Profile.Configuration
{
    internal class UserIdentityProfile : AutoMapper.Profile
    {

        protected override void Configure()
        {
            this.CreateMap<Core.Configuration.UserIdentity, Core.Identity.UserIdentity>()
                .ConstructUsing(
                    (System.Func<Core.Configuration.UserIdentity, Core.Identity.UserIdentity>)
                    (u => Core.Identity.UserIdentity.Create(u.UserId, u.UserId, u.Password))
                );

            this.CreateMap<Core.Identity.UserIdentity, Core.Configuration.UserIdentity>();
        }

    }
}
