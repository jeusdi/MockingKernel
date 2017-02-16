using System.Collections.Generic;

namespace Core.Extensibility.Events
{
    public class NewDigitalInputsEventArgs
    {
        private Core.Identity.ClientIdentity clientIdentity;
        private Core.Identity.UserIdentity userIdentity;
        private IEnumerable<Backend.Domain.DigitalInput> digitalInputs;

        #region Properties

        public Core.Identity.UserIdentity UserIdentity { get { return this.userIdentity; } }
        public Core.Identity.ClientIdentity ClientIdentity { get { return this.clientIdentity; } }
        public IEnumerable<Backend.Domain.DigitalInput> DigitalInputs { get { return this.digitalInputs; } }

        #endregion

        private NewDigitalInputsEventArgs(Core.Identity.ClientIdentity clientIdentity, Core.Identity.UserIdentity userIdentity, IEnumerable<Backend.Domain.DigitalInput> digitalInputs)
        {
            this.clientIdentity = clientIdentity;
            this.userIdentity = userIdentity;
            this.digitalInputs = digitalInputs;
        }

        public static NewDigitalInputsEventArgs Create(Core.Identity.ClientIdentity clientIdentity, Core.Identity.UserIdentity userIdentity, IEnumerable<Backend.Domain.DigitalInput> digitalInputs)
        {
            return new NewDigitalInputsEventArgs(clientIdentity, userIdentity, digitalInputs);
        }
    }
}
