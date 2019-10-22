using System;

namespace NamedServices.Microsoft.Extensions.DependencyInjection
{
    internal static class NamedServiceHelper {

        public static Type GenerateNamedServiceType<T>(string key) {

            var namedType = NamedTypeBuilder.GetOrCreateNamedType(key);
            return typeof(NamedService<,>).MakeGenericType(typeof(T), namedType);

        }

        public static Type GenerateNamedServiceType(string key, Type type) {

            var namedType = NamedTypeBuilder.GetOrCreateNamedType(key);
            return typeof(NamedService<,>).MakeGenericType(type, namedType);

        }

        public static Type GenerateNamedServiceInterfaceType(string key, Type type) {

            var namedType = NamedTypeBuilder.GetOrCreateNamedType(key);
            return typeof(INamedService<,>).MakeGenericType(type, namedType);

        }


        public static Type GenerateNamedServiceType<T>(Enum key) {

            var namedType = NamedTypeBuilder.GetOrCreateNamedType(key);
            return typeof(NamedService<,>).MakeGenericType(typeof(T), namedType);

        }

        public static Type GenerateNamedServiceType(Enum key, Type type) {

            var namedType = NamedTypeBuilder.GetOrCreateNamedType(key);
            return typeof(NamedService<,>).MakeGenericType(type, namedType);

        }

        public static Type GenerateNamedServiceInterfaceType(Enum key, Type type) {

            var namedType = NamedTypeBuilder.GetOrCreateNamedType(key);
            return typeof(INamedService<,>).MakeGenericType(type, namedType);

        }

    }
}
