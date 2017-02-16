using System;
using System.Collections.Generic;

namespace Domain
{
    public class DigitalInput
    {
        private String id;              // Generated on server
        private DateTime timestamp;
        private String matter;
        private String comment;
        private String channel;
        private List<Humanity.FeedType> feedTypes;
        private List<IndexableProperty> properties;
        private List<DigitalResource> resources;

        #region Properties

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

        public String Matter
        {
            get { return matter; }
            set { matter = value; }
        }

        public String Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public String Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        public List<IndexableProperty> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public List<Humanity.FeedType> FeedTypes
        {
            get { return feedTypes; }
            set { feedTypes = value; }
        }

        public List<DigitalResource> Resources
        {
            get { return resources; }
            set { resources = value; }
        }

        #endregion

        #region Constructors

        public DigitalInput()
            : this(null, null)
        {

        }

        public DigitalInput(String channel, String matter, String comment = null, params Humanity.FeedType[] feedTypes)
            : this(channel, DateTime.Now, matter, comment, feedTypes)
        {

        }

        public DigitalInput(String channel, DateTime timestamp, String matter, String comment = null, params Humanity.FeedType[] feedTypes)
            : this(channel, timestamp, matter, new List<DigitalResource>(), comment, feedTypes)
        {

        }

        public DigitalInput(String channel, DateTime timestamp, String matter, List<DigitalResource> resources, String comment = null, params Humanity.FeedType[] feedTypes)
        {
            this.id = String.Empty;
            this.timestamp = timestamp;
            this.matter = matter;
            this.comment = comment;

            this.channel = channel;
            this.properties = new List<IndexableProperty>();
            this.resources = resources;
            this.feedTypes = new List<Humanity.FeedType>(feedTypes);
        }

        #endregion

    }
}
