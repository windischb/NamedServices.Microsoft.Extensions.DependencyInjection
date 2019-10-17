using System;
using Microsoft.Extensions.DependencyInjection;

namespace NamedServices.Microsoft.Extensions.DependencyInjection {
    public class NamedTypeResolver {

        private IServiceProvider ServiceProvider { get; }

        public NamedTypeResolver(IServiceProvider serviceProvider) {
            ServiceProvider = serviceProvider;
        }


        public T GetNamedService<T>(string name) where T : class {

            var namedServiceType = NamedService.GenerateNamedServiceType<T>(name);
            var namedService = ServiceProvider.GetRequiredService(namedServiceType) as NamedService<T>;
            return namedService?.Service;
        }
    }
}
