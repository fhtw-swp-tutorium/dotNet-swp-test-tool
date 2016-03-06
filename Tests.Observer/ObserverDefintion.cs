using DotNetAttributes.Observer;
using TestExecutor.Common.Reflection;
using Tests.Common;
using Tests.Common.TestTypes;

namespace Tests.Observer
{
    public class ObserverDefinition : TestDefintionBase
    {
        public ObserverDefinition() :base("Observer") { }
        public override void RegisterTypeMappings(TypeMappingContainer typeMappingContainer)
        {
            typeMappingContainer.RegisterType("Subject", typeof (SubjectAttribute));
            typeMappingContainer.RegisterType("NotifyObservers", typeof (NotifyObserversAttribute));
            typeMappingContainer.RegisterType("RegisterObserver", typeof (RegisterObserverAttribute));
            typeMappingContainer.RegisterType("UnregisterObserver", typeof(UnregisterObserverAttribute));
        }
    }
}