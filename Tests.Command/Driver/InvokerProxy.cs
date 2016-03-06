using System.Linq;
using DotNetAttributes.Command;

namespace Tests.Command.Driver
{
    public class InvokerProxy
    {
        private readonly object _invoker;

        private InvokerProxy(object invoker)
        {
            _invoker = invoker;
        }

        public static InvokerProxy Create(object invoker)
        {
            return new InvokerProxy(invoker);
        }

        public void ExecuteCommand(CommandProxy commandProxy)
        {
            var executeMethod = _invoker.GetType().GetMethods().Single(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(InvokeCommandAttribute)));
            executeMethod.Invoke(_invoker, new[] {commandProxy.Proxy});
        }
    }
}