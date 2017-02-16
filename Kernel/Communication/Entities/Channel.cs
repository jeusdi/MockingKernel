namespace Core.Communication.Entities
{
    public class ChannelPlugin
    {
        private Plugin plugin;
        private string channel;

        #region Properties

        public Plugin Plugin
        {
            get { return plugin; }
            set { plugin = value; }
        }

        public string Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        #endregion

        public ChannelPlugin()
            : this(null, null)
        {

        }

        public ChannelPlugin(Plugin plugin, string channel)
        {
            this.plugin = null;
            this.channel = channel;
        }
    }
}
