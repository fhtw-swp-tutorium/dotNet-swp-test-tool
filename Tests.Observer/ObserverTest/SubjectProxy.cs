using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using FluentAssertions;

namespace Tests.ExerciseOne.ObserverTest
{
    public class SubjectProxy
    {
        private readonly object _subject;

        public SubjectProxy(object subject)
        {
            _subject = subject;
        }

        public void InvokeUpdateObserversMethod()
        {
            GetUpdateObserverMethod().Invoke(_subject, new object[] { });
        }

        public void InvokeRegisterObserverMethod(object proxy)
        {
            GetRegisterObserverMethod().Invoke(_subject, new [] { proxy });
        }

        public void InvokeUnregisterObserverMethod(object proxy)
        {
            GetUnRegisterObserverMethod().Invoke(_subject, new [] { proxy });
        }

        public Type GetObserverType()
        {
            var registerObserverMethod = GetRegisterObserverMethod();
            return registerObserverMethod.GetParameters().First().ParameterType;
        }

        public CountingObserverProxyWrapper CreateCountingObserverInterceptor()
        {
            var generator = new ProxyGenerator();
            var interceptor = new CountingInterceptor();

            var proxy = generator.CreateInterfaceProxyWithoutTarget(GetObserverType(), interceptor);

            return new CountingObserverProxyWrapper(interceptor, proxy);
        }

        public MethodInfo GetRegisterObserverMethod()
        {
            var keywords = new List<string>()
            {
                "attach",
                "subscribe",
                "add",
                "register"
            };

            return GetSingleMethodByKeywords(keywords);
        }

        public MethodInfo GetUnRegisterObserverMethod()
        {
            var keywords = new List<string>()
            {
                "detach",
                "unsubscribe",
                "remove",
                "unregister"
            };

            return GetSingleMethodByKeywords(keywords);
        }

        public MethodInfo GetUpdateObserverMethod()
        {
            var keywords = new List<string>()
            {
                "notify",
                "update",
            };

            return GetSingleMethodByKeywords(keywords);
        }

        private MethodInfo GetSingleMethodByKeywords(List<string> keywords)
        {
            return _subject.GetType().Methods().Single(m => keywords.Any(k => m.Name.ToLower().StartsWith(k)));
        }
    }


    public class CountingObserverProxyWrapper
    {
        public CountingObserverProxyWrapper(CountingInterceptor interceptor, object proxy)
        {
            Proxy = proxy;
            Interceptor = interceptor;
        }

        public CountingInterceptor Interceptor { get; private set; }
        public object Proxy { get; private set; }
    }

    public class CountingInterceptor : StandardInterceptor
    {
        public int Count { get; private set; }

        protected override void PerformProceed(IInvocation invocation)
        {
            Count++;
        }
    }

}