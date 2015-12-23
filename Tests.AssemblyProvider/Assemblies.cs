using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Testrunner.Core.Services.ArgumentParser;

namespace Tests.AssemblyProvider
{
    public static class Assemblies
    {
        public static Arguments CurrentArguments { get; set; }

        public static IEnumerable<Assembly> GetAssembly(Type type)
        {
            if(CurrentArguments == null) throw new Exception("CurrentArguments are null");

            var directoryName = Path.GetDirectoryName(CurrentArguments.ExePath);

            var assemblies = Directory
                .EnumerateFiles(directoryName)
                .Where(file =>file.ToLower().EndsWith(".dll") || file.ToLower().EndsWith(".exe") && !file.ToLower().EndsWith(".vshost.exe"))
                .Select(Assembly.LoadFile).ToList();

            return assemblies;
        }
    }
}
