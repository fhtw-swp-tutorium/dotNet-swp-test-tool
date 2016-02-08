using Castle.DynamicProxy;

namespace Tests.ExerciseOne.Driver
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