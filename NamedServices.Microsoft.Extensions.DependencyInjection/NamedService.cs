using System;

namespace NamedServices.Microsoft.Extensions.DependencyInjection {

    public class NamedService {

        public static Type GenerateNamedServiceType<T>(string name) {
            var namedType = NamedTypeBuilder.GetOrCreateNamedType(name);
            return typeof(NamedService<,>).MakeGenericType(typeof(T), namedType);
        }

        public static Type GenerateNamedServiceType(string name, Type type) {
            var namedType = NamedTypeBuilder.GetOrCreateNamedType(name);
            return typeof(NamedService<,>).MakeGenericType(type, namedType);
        }

    }

    public class NamedService<T>: NamedService, IDisposable where T : class {

        public T Service { get; private set; }

        public NamedService(T service) {
            Service = service;
        }

        ~NamedService() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing) {
            if (disposing) {
                // free managed resources
                if (Service != null) {
                    if (Service is IDisposable disposable) {
                        disposable.Dispose();
                    }
                    Service = null;
                }
            }

        }

    }

    public class NamedService<TService, TNamed>: NamedService<TService> where TService: class where TNamed : struct {
        
        public string Name => typeof(TNamed).Name;

        public NamedService(TService service) : base(service)
        {
        }
    }
}
