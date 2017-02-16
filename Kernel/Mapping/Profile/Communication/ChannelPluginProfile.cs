namespace Core.Mapping.Profile.Communication
{
    internal class ChannelPluginProfile : AutoMapper.Profile
    {

        protected override void Configure()
        {
            this.CreateMap<string, Core.Communication.Entities.ChannelPlugin>()
                .ForMember(dst => dst.Channel, opts => opts.MapFrom(src => src));
        }

    }
}
