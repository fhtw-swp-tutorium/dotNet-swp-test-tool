using System.Collections.Generic;
using System.Linq;
using Tests.Common.TestTypes;

namespace Tests.Singleton.Driver
{
    public class SingletonDriver
    {
        private List<SingletonProxy> _singletons;

        public void GenerateSingletons(TypeContext typeContext)
        {
            _singletons = typeContext.ClassMethodList.Keys.Select(SingletonProxy.Generate).ToList();
        }

        public bool SingletonsCanBeAccessed()
        {
            return _singletons.All(s => s.HasInstancePropertyOrMethod());
        }

        public bool SingletonsHavePrivateConstructor()
        {
            return _singletons.All(s => s.HasNoPublicConstructor());
        }

        public bool SingletonsAlwaysReturnTheSameInstance()
        {
            var firstInstances = _singletons.Select(s => s.GetInstance()).ToList();
            var secondInstances = _singletons.Select(s => s.GetInstance()).ToList();

            for (int i = 0; i < firstInstances.Count; i++)
            {
                if (!object.ReferenceEquals(firstInstances[i], secondInstances[i])) return false;
            }

            return true;
        }

        public bool SingletonsNeverReturnNull()
        {
            return _singletons.Select(s => s.GetInstance()).All(i => i != null);
        }
    }
}