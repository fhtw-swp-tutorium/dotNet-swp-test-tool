using System.Collections.Generic;
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

        public static bool EveryClassMethodHasParameters(this TypeContext typeContext, int parameterNumber)
            => typeContext.ClassMethodList.All(c => c.Value.All(m => m.GetParameters().Length == parameterNumber));

        public static bool EveryClassMethodsParameterIsAnInterface(this TypeContext typeContext)
            => typeContext.ClassMethodList.All(c => c.Value.All(m => m.GetParameters().All(p => p.ParameterType.IsInterface)));

        public static bool EveryClassHasOneMethodWithPrefix(this TypeContext typeContext, IEnumerable<string> prefixes)
        {
            foreach (var classMethod in typeContext.ClassMethodList)
            {
                var methodInfos = classMethod.Value;
                var enumerable = methodInfos.Where(m => prefixes.Any(p => m.Name.ToLower().Contains(p)));

                if (!enumerable.Any()) return false;
            }

            return true;
        }



        public static bool EveryInterfaceParameterHasAnImplementation(this TypeContext typeContext)
        {
            return
                typeContext.EveryClassHasOneMethod() &&
                typeContext.EveryClassMethodHasParameters(1) &&
                typeContext.EveryClassMethodsParameterIsAnInterface() &&
                typeContext.ClassMethodList.All(m =>
                {
                    var firstParamterType = m.Value.First().GetParameters().First().ParameterType;
                    return TypeProvider.Types.Count(t => t.Implements(firstParamterType)) >= 1;
                });
        }
    }
}