using System;

namespace NamedServices.Microsoft.Extensions.DependencyInjection {
    internal interface INamedService: IDisposable {
        object Service { get; }
    }

    internal interface INamedService<out T> : INamedService where T : class {
        new T Service { get; }

    }
}
