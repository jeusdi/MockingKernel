namespace Core.Extensibility.Events
{
    public delegate string NotifyNewDigitalInputsEventHandler(Core.Extensibility.IProducerPlugin sender, NewDigitalInputsEventArgs args);
    public delegate void NotifyRemovedSourcesEventHandler(Core.Extensibility.IProducerPlugin sender, RemovedDigitalInputsEventArgs args);
}
