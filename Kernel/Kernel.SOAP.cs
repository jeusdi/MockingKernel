using System.Collections.Generic;
using System.ServiceModel;
using Core.Communication.Entities;

namespace Core
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, IncludeExceptionDetailInFaults = true), XmlSerializerFormat]
    public partial class Kernel : Core.Communication.ICoreService
    {

        #region ICoreService interface implementation

        IEnumerable<Communication.Entities.Plugin> Communication.ICoreService.GetPlugins(Communication.Entities.UserIdentity userIdentity)
        {
            Core.Identity.UserIdentity coreUserIdentity = this.mapper.Map<Communication.Entities.UserIdentity, Core.Identity.UserIdentity>(userIdentity);
            IEnumerable<Core.Extensions.PluginInfo> plugins = this.GetPlugins(coreUserIdentity);
            return this.mapper.Map<IEnumerable<Core.Extensions.PluginInfo>, IEnumerable<Core.Communication.Entities.Plugin>>(plugins);
        }

        IEnumerable<Communication.Entities.ChannelPlugin> Communication.ICoreService.GetPluginChannels(Communication.Entities.UserIdentity userIdentity)
        {
            Core.Identity.UserIdentity coreUserIdentity = this.mapper.Map<Communication.Entities.UserIdentity, Core.Identity.UserIdentity>(userIdentity);
            IEnumerable<string> channels = this.GetPluginChannels(coreUserIdentity);
            foreach (string channel in channels)
                yield return new Communication.Entities.ChannelPlugin(null, channel);
        }

        IEnumerable<ChannelPlugin> Communication.ICoreService.GetPluginChannelsById(UserIdentity userIdentity, string pluginId)
        {
            Core.Identity.UserIdentity coreUserIdentity = this.mapper.Map<Communication.Entities.UserIdentity, Core.Identity.UserIdentity>(userIdentity);
            IEnumerable<string> channels = this.GetPluginChannels(coreUserIdentity, pluginId);
            foreach (string channel in channels)
                yield return new Communication.Entities.ChannelPlugin(null, channel);
        }

        void Communication.ICoreService.AddUserIdentity(Communication.Entities.UserIdentity userIdentity)
        {
            Core.Identity.UserIdentity coreUserIdentity = this.mapper.Map<Communication.Entities.UserIdentity, Core.Identity.UserIdentity>(userIdentity);
            this.observableUserIdentities.Add(coreUserIdentity);
        }

        void Communication.ICoreService.RemoveUserIdentity(Communication.Entities.UserIdentity userIdentity)
        {
            Core.Identity.UserIdentity coreUserIdentity = this.mapper.Map<Communication.Entities.UserIdentity, Core.Identity.UserIdentity>(userIdentity);
            this.observableUserIdentities.Remove(coreUserIdentity);
        }

        #endregion

    }
}
