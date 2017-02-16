using System;

namespace Domain
{
    public class Channel
    {
        private String id;
        private String name;
        private String description;

        #region Properties

        public virtual String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        #endregion

        #region Constructors

        public Channel()
            : this(null, null, null)
        {
            
        }

        public Channel(String id, String name, String description = null)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        #endregion

        public override string ToString()
        {
            return this.name;
        }
    }
}