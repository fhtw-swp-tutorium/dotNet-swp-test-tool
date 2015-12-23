using System;
using System.Collections.Generic;
using SwpStudentsSpecification.Exercise1.Observer;
using Test.Common;

namespace Tests.ExerciseOne
{
    public class ObserverDefintion : ITestDefintion
    {
        public Type GetAssemblyType
        {
            get { return typeof(ObserverDefintion); }
        }
    }
}