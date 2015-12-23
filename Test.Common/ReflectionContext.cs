using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Test.Common
{
    public static class ReflectionContext
    {
        public static IReadOnlyList<Type> Types { get; private set; }

        public static void Initialize(string exePath)
        {
            var directoryName = Path.GetDirectoryName(exePath);

            var assemblies = Directory
                .EnumerateFiles(directoryName)
                .Where(
                    file =>
                        (file.ToLower().EndsWith(".dll") ||
                         file.ToLower().EndsWith(".exe") && !file.ToLower().EndsWith(".vshost.exe")) &&
                        !file.EndsWith("SwpStudentsSpecification.dll"))
                .Select(Assembly.LoadFrom);

            Types = assemblies
                .SelectMany(a => a.GetTypes())
                .ToList();
        }
    }
}
