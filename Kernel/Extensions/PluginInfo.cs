using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class PluginInfo
    {
        private string id;
        private string version;
        private string name;
        private string description;

        #region Properties

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion

        public PluginInfo(string id, string version, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.version = version;
        }
    }
}
