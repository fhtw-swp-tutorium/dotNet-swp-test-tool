using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using FluentAssertions;
using NUnit.Framework;
using ReflectionContext = Test.Common.ReflectionContext;

namespace Tests.ExerciseOne.ObserverTest
{
    [TestFixture]
    public class ObserverTest
    {
        private IEnumerable<SubjectProxy> _subjectProxies;
        private IEnumerable<Type> _types;

        [SetUp]
        public void Setup()
        {
            _types = ReflectionContext.Types;

            var subjectProxyFactory = new SubjectProxyFactory(_types);
            _subjectProxies = subjectProxyFactory.ObserverProxiesOfAssembly();
        }

        [Test]
        public void CheckIfAtLeastOneSubjectExists()
        {
            _subjectProxies.Should().HaveCount(c => c > 0, because: "at least one subject has to exist in the project");
        }

        [Test]
        public void CheckIfObserverTypeIsInterface()
        {
            _subjectProxies.All(s => s.GetObserverType().IsInterface).Should().Be(true, because: "all observers should be interfaces");
        }

        [Test]
        public void CheckUpdateObserverMethod()
        {
            _subjectProxies.ForEach(sp =>
            {
                sp.GetUpdateObserverMethod().Should().NotBeNull(because: "UpdateObserver Method has to exist in every subject");
            });
        }

        [Test]
        public void CheckRegisterObserverMethod()
        {
            _subjectProxies.ForEach(sp =>
            {
                sp.GetRegisterObserverMethod().Should().NotBeNull(because: "RegisterObserver Method has to exist in every subject");
            });

        }
        [Test]
        public void CheckUnregisterObserverMethod()
        {
            _subjectProxies.ForEach(sp =>
            {
                sp.GetUnRegisterObserverMethod().Should().NotBeNull(because: "UnRegisterObserver Method has to exist in every subject");
            });

        }

        [Test]
        public void RegisterObserver()
        {
            var subjectProxyFactory = new SubjectProxyFactory(_types);
            var subjects = subjectProxyFactory.ObserverProxiesOfAssembly();

            foreach (var subject in subjects)
            {
                var countingObserverProxyWrapper = subject.CreateCountingObserverInterceptor();

                subject.InvokeRegisterObserverMethod(countingObserverProxyWrapper.Proxy);
                subject.InvokeUpdateObserversMethod();
                subject.InvokeUpdateObserversMethod();

                var count = countingObserverProxyWrapper.Interceptor.Count;
                count.Should().Be(2, because: "observers are updated twice");
            }
        }

        [Test]
        public void UnRegisterObserver()
        {
            var registerProxyFactory = new SubjectProxyFactory(_types);
            var subjects = registerProxyFactory.ObserverProxiesOfAssembly();

            foreach (var subject in subjects)
            {
                var countingObserverProxyWrapper = subject.CreateCountingObserverInterceptor();

                subject.InvokeRegisterObserverMethod(countingObserverProxyWrapper.Proxy);
                subject.InvokeUpdateObserversMethod();

                subject.InvokeUnregisterObserverMethod(countingObserverProxyWrapper.Proxy);
                subject.InvokeUpdateObserversMethod();

                var count = countingObserverProxyWrapper.Interceptor.Count;
                count.Should().Be(1, "because the observer is deleted after the first update");
            }
        }

        [Test]
        public void WorkingWithTwoObservers()
        {
            var registerProxyFactory = new SubjectProxyFactory(_types);
            var subjects = registerProxyFactory.ObserverProxiesOfAssembly();

            foreach (var subject in subjects)
            {
                var firstObserver = subject.CreateCountingObserverInterceptor();
                var secondObserver = subject.CreateCountingObserverInterceptor();

                subject.InvokeRegisterObserverMethod(firstObserver.Proxy);
                subject.InvokeRegisterObserverMethod(secondObserver.Proxy);

                subject.InvokeUpdateObserversMethod();
                subject.InvokeUpdateObserversMethod();
                subject.InvokeUpdateObserversMethod();

                subject.InvokeUnregisterObserverMethod(firstObserver.Proxy);
                subject.InvokeUnregisterObserverMethod(secondObserver.Proxy);

                subject.InvokeUpdateObserversMethod();

                var countOne = firstObserver.Interceptor.Count;
                var countTwo = secondObserver.Interceptor.Count;
                countOne.Should().Be(3, "because the first observer is updated three times");
                countTwo.Should().Be(3, "because the second observer is updated three times");
            }
        }
    }

    //public static class ReflectionExtensions
    //{
    //    public static List<MethodInfo> GetMethodsWithAttribute(this Assembly assembly, Type attribute)
    //    {
    //        return assembly.GetTypes()
    //                  .SelectMany(t => t.GetMethods())
    //                  .Where(m => m.GetCustomAttributes(attribute, false).Length > 0)
    //                  .ToList();
    //    }

    //    public static List<MethodInfo> GetMethodsWithAttribute(this Assembly assembly, Type classAttribute, Type attribute)
    //    {
    //        return assembly.GetClassesWithAttribute(classAttribute)
    //                  .SelectMany(t => t.GetMethods())
    //                  .Where(m => m.GetCustomAttributes(attribute, false).Length > 0)
    //                  .ToList();
    //    }

    //    public static List<MethodInfo> GetMethodsWithAttributeFromObject(this Assembly assembly, object classAttribute, Type attribute)
    //    {
    //        return classAttribute.GetType()
    //                  .GetMethods()
    //                  .Where(m => m.GetCustomAttributes(attribute, false).Length > 0)
    //                  .ToList();
    //    }

    //}
}