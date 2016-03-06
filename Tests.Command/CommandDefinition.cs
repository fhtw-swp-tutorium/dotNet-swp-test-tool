using DotNetAttributes.Command;
using TestExecutor.Common.Reflection;
using Tests.Common;
using Tests.Common.TestTypes;

namespace Tests.Command
{
    public class CommandDefinition : TestDefintionBase
    {
        public CommandDefinition() : base("command") { }
        public override void RegisterTypeMappings(TypeMappingContainer typeMappingContainer)
        {
            typeMappingContainer.RegisterType("Invoker", typeof(InvokerAttribute));
            typeMappingContainer.RegisterType("InvokeCommand", typeof(InvokeCommandAttribute));
        }
    }
}