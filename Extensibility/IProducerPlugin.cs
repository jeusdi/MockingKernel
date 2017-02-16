using System;
using System.Collections.Generic;

namespace Core.Extensibility
{
    public interface IProducerPlugin
    {

        ProducerInfo ProducerInfo { get; }

        void Initialize();

        IEnumerable<Guid> TypeGuids { get; }

        IEnumerable<Backend.Domain.DigitalInput> GetDigitalInputs();
        IEnumerable<string> GetChannels();

        event Events.NotifyNewDigitalInputsEventHandler notifyNewDigitalInputs;
        event Events.NotifyRemovedSourcesEventHandler notifyRemovedSources;

    }
}
