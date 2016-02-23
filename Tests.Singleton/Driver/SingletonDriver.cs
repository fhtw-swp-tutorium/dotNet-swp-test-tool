using System.Collections.Generic;
using System.Linq;
using StudentsAttributes;
using TestExecutor.Common.Reflection;

namespace Tests.Singleton.Driver
{
    public class SingletonDriver
    {
        private List<SingletonProxy> _singletons;

        public List<SingletonProxy> Singletons
        {
            get { return _singletons ?? (_singletons = GetSingletons()); }
        }

        private List<SingletonProxy> GetSingletons()
        {
            return
                TypeProvider.GetTypesWithAttribute<SingletonAttribute>()
                    .Select(t => new SingletonProxy(t)).ToList();
        }
    }
}