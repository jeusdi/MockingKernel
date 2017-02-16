using System;
using System.Collections.Generic;

namespace Core
{
    public interface IKernel
    {

        Core.Configuration.ICoreConfiguration Configuration { get; }
        Core.Communication.ICoreService CoreService { get; }

        IEnumerable<Core.Identity.UserIdentity> UserIdentities { get; }

        void Initialize();

        IEnumerable<string> GetPluginChannels(Core.Identity.UserIdentity userIdentity);
        IEnumerable<Core.Extensions.PluginInfo> GetPlugins(Core.Identity.UserIdentity userIdentity);
        IEnumerable<string> GetPluginChannels(Core.Identity.UserIdentity userIdentity, string pluginId);
    }
}
