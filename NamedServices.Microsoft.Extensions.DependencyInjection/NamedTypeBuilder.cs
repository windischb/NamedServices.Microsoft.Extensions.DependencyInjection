using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Reflection.Emit;
using Reflectensions.Helper;

namespace NamedServices.Microsoft.Extensions.DependencyInjection
{
    public static class NamedTypeBuilder {

        private static string RootNamespace = "NamedType";
        private static string RootEnumNamespace = "NamedEnumType";

        private static readonly string AssemblyName  = Guid.NewGuid().ToString();
        private static readonly AssemblyBuilder AssemblyBuilder  = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(AssemblyName), AssemblyBuilderAccess.Run);
        private static readonly ModuleBuilder ModuleBuilder  = AssemblyBuilder.DefineDynamicModule("NamedTypeModule");

        private static readonly ConcurrentDictionary<string, Type> ExistingNamedTypes = new ConcurrentDictionary<string, Type>();

        public static Type GetOrCreateNamedType(string key) {

            return ExistingNamedTypes.GetOrAdd($"{RootNamespace}.{key}", CreateNamedType);

        }

        public static Type GetOrCreateNamedType(Enum key) {

            var name = key.GetFullName();
            if (name.Contains(",")) {
                throw new ArgumentException("Only single Enums are supported!", nameof(key));
            }
            return ExistingNamedTypes.GetOrAdd($"{RootEnumNamespace}.{name}", CreateNamedType);

        }

        private static Type CreateNamedType(string key) {

            var tb = ModuleBuilder.DefineType(key,
                TypeAttributes.Public |
                TypeAttributes.Sealed,
                typeof(ValueType));

            var objectTypeInfo = tb.CreateTypeInfo();

            return objectTypeInfo.AsType();
        }

    }
}
