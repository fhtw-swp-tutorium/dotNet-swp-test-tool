using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using StudentsAttributes;
using TestExecutor.Common.Reflection;

namespace Tests.Singleton
{
    [TestFixture]
    public class SingletonTest
    {
        private IList<SingletonDriver> _singletonDrivers;

        [SetUp]
        public void TestSetup()
        {
            _singletonDrivers = 
                TypeProvider.GetTypesWithAttribute<SingletonAttribute>()
                .Select(t => new SingletonDriver(t)).ToList();
        }

        [Test]
        public void AtLeastOneSingletonShouldExists()
        {
            _singletonDrivers.Count
                .Should().BeGreaterOrEqualTo(1, because: "there has to be at least one class with a singleton attribute");
        }

        [Test]
        public void SingletonShouldProvideInstanceFieldOrAccessorMethod()
        {
            foreach (var singleton in _singletonDrivers)
            {
                singleton.HasInstancePropertyOrMethod()
                    .Should().BeTrue(because: "there has to be at least one instance method or property in every singleton");
            }
        }

        [Test]
        public void SingletonShouldHaveNonPublicConstructor()
        {
            foreach (var singleton in _singletonDrivers)
            {
                singleton.HasNoPublicConstructor()
                    .Should().BeTrue(because: "every singleton should have non public constructor");
            }
        }

        [Test]
        public void SingletonAccessorShouldReturnSameInstance()
        {
            foreach (var singleton in _singletonDrivers)
            {
                var firstInstance = singleton.GetInstance();
                var secondInstance = singleton.GetInstance();

                firstInstance
                    .Should().NotBeNull().And
                    .Should().BeSameAs(secondInstance, because: "singletons always have to return the same instance");
            }
        }
    }
}