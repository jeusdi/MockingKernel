namespace Core.Mapping.Profile.Communication
{
    internal class PluginProfile : AutoMapper.Profile
    {

        protected override void Configure()
        {
            this.CreateMap<Core.Extensions.PluginInfo, Core.Communication.Entities.Plugin>();
            this.CreateMap<Core.Communication.Entities.Plugin, Core.Extensions.PluginInfo>();
        }

    }
}
