using System;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace MVCLab.Attributes
{
    public sealed class MethodLogAttribute : InterceptorMethodAttribute
    {
        public override void OnExecuted()
        { Debug.WriteLine("MethodLogAttribute.OnExecuted"); }

        public override void OnExecuting()
        { Debug.WriteLine("MethodLogAttribute.OnExecuting"); }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
    public sealed class InterceptorAttribute : ContextAttribute, IContributeObjectSink
    {
        public InterceptorAttribute() : base("Interceptor")
        {

        }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new InterceptorHandler(nextSink);
        }
    }

    public sealed class InterceptorHandler : IMessageSink
    {
        public InterceptorHandler(IMessageSink nextSink)
        {
            NextSink = nextSink;
        }
        public IMessageSink NextSink { get; private set; }

        IMessageCtrl IMessageSink.AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            throw new NotImplementedException();
        }

        IMessage IMessageSink.SyncProcessMessage(IMessage msg)
        {
            IMessage result;
            IMethodCallMessage call = msg as IMethodCallMessage;
            if (call == null)
            {
                result = NextSink.SyncProcessMessage(msg);
            }
            else
            {

                var methodAttributes =
                    System.Attribute.GetCustomAttributes(call.MethodBase,
                    typeof(InterceptorMethodAttribute));
                if (methodAttributes == null)
                {
                    result = NextSink.SyncProcessMessage(msg);
                 }
                else
                {
                    foreach (var attribute in methodAttributes)
                    {
                        ((InterceptorMethodAttribute)attribute).OnExecuting();
                    }

                    result = NextSink.SyncProcessMessage(msg);

                    foreach (var attribute in methodAttributes)
                    {
                        ((InterceptorMethodAttribute)attribute).OnExecuted();
                    }
                }

            }
            result = NextSink.SyncProcessMessage(msg);
            return result;
        }
    }


    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public abstract class InterceptorMethodAttribute : System.Attribute
    {
        public abstract void OnExecuting();
        public abstract void OnExecuted();
    }
}