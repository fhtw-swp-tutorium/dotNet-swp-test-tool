using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestExecutor.Common.Reflection
{
    public static class TypeProvider
    {
        public static IReadOnlyCollection<Type> GetTypesWithAttribute<T>() where T : Attribute
        {
            return Types.Where(m => m.GetCustomAttributes<T>(false).Any()).ToList();
        } 

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
                        !file.EndsWith("StudentsAttributes.dll"))
                .Select(Assembly.LoadFrom);

            Types = assemblies
                .SelectMany(a => a.GetTypes())
                .ToList();
        }
    }
}
