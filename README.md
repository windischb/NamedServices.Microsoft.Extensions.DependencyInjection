# NamedServices.Microsoft.Extensions.DependencyInjection

Allowes you to use Named Services with Microsoft Dependency Injection.

To add a Named Service to DI one of the following ExtensionMethods an IServiceCollection can be used:

```csharp
AddNamed(this IServiceCollection serviceCollection, Type type, string name, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, string name, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, string name, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory, ServiceLifetime serviceLifetime);


/// Singleton

AddNamedSingleton(this IServiceCollection serviceCollection, string name, Type type);
AddNamedSingleton(this IServiceCollection serviceCollection, string name, Type type, Func<IServiceProvider, object> implementationFactory);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, string name);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory);


/// Scoped

AddNamedScoped(this IServiceCollection serviceCollection, string name, Type type);
AddNamedScoped(this IServiceCollection serviceCollection, string name, Type type, Func<IServiceProvider, object> implementationFactory);
AddNamedScoped<T>(this IServiceCollection serviceCollection, string name);
AddNamedScoped<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory);


/// Transient

AddNamedTransient(this IServiceCollection serviceCollection, string name, Type type);
AddNamedTransient(this IServiceCollection serviceCollection, string name, Type type, Func<IServiceProvider, object> implementationFactory);
AddNamedTransient<T>(this IServiceCollection serviceCollection, string name);
AddNamedTransient<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory);

```