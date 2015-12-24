using System;
using System.Collections.Generic;
using SwpStudentsSpecification.Exercise1.Observer;
using Tests.Common;

namespace Tests.ExerciseOne
{
    public class ObserverDefintion : ITestDefintion
    {
        public Type GetAssemblyIdentifier { get { return typeof(ObserverDefintion); } }

        public string TestGroupName { get { return "Observer"; }}
    }
}