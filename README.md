# NamedServices.Microsoft.Extensions.DependencyInjection

Allowes you to use Named Services with Microsoft Dependency Injection.
Supports `string` or `enum` as key.

## Add Named Service to DI

```csharp
AddNamed(this IServiceCollection serviceCollection, Type type, string key, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, string key, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, ServiceLifetime serviceLifetime);
AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, Enum key, ServiceLifetime serviceLifetime);
AddNamed<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory, ServiceLifetime serviceLifetime);


/// Singleton

AddNamedSingleton(this IServiceCollection serviceCollection, string key, Type type);
AddNamedSingleton(this IServiceCollection serviceCollection, string key, Type type, Func<IServiceProvider, object> implementationFactory);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, string key);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory);
AddNamedSingleton(this IServiceCollection serviceCollection, Enum key, Type type);
AddNamedSingleton(this IServiceCollection serviceCollection, Enum key, Type type, Func<IServiceProvider, object> implementationFactory);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, Enum key);
AddNamedSingleton<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory);


/// Scoped

AddNamedScoped(this IServiceCollection serviceCollection, string key, Type type);
AddNamedScoped(this IServiceCollection serviceCollection, string key, Type type, Func<IServiceProvider, object> implementationFactory);
AddNamedScoped<T>(this IServiceCollection serviceCollection, string key);
AddNamedScoped<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory);
AddNamedScoped(this IServiceCollection serviceCollection, Enum key, Type type);
AddNamedScoped(this IServiceCollection serviceCollection, Enum key, Type type, Func<IServiceProvider, object> implementationFactory);
AddNamedScoped<T>(this IServiceCollection serviceCollection, Enum key);
AddNamedScoped<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory);


/// Transient

AddNamedTransient(this IServiceCollection serviceCollection, string key, Type type);
AddNamedTransient(this IServiceCollection serviceCollection, string key, Type type, Func<IServiceProvider, object> implementationFactory);
AddNamedTransient<T>(this IServiceCollection serviceCollection, string key);
AddNamedTransient<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory);
AddNamedTransient(this IServiceCollection serviceCollection, Enum key, Type type);
AddNamedTransient(this IServiceCollection serviceCollection, Enum key, Type type, Func<IServiceProvider, object> implementationFactory);
AddNamedTransient<T>(this IServiceCollection serviceCollection, Enum key);
AddNamedTransient<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory);

```
  


## Resolve Named Service from DI
  
To Resolve your Named Service from DI you can use `NamedServiceResolver`  
`NamedServiceResolver` is injected automatically to use it for Constructor Injection.  


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
        UsersRepo = namedServiceResolver.GetNamedService<LiteRepository>("users");
        ClientsRepo = namedServiceResolver.GetNamedService<LiteRepository>(LiteDbRepoNames.Clients);
    }

    ...
}

```