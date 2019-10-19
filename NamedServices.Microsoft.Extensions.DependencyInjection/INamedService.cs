using System;
using Reflectensions.Helper;

namespace NamedServices.Microsoft.Extensions.DependencyInjection {
    public interface INamedService: IDisposable {
        object Service { get; }
    }

    public interface INamedService<out T> : INamedService where T : class {
        new T Service { get; }

    }
}
