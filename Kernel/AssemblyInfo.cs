[assembly: Core.Aspects.Logging.ExceptionHandlingAspect()]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Tests.Kernel")]