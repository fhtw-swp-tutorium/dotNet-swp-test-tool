using System.Linq;
using DotNetAttributes.Observer;

namespace Tests.Observer.Driver
{
    public class SubjectProxy
    {
        private readonly object _subject;

        private SubjectProxy(object subject)
        {
            _subject = subject;
        }

        public static SubjectProxy Create(object observer)
        {
            return new SubjectProxy(observer);
        }

        public void RegisterObserver(ObserverProxy observerProxy)
        {
            var registerMethod = _subject.GetType().GetMethods().Single(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(RegisterObserverAttribute)));
            registerMethod.Invoke(_subject, new[] { observerProxy.Proxy });
        }

        public void UnregisterObserver(ObserverProxy observerProxy)
        {
            var registerMethod = _subject.GetType().GetMethods().Single(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(UnregisterObserverAttribute)));
            registerMethod.Invoke(_subject, new[] { observerProxy.Proxy });
        }

        public void Notify()
        {
            var registerMethod = _subject.GetType().GetMethods().Single(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(NotifyObserversAttribute)));
            registerMethod.Invoke(_subject, new object[0]);
        }
    }
}