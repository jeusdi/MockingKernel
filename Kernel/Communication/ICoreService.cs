using System.Collections.Generic;
using System.ServiceModel;

namespace Core.Communication
{
    [ServiceContract]
    public interface ICoreService
    {
        [OperationContract]
        IEnumerable<Core.Communication.Entities.Plugin> GetPlugins(Communication.Entities.UserIdentity userIdentity);

        [OperationContract]
        IEnumerable<Communication.Entities.ChannelPlugin> GetPluginChannels(Communication.Entities.UserIdentity userIdentity);
        [OperationContract]
        IEnumerable<Communication.Entities.ChannelPlugin> GetPluginChannelsById(Communication.Entities.UserIdentity userIdentity, string pluginId);

        #region ICoreConfiguration interface

        [OperationContract]
        void AddUserIdentity(Communication.Entities.UserIdentity userIdentity);

        [OperationContract]
        void RemoveUserIdentity(Communication.Entities.UserIdentity userIdentity);

        #endregion

    }
}
