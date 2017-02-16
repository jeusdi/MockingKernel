using System;
using System.Collections.Generic;

namespace Domain
{
    public enum FollowUpActivityStatus
    {
        open,
        closed,
        delegated
    }

    public enum FollowUpActivityBacklogStatus
    {
        work,
        sprint
    }

    public class FollowUpActivity
    {
        private String id;              // Generated on server
        private DateTime? creationDate;
        private DateTime? startDate;
        private DateTime? dueDate;
        private DateTime? closingDate;
        private String matter;
        private String comment;
        private FollowUpActivityStatus? status;
        private FollowUpActivityBacklogStatus? backlogStatus;
        private List<MetaInfoValue> metainfos;
        private IList<Relations.FuaContextualizedResource> resources;

        #region Properties

        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime? CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        public DateTime? StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime? DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public DateTime? ClosingDate
        {
            get { return closingDate; }
            set { closingDate = value; }
        }

        public FollowUpActivityStatus? Status
        {
            get { return status; }
            set { status = value; }
        }

        public FollowUpActivityBacklogStatus? BacklogStatus
        {
            get { return backlogStatus; }
            set { backlogStatus = value; }
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

        public List<MetaInfoValue> Metainfos
        {
          get { return metainfos; }
          set { metainfos = value; }
        }

        public IList<Relations.FuaContextualizedResource> Resources
        {
            get { return resources; }
        }

        #endregion

        #region Constructors

        public FollowUpActivity()
            : this(null, null)
        {

        }

        public FollowUpActivity(String matter, String comment = null, params Domain.MetaInfoValue[] metainfos)
            : this(DateTime.Now, matter, comment, metainfos)
        {

        }

        public FollowUpActivity(DateTime creationDate, String matter, String comment = null, params Domain.MetaInfoValue[] metainfos)
            : this(creationDate, matter, new List<Relations.FuaContextualizedResource>(), comment, metainfos)
        {

        }

        public FollowUpActivity(DateTime creationDate, String matter, List<Relations.FuaContextualizedResource> resources, String comment = null, params Domain.MetaInfoValue[] metainfos)
            : this(creationDate, matter, null, new List<Relations.FuaContextualizedResource>(), comment, metainfos)
        {

        }

        public FollowUpActivity(DateTime creationDate, String matter, FollowUpActivityBacklogStatus? backlogStatus, List<Relations.FuaContextualizedResource> resources, String comment = null, params Domain.MetaInfoValue[] metainfos)
            : this(creationDate, null, null, null, matter, FollowUpActivityStatus.open, backlogStatus, new List<Relations.FuaContextualizedResource>(), comment, metainfos)
        {

        }

        public FollowUpActivity(DateTime? creationDate, DateTime? startDate, DateTime? dueDate, DateTime? closingDate, String matter, FollowUpActivityStatus status, FollowUpActivityBacklogStatus? backlogStatus, List<Relations.FuaContextualizedResource> resources, String comment = null, params Domain.MetaInfoValue[] metainfos)
        {
            this.id = null;
            this.creationDate = creationDate;
            this.startDate = startDate;
            this.dueDate = dueDate;
            this.closingDate = closingDate;
            this.matter = matter;
            this.comment = comment;
            this.status = status;
            this.backlogStatus = backlogStatus;

            this.metainfos = new List<MetaInfoValue>(metainfos);
            this.resources = resources;
        }

        #endregion

    }
}
