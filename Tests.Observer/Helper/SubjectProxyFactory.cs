using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using StudentsAttributes;
using TestExecutor.Common.Reflection;

namespace Tests.ExerciseOne.Helper
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
            var subjectTypes = TypeProvider.GetTypesWithAttribute<SubjectAttribute>().ToList();

            foreach (var subject in subjectTypes)
            {
                var customAttributes = subject.GetCustomAttribute<SubjectAttribute>();
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