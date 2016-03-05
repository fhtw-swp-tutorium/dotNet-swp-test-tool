using System;
using Castle.DynamicProxy;
using Tests.Common;
using Tests.Common.Proxy;

namespace Tests.Command.Driver
{
    public class CommandProxy
    {
        public CountingInterceptor Interceptor { get; private set; }
        public object Proxy { get; private set; }

        public static CommandProxy Create(Type type)
        {
            var generator = new ProxyGenerator();
            var interceptor = new CountingInterceptor();

            var proxy = generator.CreateInterfaceProxyWithoutTarget(type, interceptor);

            return new CommandProxy(interceptor, proxy);
        }

        public CommandProxy(CountingInterceptor interceptor, object proxy)
        {
            Proxy = proxy;
            Interceptor = interceptor;
        }
    }
}