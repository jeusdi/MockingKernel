using System.Collections.Generic;

namespace Core.Extensibility.Events
{
    public class RemovedDigitalInputsEventArgs
    {
        private Core.Identity.ClientIdentity clientIdentity;
        private Core.Identity.UserIdentity userIdentity;
        private IEnumerable<Backend.Domain.Source.SourceId> sources;

        #region Properties

        public Core.Identity.UserIdentity UserIdentity { get { return this.userIdentity; } }
        public Core.Identity.ClientIdentity ClientIdentity { get { return this.clientIdentity; } }
        public IEnumerable<Backend.Domain.Source.SourceId> Sources { get { return this.sources; } }

        #endregion

        private RemovedDigitalInputsEventArgs(Core.Identity.ClientIdentity clientIdentity, Core.Identity.UserIdentity userIdentity, IEnumerable<Backend.Domain.Source.SourceId> sources)
        {
            this.clientIdentity = clientIdentity;
            this.userIdentity = userIdentity;
            this.sources = sources;
        }

        public static RemovedDigitalInputsEventArgs Create(Core.Identity.ClientIdentity clientIdentity, Core.Identity.UserIdentity userIdentity, IEnumerable<Backend.Domain.Source.SourceId> sources)
        {
            return new RemovedDigitalInputsEventArgs(clientIdentity, userIdentity, sources);
        }
    }
}
