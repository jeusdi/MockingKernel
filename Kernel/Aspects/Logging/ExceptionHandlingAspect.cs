using System;

namespace Core.Aspects.Logging
{
    [Serializable()]
    public class ExceptionHandlingAspect : PostSharp.Aspects.OnExceptionAspect
    {
        public override void OnException(PostSharp.Aspects.MethodExecutionArgs args)
        {
            log4net.LogManager.GetLogger("").Warn("EXCP-", args.Exception);
#if DEBUG
                args.FlowBehavior = PostSharp.Aspects.FlowBehavior.Default;
#else
                args.FlowBehavior = PostSharp.Aspects.FlowBehavior.Continue;
#endif
        }
    }
}