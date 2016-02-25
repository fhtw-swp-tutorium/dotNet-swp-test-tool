using System.Linq;
using FluentAssertions.Common;
using TestExecutor.Common.Reflection;
using Tests.Common;

namespace Tests.Command
{
    public static class CommandAssertions
    {
        public static bool EveryInterfaceParameterHasAnImplementation(this TestTypeContext testTypeContext)
        {
            return
                testTypeContext.EveryClassHasOneMethod() &&
                testTypeContext.EveryClassMethodHasOneParamter() &&
                testTypeContext.EveryClassMethodsParameterIsAnInterface() &&
                testTypeContext.ClassMethodList.All(m =>
                {
                    var firstParamterType = m.Value.First().GetParameters().First().ParameterType;
                    return TypeProvider.Types.Count(t => t.Implements(firstParamterType)) >= 1;
                });
        }
    }
}