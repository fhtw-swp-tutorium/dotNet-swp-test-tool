using System;

namespace Tests.Common
{
    public abstract class TestDefintionBase
    {
        protected TestDefintionBase(string testGroupName)
        {
            TestGroupName = testGroupName;
        }

        public Type GetAssemblyIdentifier { get { return GetType(); } }
        public string TestGroupName { get; private set; }
    }
}