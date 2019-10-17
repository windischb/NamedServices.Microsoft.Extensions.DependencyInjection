using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NamedServices.Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {


        #region Singleton
        public static IServiceCollection AddNamedSingleton<T>(this IServiceCollection serviceCollection, string name) where T : class
        {
            return AddNamed<T>(serviceCollection, name, ServiceLifetime.Singleton);
        }


        public static IServiceCollection AddNamedSingleton<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory) where T : class
        {
            return AddNamed<T>(serviceCollection, name, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, string name, Type type)
        {
            return AddNamed(serviceCollection, type, name, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, string name, Type type, Func<IServiceProvider, object> implementationFactory)
        {
            return AddNamed(serviceCollection, type, name, implementationFactory, ServiceLifetime.Singleton);
        }


        #endregion

        #region Scoped
        public static IServiceCollection AddNamedScoped<T>(this IServiceCollection serviceCollection, string name) where T : class
        {
            return AddNamed<T>(serviceCollection, name, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory) where T : class
        {
            return AddNamed<T>(serviceCollection, name, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, string name, Type type)
        {
            return AddNamed(serviceCollection, type, name, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, string name, Type type, Func<IServiceProvider, object> implementationFactory)
        {
            return AddNamed(serviceCollection, type, name, implementationFactory, ServiceLifetime.Scoped);
        }
        #endregion

        #region Transient
        public static IServiceCollection AddNamedTransient<T>(this IServiceCollection serviceCollection, string name) where T : class
        {
            return AddNamed<T>(serviceCollection, name, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory) where T : class
        {
            return AddNamed<T>(serviceCollection, name, implementationFactory, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, string name, Type type)
        {
            return AddNamed(serviceCollection, type, name, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, string name, Type type, Func<IServiceProvider, object> implementationFactory)
        {
            return AddNamed(serviceCollection, type, name, implementationFactory, ServiceLifetime.Transient);
        }
        #endregion


        #region AddNamed
        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string name, ServiceLifetime serviceLifetime)
        {

            serviceCollection.TryAddSingleton<NamedTypeResolver>();

            var namedService = NamedService.GenerateNamedServiceType(name, type);
            serviceCollection.Add(new ServiceDescriptor(namedService, namedService, serviceLifetime));
            return serviceCollection;
        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string name, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime)
        {

            serviceCollection.TryAddSingleton<NamedTypeResolver>();

            var namedService = NamedService.GenerateNamedServiceType(name, type);
            serviceCollection.Add(new ServiceDescriptor(namedService, provider => Activator.CreateInstance(namedService, implementationFactory(provider)), serviceLifetime));
            return serviceCollection;
        }

        public static IServiceCollection AddNamed<T>(this IServiceCollection serviceCollection, string name, ServiceLifetime serviceLifetime)
        {

            serviceCollection.TryAddSingleton<NamedTypeResolver>();

            var namedService = NamedService.GenerateNamedServiceType<T>(name);
            serviceCollection.Add(new ServiceDescriptor(namedService, namedService, serviceLifetime));
            return serviceCollection;
        }

        public static IServiceCollection AddNamed<T>(this IServiceCollection serviceCollection, string name, Func<IServiceProvider, T> implementationFactory, ServiceLifetime serviceLifetime)
        {

            serviceCollection.TryAddSingleton<NamedTypeResolver>();

            var namedService = NamedService.GenerateNamedServiceType<T>(name);
            serviceCollection.Add(new ServiceDescriptor(namedService, provider => Activator.CreateInstance(namedService, implementationFactory(provider)), serviceLifetime));
            return serviceCollection;
        }
        #endregion

    }
}
