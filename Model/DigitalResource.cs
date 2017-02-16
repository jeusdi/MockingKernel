using System;
using System.Collections.Generic;

namespace Domain
{
    public class DigitalResource
    {
        private String id;              // Generated on server
        private DateTime timestamp;
        private String matter;
        private String comment;

        private String channel;
        private Humanity.FeedType feedType;
        private Source source;          //Source description
        private String mime;
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

        public Humanity.FeedType FeedType
        {
            get { return feedType; }
            set { feedType = value; }
        }

        public Source Source
        {
            get { return source; }
            set { source = value; }
        }

        public String Mime
        {
            get { return mime; }
            set { mime = value; }
        }

        public List<IndexableProperty> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public List<DigitalResource> Resources
        {
            get { return resources; }
            set { resources = value; }
        }

        #endregion

        #region Constructors

        public DigitalResource()
            : this(null, null, null, Humanity.FeedType.unknown)
        {

        }

        public DigitalResource(String channel, Source source, String matter, Humanity.FeedType feedType, String comment = null)
            : this(channel, source, DateTime.Now, matter, feedType, comment)
        {

        }

        public DigitalResource(String channel, Source source, DateTime timestamp, String matter, Humanity.FeedType feedType, String comment = null)
            : this(channel, source, timestamp, matter, feedType, null, comment)
        {

        }

        public DigitalResource(String channel, Source source, DateTime timestamp, String matter, Humanity.FeedType feedType, String mime, String comment = null)
        {
            this.id = String.Empty;
            this.timestamp = timestamp;
            this.matter = matter;
            this.comment = comment;

            this.channel = channel;
            this.feedType = feedType;
            this.source = source;
            this.mime = mime;
            this.properties = new List<IndexableProperty>();
            this.resources = new List<DigitalResource>();
        }

        #endregion

    }
}
