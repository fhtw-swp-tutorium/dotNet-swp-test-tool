using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Common;

namespace TestExecutor.Common.Reflection
{
    public static class TypeProvider
    {
        private const string SwpAttributesDllName = "dotNetAttributes";
        private static string _directoryName;
        private static ILoggerFacade _loggerFacade;
        private static Dictionary<string, Type> _typeMap;

        public static void Initialize(ILoggerFacade loggerFacade, string exePath)
        {
            _directoryName = Path.GetDirectoryName(exePath);
            _loggerFacade = loggerFacade;
            _typeMap = new Dictionary<string, Type>();

            try
            {
                var assemblies = Directory
                    .EnumerateFiles(_directoryName)
                    .Where(
                        file =>
                            (file.ToLower().EndsWith(".dll") ||
                             file.ToLower().EndsWith(".exe") && !file.ToLower().EndsWith(".vshost.exe")) &&
                            !file.EndsWith(SwpAttributesDllName+".dll"))
                    .Select(Assembly.LoadFrom).ToList();

                Types = assemblies
                    .SelectMany(a => a.GetTypes())
                    .ToList();
            }
            catch (ReflectionTypeLoadException e)
            {
                throw new SwpTestToolException(
                    "Fehler beim Laden einer oder mehrerer angegebenen Assemblies/Anwendungen im angegeben Ordner, wird die Anwendung möglicherweise zur Ziet ausgeführt?",
                    e);
            }            
        }

        public static IReadOnlyCollection<Type> GetTypesWithAttribute<T>() where T : Attribute
        {
            return Types.Where(m => m.GetCustomAttributes<T>(false).Any()).ToList();
        }

        public static IReadOnlyCollection<Type> GetTypesWithAttribute(Type attributeType)
        {
            return Types.Where(m => m.GetCustomAttributes(attributeType, false).Any()).ToList();
        }

        public static IReadOnlyList<Type> Types { get; private set; }

        public static bool CheckCorrectVersionOfAttributeAssembly(Type type)
        {
            var studentsAttributeDllFullPath = Path.Combine(_directoryName, SwpAttributesDllName + ".dll");

            var studentsAttributeDllVersion = FileVersionInfo.GetVersionInfo(studentsAttributeDllFullPath).FileVersion;
            var swpTestToolsAttributeDllVersion = type.Assembly.GetReferencedAssemblies().First(a => a.Name == SwpAttributesDllName).Version.ToString();

            var versionsAreEqual = swpTestToolsAttributeDllVersion == studentsAttributeDllVersion;

            if(!versionsAreEqual)
                _loggerFacade.Error(String.Format("Die Versionen der {0} Assembly stimmen nicht überein. Das Tool verwendet die Version {1} und Ihre Anwendung die Version {2}", SwpAttributesDllName, swpTestToolsAttributeDllVersion, studentsAttributeDllVersion));
            
            return versionsAreEqual;
        }

        public static bool CheckIfAttributeAssemblyExists()
        {
            var studentsAttributeDllFullPath = Path.Combine(_directoryName, SwpAttributesDllName + ".dll");

            var attributeDllExists = File.Exists(studentsAttributeDllFullPath);
            if (!attributeDllExists)
                _loggerFacade.Error(string.Format("Es konnte keine {0} Assembly gefunden werden.", SwpAttributesDllName));

            return attributeDllExists;
        }


        public static void RegisterTypeMappings(TypeMappingContainer typeMappingContainer)
        {
            foreach (var type in typeMappingContainer.TypeMap)
            {
                _typeMap.Add(type.Key, type.Value);
            }
        }

        public static Type GetType(string mappingName)
        {
            if (!_typeMap.ContainsKey(mappingName))
                throw new Exception($"Type for typename ({mappingName}) can not be found");

            return _typeMap[mappingName];
        }
    }
}
