using System;
using Reflectensions.Helper;

namespace NamedServices.Microsoft.Extensions.DependencyInjection {
    public interface INamedService: IDisposable {

    }

    public interface INamedService<out T> : INamedService where T : class {

        T Service { get; }

    }
}
