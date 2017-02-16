using System.Collections.Generic;

namespace Core
{
    public partial class Kernel
    {

        #region DigitalInputs

        private string handleNewDigitalInputsNotification(Core.Identity.ClientIdentity clientIdentity, Core.Identity.UserIdentity userIdentity, IEnumerable<Backend.Domain.DigitalInput> digitalInputs)
        {
            Backend.Infrastructure.IBackend backend = this.LookForBackend(userIdentity, clientIdentity);
            return backend.saveDigitalInputs(digitalInputs);
        }

        private void handleDeletedSourcesNotification(Core.Identity.ClientIdentity clientIdentity, Core.Identity.UserIdentity userIdentity, IEnumerable<Backend.Domain.Source.SourceId> sourceIds)
        {
            Backend.Infrastructure.IBackend backend = this.LookForBackend(userIdentity, clientIdentity);
            backend.deleteSources(sourceIds);
        }

        #endregion

    }
}
