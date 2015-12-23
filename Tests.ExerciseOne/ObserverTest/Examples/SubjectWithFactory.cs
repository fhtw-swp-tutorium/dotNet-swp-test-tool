//using System.Collections;
//using System.Collections.Generic;
//using SWP_ObserverTest.ObserverDefintion.Examples;

//namespace Tests.ObserverTest.Examples
//{
//    [Subject(typeof(SubjectFactory))]
//    public class SubjectWithFactory
//    {
//        private readonly List<IObserver> _observers;

//        public SubjectWithFactory(Hashtable hashtable)
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

//    public class SubjectFactory
//    {
//        public SubjectWithFactory Create()
//        {
//            return new SubjectWithFactory(null);
//        }
//    }
//}