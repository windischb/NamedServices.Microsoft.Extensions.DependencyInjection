using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Reflection.Emit;

namespace NamedServices.Microsoft.Extensions.DependencyInjection
{
    public static class NamedTypeBuilder {

        private static string RootNamespace = "NamedType";

        private static readonly string AssemblyName  = Guid.NewGuid().ToString();
        private static readonly AssemblyBuilder AssemblyBuilder  = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(AssemblyName), AssemblyBuilderAccess.Run);
        private static readonly ModuleBuilder ModuleBuilder  = AssemblyBuilder.DefineDynamicModule("NamedTypeModule");

        private static readonly ConcurrentDictionary<string, Type> ExistingNamedTypes = new ConcurrentDictionary<string, Type>();

        public static Type GetOrCreateNamedType(string name) {

            return ExistingNamedTypes.GetOrAdd(name, CreateNamedType);

        }

        private static Type CreateNamedType(string name) {

            var tb = ModuleBuilder.DefineType($"{RootNamespace}.{name}",
                TypeAttributes.Public |
                TypeAttributes.Sealed,
                typeof(ValueType));

            var objectTypeInfo = tb.CreateTypeInfo();

            return objectTypeInfo.AsType();
        }

    }
}
