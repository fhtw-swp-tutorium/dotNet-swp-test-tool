using System;
using Castle.DynamicProxy;
using Tests.Common.Proxy;

namespace Tests.Observer.Driver
{
    public class ObserverProxy
    {
        public CountingInterceptor Interceptor { get; private set; }
        public object Proxy { get; private set; }

        public static ObserverProxy Create(Type type)
        {
            var generator = new ProxyGenerator();
            var interceptor = new CountingInterceptor();

            var proxy = generator.CreateInterfaceProxyWithoutTarget(type, interceptor);

            return new ObserverProxy(interceptor, proxy);
        }

        private ObserverProxy(CountingInterceptor interceptor, object proxy)
        {
            Proxy = proxy;
            Interceptor = interceptor;
        }
    }
}