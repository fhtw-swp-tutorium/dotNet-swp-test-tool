using System;
using System.Collections.Generic;
using System.Linq;
using DotNetAttributes.Observer;
using Tests.Common.Proxy;
using Tests.Common.TestTypes;

namespace Tests.Observer.Driver
{
    public class ObserverDriver
    {
        private List<SubjectProxy> _subjects;
        private List<ObserverProxy> _observerProxies; 

        public void GenerateSubjects(TypeContext typeContext)
        {
            var types = typeContext.ClassMethodList.Keys;
            var invokerObjects = new ObjectFactory().GenerateObjects(typeof(SubjectAttribute), types);

            _subjects = invokerObjects.Select(SubjectProxy.Create).ToList();
        }

        public void GenerateObserver(TypeContext typeContext)
        {
            var registerMethods = typeContext.OnlyMethodsWithAttribute(typeof(RegisterObserverAttribute));
            var observerInterfaces = new List<Type>();
            registerMethods.ClassMethodList.Values.ToList().ForEach(m =>
            {
                var parameterType = m.First().GetParameters().First().ParameterType;
                if (!parameterType.IsInterface) throw new ArgumentException("Parameter is no interface");
                observerInterfaces.Add(parameterType);
            });

            _observerProxies = observerInterfaces.Select(ObserverProxy.Create).ToList();
        }

        public void RegisterObserver()
        {
            if (_subjects.Count != _observerProxies.Count)
                throw new Exception("there are not the some number of  Subjects and Observers");

            for (var i = 0; i < _subjects.Count; i++)
            {
                _subjects[i].RegisterObserver(_observerProxies[i]);
            }
        }

        public void UnregisterObserver()
        {
            if (_subjects.Count != _observerProxies.Count)
                throw new Exception("there are not the some number of  Subjects and Observers");

            for (var i = 0; i < _subjects.Count; i++)
            {
                _subjects[i].UnregisterObserver(_observerProxies[i]);
            }
        }

        public void NotifyObservers()
        {
            foreach (SubjectProxy subject in _subjects)
            {
                subject.Notify();
            }
        }

        public bool ObserversHaveBeenCalledAtLeast(int times)
        {
            return _observerProxies.All(c => c.Interceptor.Count >= times);
        }

        public bool ObserversHaveNeverBeenCalled()
        {
            return _observerProxies.All(c => c.Interceptor.Count == 0);
        }
    }
}