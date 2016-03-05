using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;

namespace Tests.Observer.Driver
{
    public class SubjectProxy
    {
        private readonly object _subject;
        private readonly Dictionary<string, ObserverProxy> _observers;

        private readonly List<string> _addKeys = new List<string>() { "attach", "subscribe", "add", "register" };
        private readonly List<string> _removeKeys = new List<string>() { "detach", "unsubscribe", "remove", "unregister" };
        private readonly List<string> _updateKeys = new List<string>() { "notify", "update" };

        public SubjectProxy(object subject)
        {
            _subject = subject;
            _observers = new Dictionary<string, ObserverProxy>();
        }

        public bool HasAppropriateAddMethod { get { return GetAppropriateAddMethod() != null; } }

        public bool HasAppropriateRemvoeMethod { get { return GetAppropriateRemoveMethod() != null; } }

        public bool HasAppropriateUpdateMethod { get { return GetAppropriateUpdateMethod() != null; } }

        public void RegisterObserver(string name)
        {
            var observerProxy = ObserverProxy.Create(GetObserverType());
            _observers.Add(name, observerProxy);
            GetAppropriateAddMethod().Invoke(_subject, new[] { observerProxy.Proxy });
        }

        public void UnregisterObserver(string name)
        {
            var observerProxy = _observers[name];
            GetAppropriateRemoveMethod().Invoke(_subject, new[] { observerProxy.Proxy });
        }

        public void UpdateObserver()
        {
            GetAppropriateUpdateMethod().Invoke(_subject, new object[] { });
        }

        private MethodInfo GetAppropriateUpdateMethod()
        {
            return GetMethodsByKeywords(_updateKeys)
                .FirstOrDefault(updateMethod => !updateMethod.GetParameters().Any());
        }

        private MethodInfo GetAppropriateRemoveMethod()
        {
            return GetMethodsByKeywords(_removeKeys).
                Where(removeMethod => removeMethod.GetParameters().Count() == 1).
                FirstOrDefault(removeMethod => removeMethod.GetParameters().First().ParameterType.IsInterface);
        }

        private MethodInfo GetAppropriateAddMethod()
        {
            return GetMethodsByKeywords(_addKeys).
                Where(removeMethod => removeMethod.GetParameters().Count() == 1).
                FirstOrDefault(removeMethod => removeMethod.GetParameters().First().ParameterType.IsInterface);
        }

        private Type GetObserverType()
        {
            var registerObserverMethod = GetAppropriateAddMethod();
            return registerObserverMethod.GetParameters().First().ParameterType;
        }

        private List<MethodInfo> GetMethodsByKeywords(List<string> keywords)
        {
            return _subject.GetType().Methods().Where(m => keywords.Any(k => m.Name.ToLower().StartsWith(k))).ToList();
        }

        public ObserverProxy GetObserver(string name)
        {
            return _observers[name];
        }
    }
}