using System;
using Microsoft.Extensions.DependencyInjection;

namespace NamedServices.Microsoft.Extensions.DependencyInjection {
    public class NamedServiceResolver {

        private IServiceProvider ServiceProvider { get; }

        public NamedServiceResolver(IServiceProvider serviceProvider) {

            ServiceProvider = serviceProvider;

        }


        public T GetNamedService<T>(string key) where T : class {

            var namedServiceType = NamedService.GenerateNamedServiceType<T>(key);
            var namedService = ServiceProvider.GetRequiredService(namedServiceType) as NamedService<T>;
            return namedService?.Service;

        }

        public T GetNamedService<T>(Enum key) where T : class {

            var namedServiceType = NamedService.GenerateNamedServiceType<T>(key);
            var namedService = ServiceProvider.GetRequiredService(namedServiceType) as NamedService<T>;
            return namedService?.Service;

        }
    }
}
