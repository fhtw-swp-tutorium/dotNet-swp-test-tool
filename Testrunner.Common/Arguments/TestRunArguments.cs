namespace Testrunner.Common.Arguments
{
    public class TestRunArguments
    {
        public TestRunArguments(string exercise, string exePath)
        {
            Exercise = exercise;
            ExePath = exePath;
        }

        public string ExePath { get; private set; }
        public string Exercise { get; private set; }
    }
}