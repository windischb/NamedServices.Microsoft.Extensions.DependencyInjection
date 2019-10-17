# NamedServices.Microsoft.Extensions.DependencyInjection

Allowes you to use Named Services with Microsoft Dependency Injection.

To add a Named Service to DI one of the following ExtensionMethods an IServiceCollection can be used:

```csharp
public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string name, ServiceLifetime serviceLifetime)
public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string name, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime)
public static IServiceCollection AddNamed<T>(this IServiceCollection serviceCollection, string name, ServiceLifetime serviceLifetime)
public static IServiceCollection AddNamed<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory, ServiceLifetime serviceLifetime)


/// Singleton

public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, string name, Type type)
public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, string name, Type type, Func<IServiceProvider, object> implementationFactory)
public static IServiceCollection AddNamedSingleton<T>(this IServiceCollection serviceCollection, string name) where T : class
public static IServiceCollection AddNamedSingleton<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory) where T : class


/// Scoped

public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, string name, Type type)
public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, string name, Type type, Func<IServiceProvider, object> implementationFactory)
public static IServiceCollection AddNamedScoped<T>(this IServiceCollection serviceCollection, string name) where T : class
public static IServiceCollection AddNamedScoped<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory) where T : class


/// Transient

public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, string name, Type type)
public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, string name, Type type, Func<IServiceProvider, object> implementationFactory)
public static IServiceCollection AddNamedTransient<T>(this IServiceCollection serviceCollection, string name) where T : class
public static IServiceCollection AddNamedTransient<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory) where T : class

```