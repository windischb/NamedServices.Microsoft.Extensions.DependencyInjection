using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace NamedServices.Microsoft.Extensions.DependencyInjection {
    public static class IServiceProviderExtensions {

        public static object GetRequiredNamedService(this IServiceProvider serviceProvider, Type type, string key) {

            var namedServiceType = NamedServiceHelper.GenerateNamedServiceType(key, type);
            var namedService = serviceProvider.GetRequiredService(namedServiceType) as INamedService;
            return namedService?.Service;

        }

        public static object GetRequiredNamedService(this IServiceProvider serviceProvider, Type type, Enum key) {

            var namedServiceType = NamedServiceHelper.GenerateNamedServiceType(key, type);
            var namedService = serviceProvider.GetRequiredService(namedServiceType) as INamedService;
            return namedService?.Service;

        }

        public static T GetRequiredNamedService<T>(this IServiceProvider serviceProvider, string key) where T : class {

            var namedServiceType = NamedServiceHelper.GenerateNamedServiceType<T>(key);
            var namedService = serviceProvider.GetRequiredService(namedServiceType) as INamedService<T>;
            return namedService?.Service;

        }

        public static T GetRequiredNamedService<T>(this IServiceProvider serviceProvider, Enum key) where T : class {

            var namedServiceType = NamedServiceHelper.GenerateNamedServiceType<T>(key);
            var namedService = serviceProvider.GetRequiredService(namedServiceType) as INamedService<T>;
            return namedService?.Service;

        }

        public static object GetNamedService(this IServiceProvider serviceProvider, Type type, string key) {

            var namedServiceType = NamedServiceHelper.GenerateNamedServiceType(key, type);
            var namedService = serviceProvider.GetService(namedServiceType) as INamedService;
            return namedService?.Service;

        }

        public static object GetNamedService(this IServiceProvider serviceProvider, Type type, Enum key) {

            var namedServiceType = NamedServiceHelper.GenerateNamedServiceType(key, type);
            var namedService = serviceProvider.GetService(namedServiceType) as INamedService;
            return namedService?.Service;

        }

        public static T GetNamedService<T>(this IServiceProvider serviceProvider, string key) where T : class {

            var namedServiceType = NamedServiceHelper.GenerateNamedServiceType<T>(key);
            var namedService = serviceProvider.GetService(namedServiceType) as INamedService<T>;
            return namedService?.Service;

        }

        public static T GetNamedService<T>(this IServiceProvider serviceProvider, Enum key) where T : class {

            var namedServiceType = NamedServiceHelper.GenerateNamedServiceType<T>(key);
            var namedService = serviceProvider.GetService(namedServiceType) as INamedService<T>;
            return namedService?.Service;

        }
    }
}
