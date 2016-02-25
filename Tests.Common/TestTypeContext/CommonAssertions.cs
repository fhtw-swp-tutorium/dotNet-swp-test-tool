using System.Linq;

namespace Tests.Common
{
    public static class CommonAssertions
    {
        public static bool ClassListHasEntries(this TestTypeContext testTypeContext)
            => testTypeContext.ClassMethodList.Any();

        public static bool EveryClassHasOneMethod(this TestTypeContext testTypeContext)
            => testTypeContext.ClassMethodList.All(c => c.Value.Count == 1);

        public static bool EveryClassMethodHasOneParamter(this TestTypeContext testTypeContext)
            => testTypeContext.ClassMethodList.All(c => c.Value.All(m => m.GetParameters().Length == 1));

        public static bool EveryClassMethodsParameterIsAnInterface(this TestTypeContext testTypeContext)
            => testTypeContext.ClassMethodList.All(c => c.Value.All(m => m.GetParameters().All(p => p.ParameterType.IsInterface)));
    }
}