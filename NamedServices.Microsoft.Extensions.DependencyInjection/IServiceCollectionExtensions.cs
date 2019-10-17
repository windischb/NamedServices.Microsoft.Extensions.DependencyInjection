using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NamedServices.Microsoft.Extensions.DependencyInjection {
    public static class IServiceCollectionExtensions {


        #region Singleton

        public static IServiceCollection AddNamedSingleton<T>(this IServiceCollection serviceCollection, string key) where T : class {
            return AddNamed<T>(serviceCollection, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory) where T : class {
            return AddNamed<T>(serviceCollection, key, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, string key, Type type) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, string key, Type type, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<T>(this IServiceCollection serviceCollection, Enum key) where T : class {
            return AddNamed<T>(serviceCollection, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory) where T : class {
            return AddNamed<T>(serviceCollection, key, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, Enum key, Type type) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, Enum key, Type type, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Singleton);
        }

        #endregion

        #region Scoped

        public static IServiceCollection AddNamedScoped<T>(this IServiceCollection serviceCollection, string key) where T : class {
            return AddNamed<T>(serviceCollection, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory) where T : class {
            return AddNamed<T>(serviceCollection, key, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, string key, Type type) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, string key, Type type, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<T>(this IServiceCollection serviceCollection, Enum key) where T : class {
            return AddNamed<T>(serviceCollection, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory) where T : class {
            return AddNamed<T>(serviceCollection, key, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, Enum key, Type type) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, Enum key, Type type, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Scoped);
        }

        #endregion

        #region Transient

        public static IServiceCollection AddNamedTransient<T>(this IServiceCollection serviceCollection, string key) where T : class {
            return AddNamed<T>(serviceCollection, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory) where T : class {
            return AddNamed<T>(serviceCollection, key, implementationFactory, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, string key, Type type) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, string key, Type type, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<T>(this IServiceCollection serviceCollection, Enum key) where T : class {
            return AddNamed<T>(serviceCollection, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory) where T : class {
            return AddNamed<T>(serviceCollection, key, implementationFactory, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, Enum key, Type type) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, Enum key, Type type, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Transient);
        }

        #endregion


        #region Add

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string key, ServiceLifetime serviceLifetime) {

            serviceCollection.TryAddSingleton<NamedServiceResolver>();

            var namedService = NamedService.GenerateNamedServiceType(key, type);
            serviceCollection.Add(new ServiceDescriptor(namedService, namedService, serviceLifetime));
            return serviceCollection;

        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime) {

            serviceCollection.TryAddSingleton<NamedServiceResolver>();

            var namedService = NamedService.GenerateNamedServiceType(key, type);
            serviceCollection.Add(new ServiceDescriptor(namedService, provider => Activator.CreateInstance(namedService, implementationFactory(provider)), serviceLifetime));
            return serviceCollection;

        }

        public static IServiceCollection AddNamed<T>(this IServiceCollection serviceCollection, string key, ServiceLifetime serviceLifetime) {

            serviceCollection.TryAddSingleton<NamedServiceResolver>();

            var namedService = NamedService.GenerateNamedServiceType<T>(key);
            serviceCollection.Add(new ServiceDescriptor(namedService, namedService, serviceLifetime));
            return serviceCollection;

        }

        public static IServiceCollection AddNamed<T>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, T> implementationFactory, ServiceLifetime serviceLifetime) {

            serviceCollection.TryAddSingleton<NamedServiceResolver>();

            var namedService = NamedService.GenerateNamedServiceType<T>(key);
            serviceCollection.Add(new ServiceDescriptor(namedService, provider => Activator.CreateInstance(namedService, implementationFactory(provider)), serviceLifetime));
            return serviceCollection;

        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, ServiceLifetime serviceLifetime) {

            serviceCollection.TryAddSingleton<NamedServiceResolver>();

            var namedService = NamedService.GenerateNamedServiceType(key, type);
            serviceCollection.Add(new ServiceDescriptor(namedService, namedService, serviceLifetime));
            return serviceCollection;

        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime) {

            serviceCollection.TryAddSingleton<NamedServiceResolver>();

            var namedService = NamedService.GenerateNamedServiceType(key, type);
            serviceCollection.Add(new ServiceDescriptor(namedService, provider => Activator.CreateInstance(namedService, implementationFactory(provider)), serviceLifetime));
            return serviceCollection;

        }

        public static IServiceCollection AddNamed<T>(this IServiceCollection serviceCollection, Enum key, ServiceLifetime serviceLifetime) {

            serviceCollection.TryAddSingleton<NamedServiceResolver>();

            var namedService = NamedService.GenerateNamedServiceType<T>(key);
            serviceCollection.Add(new ServiceDescriptor(namedService, namedService, serviceLifetime));
            return serviceCollection;

        }

        public static IServiceCollection AddNamed<T>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, T> implementationFactory, ServiceLifetime serviceLifetime) {

            serviceCollection.TryAddSingleton<NamedServiceResolver>();

            var namedService = NamedService.GenerateNamedServiceType<T>(key);
            serviceCollection.Add(new ServiceDescriptor(namedService, provider => Activator.CreateInstance(namedService, implementationFactory(provider)), serviceLifetime));
            return serviceCollection;

        }

        #endregion

    }
}
