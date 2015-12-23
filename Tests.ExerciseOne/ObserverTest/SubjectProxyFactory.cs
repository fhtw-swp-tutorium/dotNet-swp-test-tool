using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using SwpStudentsSpecification.Exercise1.Observer;

namespace Tests.ExerciseOne.ObserverTest
{
    public class SubjectProxyFactory
    {
        private readonly List<Type> _types;

        public SubjectProxyFactory(IEnumerable<Type> types)
        {
            _types = types.ToList();
        }

        public IEnumerable<SubjectProxy> ObserverProxiesOfAssembly()
        {
            var subjects = new List<SubjectProxy>();
            var subjectTypes = _types
                .Where(m => m.GetCustomAttributes(typeof(SubjectAttribute), false).Length > 0)
                .ToList();

            foreach (var subject in subjectTypes)
            {
                var customAttributes = (SubjectAttribute)subject.GetCustomAttribute(typeof(SubjectAttribute));
                var factoryType = customAttributes.Factory;

                object instance;

                if (factoryType != null)
                {
                    var factory = Activator.CreateInstance(factoryType);
                    var createMethod = factory.GetType().Methods().First(m => m.IsPublic && !m.GetParameters().Any());
                    instance = createMethod.Invoke(factory, new object[] { });
                }
                else
                {
                    instance = Activator.CreateInstance(subject);
                }

                subjects.Add(new SubjectProxy(instance));
            }

            return subjects;
        }
    }
}