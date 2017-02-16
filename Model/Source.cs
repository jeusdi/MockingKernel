using System;
using System.Collections.Generic;

namespace Domain
{

    public class Source
    {

        #region Nested Classes

        public class SourceId
        {
            private string id;
            private string batch;
            private string client;

            #region Properties

            public string Id
            {
                get { return id; }
                set { id = value; }
            }

            public string Batch
            {
                get { return batch; }
                set { batch = value; }
            }

            public string ClientId
            {
                get { return client; }
                set { client = value; }
            }

            #endregion

            #region Constructors

            public SourceId()
                : this(null, null, null)
            {

            }

            public SourceId(string id, string batch, string client)
            {
                this.id = id;
                this.batch = batch;
                this.client = client;
            }

            #endregion

        }

        #endregion

        private SourceId id;
        private Humanity.FeedType feedType;
        private List<IndexableProperty> properties;

        #region Properties

        public SourceId Id
        {
            get { return id; }
            set { id = value; }
        }

        public Humanity.FeedType FeedType
        {
            get { return feedType; }
            set { feedType = value; }
        }

        public List<IndexableProperty> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        #endregion

        #region Constructors

        public Source(SourceId id, Humanity.FeedType feed_type)
        {
            this.id = id;
            this.feedType = feed_type;
            this.properties = new List<IndexableProperty>();
        }

        #endregion
    }

}
