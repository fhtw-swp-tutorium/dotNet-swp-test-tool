//using System.Collections.Generic;
//using SWP_ObserverTest.ObserverDefintion.Examples;

//namespace Tests.ObserverTest.Examples
//{
//    [Subject]
//    public class Subject
//    {
//        private readonly List<IObserver> _observers;

//        public Subject()
//        {
//            _observers = new List<IObserver>();
//        }

//        public void UpdateObserver()
//        {
//            _observers.ForEach(o => o.Update());
//        }

//        public void Register(IObserver observer)
//        {
//            _observers.Add(observer);
//        }

//        public void Unregister(IObserver observer)
//        {
//            _observers.Remove(observer);
//        }
//    }
//}