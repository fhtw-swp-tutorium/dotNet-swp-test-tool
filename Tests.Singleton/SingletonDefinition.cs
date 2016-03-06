using DotNetAttributes.Singleton;
using TestExecutor.Common.Reflection;
using Tests.Common;
using Tests.Common.TestTypes;

namespace Tests.Singleton
{
    public class SingletonDefinition : TestDefintionBase
    {
        public SingletonDefinition() : base("Singleton") { }
        public override void RegisterTypeMappings(TypeMappingContainer typeMappingContainer)
        {
            typeMappingContainer.RegisterType("Singleton", typeof(SingletonAttribute));
        }
    }
}