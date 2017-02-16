using System;
using System.Collections.Generic;

namespace Domain
{
    public class Resource
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
        private List<MetaInfoValue> metainfos;

        private IList<String> fuas;
        private String foremostResourceId;
        private List<String> subordinateResourceIds;

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

        public List<MetaInfoValue> Metainfos
        {
          get { return metainfos; }
          set { metainfos = value; }
        }

        public IList<String> Fuas
        {
            get { return fuas; }
        }

        public String ForemostResourceId
        {
            get { return foremostResourceId; }
            set { foremostResourceId = value; }
        }

        public List<String> SubordinateResourceIds
        {
            get { return subordinateResourceIds; }
            set { subordinateResourceIds = value; }
        }

        #endregion

        #region Constructors

        public Resource()
            : this(null, null, null, Humanity.FeedType.unknown)
        {

        }

        public Resource(String channel, Source source, String matter, Humanity.FeedType feedType, String comment = null, params Domain.MetaInfoValue[] metainfos)
            : this(channel, source, DateTime.Now, matter, feedType, comment, metainfos)
        {

        }

        public Resource(String channel, Source source, DateTime timestamp, String matter, Humanity.FeedType feedType, String comment = null, params Domain.MetaInfoValue[] metainfos)
            : this(channel, source, timestamp, matter, feedType, null, comment, metainfos)
        {

        }

        public Resource(String channel, Source source, DateTime timestamp, String matter, Humanity.FeedType feedType, String mime, String comment = null, params Domain.MetaInfoValue[] metainfos)
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
            this.metainfos = new List<MetaInfoValue>(metainfos);
            
            this.fuas = new List<String>();
            this.foremostResourceId = null;
            this.subordinateResourceIds = new List<string>();
        }

        #endregion

    }
}
