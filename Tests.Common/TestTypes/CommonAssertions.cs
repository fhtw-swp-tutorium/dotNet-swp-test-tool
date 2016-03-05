using System.Linq;
using FluentAssertions.Common;
using TestExecutor.Common.Reflection;

namespace Tests.Common.TestTypes
{
    public static class CommonAssertions
    {
        public static bool ClassListHasEntries(this TypeContext typeContext)
            => typeContext.ClassMethodList.Any();

        public static bool EveryClassHasOneMethod(this TypeContext typeContext)
            => typeContext.ClassMethodList.All(c => c.Value.Count == 1);

        public static bool EveryClassMethodHasOneParamter(this TypeContext typeContext)
            => typeContext.ClassMethodList.All(c => c.Value.All(m => m.GetParameters().Length == 1));

        public static bool EveryClassMethodsParameterIsAnInterface(this TypeContext typeContext)
            => typeContext.ClassMethodList.All(c => c.Value.All(m => m.GetParameters().All(p => p.ParameterType.IsInterface)));

        public static bool EveryInterfaceParameterHasAnImplementation(this TypeContext typeContext)
        {
            return
                typeContext.EveryClassHasOneMethod() &&
                typeContext.EveryClassMethodHasOneParamter() &&
                typeContext.EveryClassMethodsParameterIsAnInterface() &&
                typeContext.ClassMethodList.All(m =>
                {
                    var firstParamterType = m.Value.First().GetParameters().First().ParameterType;
                    return TypeProvider.Types.Count(t => t.Implements(firstParamterType)) >= 1;
                });
        }
    }
}