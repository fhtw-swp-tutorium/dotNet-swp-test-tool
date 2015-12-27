using System;

namespace Tests.Common
{
    public abstract class TestDefintionBase
    {
        public Type GetAssemblyIdentifier { get { return GetType(); } }
        public abstract string TestGroupName { get; }
    }
}