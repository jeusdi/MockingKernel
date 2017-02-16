using Ninject;

namespace Core.IoC
{
    internal interface INinjectServiceLocator
    {
        Ninject.IKernel Kernel { get; }
    }
}