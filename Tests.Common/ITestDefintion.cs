using System;

namespace Test.Common
{
    public interface ITestDefintion
    {
        Type GetAssemblyIdentifier { get; }
        string TestGroupName { get; }
    }
}