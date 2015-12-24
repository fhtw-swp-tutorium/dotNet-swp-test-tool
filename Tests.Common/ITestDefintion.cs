using System;

namespace Tests.Common
{
    public interface ITestDefintion
    {
        Type GetAssemblyIdentifier { get; }
        string TestGroupName { get; }
    }
}