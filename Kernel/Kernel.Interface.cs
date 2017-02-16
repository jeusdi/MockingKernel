using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public partial class Kernel
    {

        #region Plugins

        public IEnumerable<Core.Extensions.PluginInfo> GetPlugins(Core.Identity.UserIdentity userIdentity)
        {
            foreach (Core.Identity.DomainIdentity domainIdentity in this.backends.Keys.Where(dI => dI.UserIdentity.UserId.Equals(userIdentity.UserId)))
                foreach (Extensibility.IProducerPlugin producer in this.producers.Where(p => p.ProducerInfo.Identity.ClientId.Equals(domainIdentity.ClientIdentity.ClientId)))
                {
                    Extensibility.ProducerInfo producerInfo = producer.ProducerInfo;
                    yield return new Core.Extensions.PluginInfo(producerInfo.Identity.ClientId, producerInfo.Version, producerInfo.Name, producerInfo.Description);
                }
        }

        public IEnumerable<string> GetPluginChannels(Core.Identity.UserIdentity userIdentity)
        {
            IEnumerable<string> channels = Enumerable.Empty<string>();

            foreach (Core.Identity.DomainIdentity domainIdentity in this.backends.Keys.Where(dI => dI.UserIdentity.UserId.Equals(userIdentity.UserId)))
                foreach (Extensibility.IProducerPlugin producer in this.producers.Where(p => p.ProducerInfo.Identity.ClientId.Equals(domainIdentity.ClientIdentity.ClientId)))
                    channels = channels.Union(producer.GetChannels());

            return channels;
        }

        public IEnumerable<string> GetPluginChannels(Core.Identity.UserIdentity userIdentity, string pluginId)
        {
            IEnumerable<string> channels = Enumerable.Empty<string>();

            foreach (Extensibility.IProducerPlugin producer in this.producers.Where(p => p.ProducerInfo.Identity.ClientId.Equals(pluginId)))
                channels = channels.Union(producer.GetChannels());

            return channels;
        }

        #endregion

    }
}
