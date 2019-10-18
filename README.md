# NamedServices.Microsoft.Extensions.DependencyInjection

Allowes you to use Named Services with Microsoft Dependency Injection.  
Supports `string` or `enum` as key.

## Add Named Service to DI

There are a few ExtensionMethods for IServiceCollection, to add Named Services:

* AddNamed
* AddNamedSingleton
* AddNamedScoped
* AddNamedTransient

You can find the complete List of ExtensionMethods at the bottom of the README.

## Resolve Named Service from DI
  
To Resolve your Named Service you can use `NamedServiceResolver`  
`NamedServiceResolver` is injected automatically to use it for Constructor Injection.  

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

    public TestController(NamedServiceResolver namedServiceResolver) {
        UsersRepo = namedServiceResolver.GetRequiredNamedService<LiteRepository>("users");
        ClientsRepo = namedServiceResolver.GetRequiredNamedService<LiteRepository>(LiteDbRepoNames.Clients);
    }

    ...
}

```


### ExtensionMethods

```csharp
/// Singleton
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory);
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, string key);

AddNamedSingleton(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory);
AddNamedSingleton(this IServiceCollection serviceCollection, Type type, Enum key);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, Enum key);


/// Scoped
AddNamedScoped(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory);
AddNamedScoped<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory);
AddNamedScoped(this IServiceCollection serviceCollection, Type type, string key);
AddNamedScoped<T>(this IServiceCollection serviceCollection, string key);

AddNamedScoped(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory);
AddNamedScoped<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory);
AddNamedScoped(this IServiceCollection serviceCollection, Type type, Enum key);
AddNamedScoped<T>(this IServiceCollection serviceCollection, Enum key);


/// Transient
AddNamedTransient(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory);
AddNamedTransient<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory);
AddNamedTransient(this IServiceCollection serviceCollection, Type type, string key);
AddNamedTransient<T>(this IServiceCollection serviceCollection, string key);

AddNamedTransient(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory);
AddNamedTransient<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory);
AddNamedTransient(this IServiceCollection serviceCollection, Type type, Enum key);
AddNamedTransient<T>(this IServiceCollection serviceCollection, Enum key);


///AddNamed
AddNamed(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, string key, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, string key, ServiceLifetime serviceLifetime);

AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, Enum key, ServiceLifetime serviceLifetime);
```