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

            return !firstInstances.Where((t, i) => !object.ReferenceEquals(t, secondInstances[i])).Any();
        }

        public bool SingletonsNeverReturnNull()
        {
            return _singletons.Select(s => s.GetInstance()).All(i => i != null);
        }
    }
}