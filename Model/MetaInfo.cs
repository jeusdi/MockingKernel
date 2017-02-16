
using System;
using System.Collections.Generic;
namespace Domain
{

    public enum IndexableMetaInfoType
    {
        StringType,
        NumberType,
        DateTimeType
    }

    public class MetaInfo
    {
        private String id;
        private IndexableMetaInfoType indexableType;
        private string key;
        private string description;
        private IList<object> values;

        #region Properties

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public IndexableMetaInfoType IndexableType
        {
            get { return indexableType; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public IList<object> Values
        {
            get { return values; }
            set { values = value; }
        }

        #endregion

        public MetaInfo(IndexableMetaInfoType indexableType)
            : this(null, indexableType, string.Empty, null)
        {
            
        }

        public MetaInfo(IndexableMetaInfoType indexableType, string key, string description)
            : this(null, indexableType, key, description)
        {
            
        }

        public MetaInfo(String id, IndexableMetaInfoType indexableType, string key, string description)
            : this(id, indexableType, key, description, new List<object>())
        {
            
        }

        public MetaInfo(String id, IndexableMetaInfoType indexableType, string key, string description, IList<object> values)
        {
            this.id = id;
            this.indexableType = indexableType;
            this.key = key;
            this.description = description;
            this.values = values ?? new List<object>();
        }
    }

    public class StringMetaInfo : MetaInfo
    {
        public StringMetaInfo(string key, string description, IList<String> values)
            : base(null, IndexableMetaInfoType.StringType, key, description, (IList<object>)values)
        {

        }
    }

    public class NumberMetaInfo : MetaInfo
    {
        public NumberMetaInfo(string key, string description, IList<double> values)
            : base(null, IndexableMetaInfoType.NumberType, key, description, (IList<object>)values)
        {

        }
    }

    public class DateMetaInfo : MetaInfo
    {
        public DateMetaInfo(string key, string description, IList<DateTime> values)
            : base(null, IndexableMetaInfoType.DateTimeType, key, description, (IList<object>)values)
        {

        }
    }

    public abstract class MetaInfoValue
    {
        private IndexableMetaInfoType indexableType;
        private string key;
        private object value;

        #region Properties

        public IndexableMetaInfoType IndexableType
        {
            get { return indexableType; }
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

        public MetaInfoValue(IndexableMetaInfoType indexableType)
            : this(indexableType, string.Empty, null)
        {
            this.indexableType = indexableType;
        }

        protected MetaInfoValue(IndexableMetaInfoType indexable_type, string key, object value)
        {
            this.indexableType = indexable_type;
            this.key = key;
            this.value = value;
        }
    }

    public class StringMetaInfoValue : MetaInfoValue
    {

        public StringMetaInfoValue(string key, string value)
            : base(IndexableMetaInfoType.StringType, key, value)
        {

        }

    }

    public class NumberMetaInfoValue : MetaInfoValue
    {

        public NumberMetaInfoValue(string key, double value)
            : base(IndexableMetaInfoType.NumberType, key, value)
        {

        }

    }

    public class DateMetaInfoValue : MetaInfoValue
    {

        public DateMetaInfoValue(string key, DateTime value)
            : base(IndexableMetaInfoType.DateTimeType, key, value)
        {

        }

    }

}
