
using System;
namespace Domain
{

    public enum IndexableType
    {
        StringType,
        NumberType,
        DateTimeType
    }

    public abstract class IndexableProperty
    {
        private IndexableType indexable_type;
        private string key;
        private object value;

        #region Properties

        public IndexableType IndexableType
        {
            get { return indexable_type; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        #endregion

        public IndexableProperty(IndexableType indexable_type)
            : this(indexable_type, string.Empty, null)
        {
            this.indexable_type = indexable_type;
        }

        protected IndexableProperty(IndexableType indexable_type, string key, object value)
        {
            this.indexable_type = indexable_type;
            this.key = key;
            this.value = value;
        }

    }

    public class IndexableStringProperty : IndexableProperty
    {

        public IndexableStringProperty(string key, string value)
            : base (IndexableType.StringType, key, value)
        {

        }

    }

    public class IndexableNumberProperty : IndexableProperty
    {

        public IndexableNumberProperty(string key, double value)
            : base (IndexableType.NumberType, key, value)
        {

        }

    }

    public class IndexableDateProperty : IndexableProperty
    {

        public IndexableDateProperty(string key, DateTime value)
            : base (IndexableType.DateTimeType, key, value)
        {

        }

    }

}
