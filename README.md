# NamedServices.Microsoft.Extensions.DependencyInjection

Allowes you to use Named Services with Microsoft Dependency Injection.  
Supports `string` or `enum` as key.

## Add Named Service to DI

There are a few ExtensionMethods for `IServiceCollection`, to add Named Services:

* AddNamed
* AddNamedSingleton
* AddNamedScoped
* AddNamedTransient

You can find the complete List of ExtensionMethods at the bottom of the README.

## Resolve Named Service from DI
  
There are a few ExtensionMethods for `IServiceProvider`, to resolve Named Services:

* GetNamedService
* GetRequiredNamedService

## Example

You can find to complete Example (an ASP.Net Core 3.0 Example) in the Folder `Examples`.

LiteDbRepoNames.cs
```csharp
public enum LiteDbRepoNames {
    Users,
    Clients
}
```

Startup.cs
```csharp
 public void ConfigureServices(IServiceCollection services) {

    ...

    services.AddNamedSingleton("users", sp => {
        var repo = new LiteRepository("Filename=users.db");
        repo.Database.Mapper.Entity<UserDbModel>().Id(model => model.Username, false);
        return repo;
    });

    services.AddNamedSingleton(LiteDbRepoNames.Clients, sp => {
        var repo = new LiteRepository("Filename=clients.db");
        repo.Database.Mapper.Entity<ClientDbModel>().Id(model => model.Name, false);
        return repo;
    });
    
    ...

}
```

TestController.cs
```csharp
[Route("api/test")]
public class TestController: Controller
{
    private LiteRepository UsersRepo { get; }
    private LiteRepository ClientsRepo { get; }

    public TestController(IServiceProvider serviceProvider) {
        UsersRepo = serviceProvider.GetRequiredNamedService<LiteRepository>("users");
        ClientsRepo = serviceProvider.GetRequiredNamedService<LiteRepository>(LiteDbRepoNames.Clients);
    }

    ...
}
```


### ExtensionMethods

```csharp
/// Singleton
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key);
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider,object> implementationFactory);
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key, Type implementationType);
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key, objectimplementationInstance);
AddNamedSingleton<TService>(this IServiceCollection serviceCollection, string key);
AddNamedSingleton<TService>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider,TService> implementationFactory);
AddNamedSingleton<TService>(this IServiceCollection serviceCollection, string key, TService implementationInstance);
AddNamedSingleton<TService, TImplementation>(this IServiceCollection serviceCollection, string key);
AddNamedSingleton<TService, TImplementation>(this IServiceCollection serviceCollection, string key,Func<IServiceProvider, TImplementation> implementationFactory);

AddNamedSingleton(this IServiceCollection serviceCollection, Type type, Enum key);
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider,object> implementationFactory);
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, Enum key, Type implementationType);
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, Enum key, objectimplementationInstance);
AddNamedSingleton<TService>(this IServiceCollection serviceCollection, Enum key);
AddNamedSingleton<TService>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider,TService> implementationFactory);
AddNamedSingleton<TService>(this IServiceCollection serviceCollection, Enum key, TService implementationInstance);
AddNamedSingleton<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key);
AddNamedSingleton<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key,Func<IServiceProvider, TImplementation> implementationFactory);


/// Scoped
AddNamedScoped(this IServiceCollection serviceCollection, Type type, string key);
AddNamedScoped(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory);
AddNamedScoped(this IServiceCollection serviceCollection, Type type, string key, Type implementationType);
AddNamedScoped<TService>(this IServiceCollection serviceCollection, string key);
AddNamedScoped<TService>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TService> implementationFactory);
AddNamedScoped<TService, TImplementation>(this IServiceCollection serviceCollection, string key);
AddNamedScoped<TService, TImplementation>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TImplementation> implementationFactory);

AddNamedScoped(this IServiceCollection serviceCollection, Type type, Enum key);
AddNamedScoped(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory);
AddNamedScoped(this IServiceCollection serviceCollection, Type type, Enum key, Type implementationType);
AddNamedScoped<TService>(this IServiceCollection serviceCollection, Enum key);
AddNamedScoped<TService>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TService> implementationFactory);
AddNamedScoped<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key);
AddNamedScoped<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TImplementation> implementationFactory);


/// Transient
AddNamedTransient(this IServiceCollection serviceCollection, Type type, string key);
AddNamedTransient(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory);
AddNamedTransient(this IServiceCollection serviceCollection, Type type, string key, Type implementationType);
AddNamedTransient<TService>(this IServiceCollection serviceCollection, string key);
AddNamedTransient<TService>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TService> implementationFactory);
AddNamedTransient<TService, TImplementation>(this IServiceCollection serviceCollection, string key);
AddNamedTransient<TService, TImplementation>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TImplementation> implementationFactory);

AddNamedTransient(this IServiceCollection serviceCollection, Type type, Enum key);
AddNamedTransient(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory);
AddNamedTransient(this IServiceCollection serviceCollection, Type type, Enum key, Type implementationType);
AddNamedTransient<TService>(this IServiceCollection serviceCollection, Enum key);
AddNamedTransient<TService>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TService> implementationFactory);
AddNamedTransient<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key);
AddNamedTransient<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TImplementation> implementationFactory);


///AddNamed
AddNamed(this IServiceCollection serviceCollection, Type type, string key, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, string key, Type implementationType, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, string key, object implementationInstance);
AddNamed<TService>(this IServiceCollection serviceCollection, string key, ServiceLifetime serviceLifetime);
AddNamed<TService>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TService> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed<TService>(this IServiceCollection serviceCollection, string key, TService implementationInstance);
AddNamed<TService, TImplementation>(this IServiceCollection serviceCollection, string key, ServiceLifetime serviceLifetime);
AddNamed<TService, TImplementation>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TImplementation> implementationFactory, ServiceLifetime serviceLifetime);

AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, Type implementationType, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, object implementationInstance);
AddNamed<TService>(this IServiceCollection serviceCollection, Enum key, ServiceLifetime serviceLifetime);
AddNamed<TService>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TService> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed<TService>(this IServiceCollection serviceCollection, Enum key, TService implementationInstance);
AddNamed<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key, ServiceLifetime serviceLifetime);
AddNamed<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TImplementation> implementationFactory, ServiceLifetime serviceLifetime);
```