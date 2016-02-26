using Castle.DynamicProxy;

namespace Tests.Common
{
    public class CountingInterceptor : StandardInterceptor
    {
        public int Count { get; private set; }

        protected override void PerformProceed(IInvocation invocation)
        {
            Count++;
        }
    }
}