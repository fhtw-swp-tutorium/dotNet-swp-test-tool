using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using SwpStudentsSpecification.Exercise1.Observer;
using Testrunner.Core.Services;

namespace Testrunner.Tests
{
    [TestFixture]
    public class ArgumentParserTest
    {
        private const string ValidPath = @"C:\Temp\TimeManagement\TimeManagement\bin\Debug\TimeManagement.exe";
        private const string InvalidPath = @"C:\Temp\TimeManagement\TimeManagement\bin\Debug\TimeManagement.pdf";

        [TestCase(new[] { "exe", ValidPath, "ue1" }, ValidPath, "ue1")]
        [TestCase(new[] { "exe", ValidPath, "ue2" }, ValidPath, "ue2")]
        [TestCase(new[] { "exe", ValidPath, "ue3" }, ValidPath, "ue3")]
        [TestCase(new[] { "ue3", "exe", ValidPath },  ValidPath, "ue3")]
        public void ValidArguments(string[] agruments, string exePath, string exercise)
        {
            var argumentParser = new ArgumentParser();
            var argumentResult = argumentParser.Parse(agruments);

            Assert.IsTrue(argumentResult.IsValid);

            Assert.IsTrue(argumentResult.ExePath == exePath);
            Assert.IsTrue(argumentResult.Exercise.ExerciseAbbreviation == exercise);
        }

        [TestCase("ue4", "exe", ValidPath)]
        [TestCase("ue4", ValidPath, "exe")]
        [TestCase("ue3", "exe", InvalidPath)]
        [TestCase("ue3", "exe", ValidPath, "ue2")]
        public void InvalidArguments(params string[] agruments)
        {
            var argumentParser = new ArgumentParser();
            var argumentResult = argumentParser.Parse(agruments);

            Assert.IsFalse(argumentResult.IsValid);
        }

        [Test]
        public void TestAssembly()
        {
            var types = new List<Type>();

            var loadFrom = Assembly.LoadFrom(@"C:\Temp\TimeManagement\TimeManagement\bin\Debug\TimeManagement.exe");

            types.AddRange(loadFrom.GetTypes());

            //loadFrom = Assembly.LoadFrom(@"C:\Temp\TimeManagement\TimeManagement\bin\Debug\SwpStudentsSpecification.dll");

            //types.AddRange(loadFrom.GetTypes());

            loadFrom = Assembly.LoadFrom(@"C:\Temp\TimeManagement\TimeManagement\bin\Debug\Observer.dll");

            types.AddRange(loadFrom.GetTypes());

            var subjectattr = new List<SubjectAttribute>();

            foreach (var type in types)
            {
                var subjectAttribute = type.GetCustomAttribute<SubjectAttribute>(false);
                if(subjectAttribute != null) subjectattr.Add(subjectAttribute);
            }
        }
    }
}
