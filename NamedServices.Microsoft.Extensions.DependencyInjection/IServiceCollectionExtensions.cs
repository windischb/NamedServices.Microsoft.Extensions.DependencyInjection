using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NamedServices.Microsoft.Extensions.DependencyInjection {
    public static class IServiceCollectionExtensions {


        #region Singleton

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key, Type implementationType) {
            return AddNamed(serviceCollection, type, key, implementationType, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, Type type, string key, object implementationInstance) {
            return AddNamed(serviceCollection, type, key, implementationInstance);
        }

        public static IServiceCollection AddNamedSingleton<TService>(this IServiceCollection serviceCollection, string key) where TService : class {
            return AddNamed<TService>(serviceCollection, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<TService>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TService> implementationFactory) where TService : class {
            return AddNamed<TService>(serviceCollection, key, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<TService>(this IServiceCollection serviceCollection, string key, TService implementationInstance) where TService : class {
            return AddNamed<TService>(serviceCollection, key, implementationInstance);
        }

        public static IServiceCollection AddNamedSingleton<TService, TImplementation>(this IServiceCollection serviceCollection, string key) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<TService, TImplementation>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, implementationFactory, ServiceLifetime.Singleton);
        }



        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, Type type, Enum key) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton(this IServiceCollection serviceCollection, Type type, Enum key, Type implementationType) {
            return AddNamed(serviceCollection, type, key, implementationType, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<TService>(this IServiceCollection serviceCollection, Enum key) where TService : class {
            return AddNamed<TService>(serviceCollection, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<TService>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TService> implementationFactory) where TService : class {
            return AddNamed<TService>(serviceCollection, key, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddNamedSingleton<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, implementationFactory, ServiceLifetime.Singleton);
        }

        #endregion

        #region Scoped

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, Type type, string key) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, Type type, string key, Type implementationType) {
            return AddNamed(serviceCollection, type, key, implementationType, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<TService>(this IServiceCollection serviceCollection, string key) where TService : class {
            return AddNamed<TService>(serviceCollection, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<TService>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TService> implementationFactory) where TService : class {
            return AddNamed<TService>(serviceCollection, key, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<TService, TImplementation>(this IServiceCollection serviceCollection, string key) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<TService, TImplementation>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, implementationFactory, ServiceLifetime.Scoped);
        }



        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, Type type, Enum key) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped(this IServiceCollection serviceCollection, Type type, Enum key, Type implementationType) {
            return AddNamed(serviceCollection, type, key, implementationType, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<TService>(this IServiceCollection serviceCollection, Enum key) where TService : class {
            return AddNamed<TService>(serviceCollection, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<TService>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TService> implementationFactory) where TService : class {
            return AddNamed<TService>(serviceCollection, key, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddNamedScoped<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, implementationFactory, ServiceLifetime.Scoped);
        }


        #endregion

        #region Transient

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, Type type, string key) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, Type type, string key, Type implementationType) {
            return AddNamed(serviceCollection, type, key, implementationType, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<TService>(this IServiceCollection serviceCollection, string key) where TService : class {
            return AddNamed<TService>(serviceCollection, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<TService>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TService> implementationFactory) where TService : class {
            return AddNamed<TService>(serviceCollection, key, implementationFactory, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<TService, TImplementation>(this IServiceCollection serviceCollection, string key) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<TService, TImplementation>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, implementationFactory, ServiceLifetime.Transient);
        }



        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, Type type, Enum key) {
            return AddNamed(serviceCollection, type, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory) {
            return AddNamed(serviceCollection, type, key, implementationFactory, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient(this IServiceCollection serviceCollection, Type type, Enum key, Type implementationType) {
            return AddNamed(serviceCollection, type, key, implementationType, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<TService>(this IServiceCollection serviceCollection, Enum key) where TService : class {
            return AddNamed<TService>(serviceCollection, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<TService>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TService> implementationFactory) where TService : class {
            return AddNamed<TService>(serviceCollection, key, implementationFactory, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamedTransient<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService {
            return AddNamed<TService, TImplementation>(serviceCollection, key, implementationFactory, ServiceLifetime.Transient);
        }

        #endregion


        #region Add

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string key, ServiceLifetime serviceLifetime) {

            return AddNamed(serviceCollection, type, key, provider => ActivatorUtilities.CreateInstance(provider, type),
                serviceLifetime);
        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime) {

            var namedService = NamedServiceHelper.GenerateNamedServiceType(key, type);
            serviceCollection.Add(new ServiceDescriptor(namedService, provider => Activator.CreateInstance(namedService, implementationFactory(provider)), serviceLifetime));

            return serviceCollection;

        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string key, Type implementationType, ServiceLifetime serviceLifetime) {

            return AddNamed(serviceCollection, type, key, provider => ActivatorUtilities.CreateInstance(provider, implementationType),
                serviceLifetime);

        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, string key, object implementationInstance) {

            var namedService = NamedServiceHelper.GenerateNamedServiceType(key, type);
            var namedImplementationInstance = Activator.CreateInstance(namedService, implementationInstance);
            serviceCollection.Add(new ServiceDescriptor(namedService, namedImplementationInstance));

            return serviceCollection;

        }

        public static IServiceCollection AddNamed<TService>(this IServiceCollection serviceCollection, string key, ServiceLifetime serviceLifetime) where TService : class {

            return AddNamed(serviceCollection, typeof(TService), key, serviceLifetime);

        }

        public static IServiceCollection AddNamed<TService>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TService> implementationFactory, ServiceLifetime serviceLifetime) where TService : class {

            return AddNamed(serviceCollection, typeof(TService), key, implementationFactory, serviceLifetime);

        }

        public static IServiceCollection AddNamed<TService>(this IServiceCollection serviceCollection, string key, TService implementationInstance) where TService : class {
            return AddNamed(serviceCollection, typeof(TService), key, implementationInstance);
        }

        public static IServiceCollection AddNamed<TService, TImplementation>(this IServiceCollection serviceCollection, string key, ServiceLifetime serviceLifetime) where TService : class where TImplementation : class, TService {

            return AddNamed(serviceCollection, typeof(TService), key, typeof(TImplementation), serviceLifetime);

        }

        public static IServiceCollection AddNamed<TService, TImplementation>(this IServiceCollection serviceCollection, string key, Func<IServiceProvider, TImplementation> implementationFactory, ServiceLifetime serviceLifetime) where TService : class where TImplementation : class, TService {

            return AddNamed(serviceCollection, typeof(TService), key, implementationFactory, serviceLifetime);

        }



        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, ServiceLifetime serviceLifetime) {

            return AddNamed(serviceCollection, type, key, provider => ActivatorUtilities.CreateInstance(provider, type),
                serviceLifetime);
        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, Func<IServiceProvider, object> implementationFactory, ServiceLifetime serviceLifetime) {

            var namedService = NamedServiceHelper.GenerateNamedServiceType(key, type);
            serviceCollection.Add(new ServiceDescriptor(namedService, provider => Activator.CreateInstance(namedService, implementationFactory(provider)), serviceLifetime));

            return serviceCollection;

        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, Type implementationType, ServiceLifetime serviceLifetime) {

            return AddNamed(serviceCollection, type, key, provider => ActivatorUtilities.CreateInstance(provider, implementationType),
                serviceLifetime);

        }

        public static IServiceCollection AddNamed(this IServiceCollection serviceCollection, Type type, Enum key, object implementationInstance) {

            var namedService = NamedServiceHelper.GenerateNamedServiceType(key, type);
            var namedImplementationInstance = Activator.CreateInstance(namedService, implementationInstance);
            serviceCollection.Add(new ServiceDescriptor(namedService, namedImplementationInstance));

            return serviceCollection;

        }

        public static IServiceCollection AddNamed<TService>(this IServiceCollection serviceCollection, Enum key, ServiceLifetime serviceLifetime) where TService : class {

            return AddNamed(serviceCollection, typeof(TService), key, serviceLifetime);

        }

        public static IServiceCollection AddNamed<TService>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TService> implementationFactory, ServiceLifetime serviceLifetime) where TService : class {

            return AddNamed(serviceCollection, typeof(TService), key, implementationFactory, serviceLifetime);

        }

        public static IServiceCollection AddNamed<TService>(this IServiceCollection serviceCollection, Enum key, TService implementationInstance) where TService : class {
            return AddNamed(serviceCollection, typeof(TService), key, implementationInstance);
        }

        public static IServiceCollection AddNamed<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key, ServiceLifetime serviceLifetime) where TService : class where TImplementation : class, TService {

            return AddNamed(serviceCollection, typeof(TService), key, typeof(TImplementation), serviceLifetime);

        }

        public static IServiceCollection AddNamed<TService, TImplementation>(this IServiceCollection serviceCollection, Enum key, Func<IServiceProvider, TImplementation> implementationFactory, ServiceLifetime serviceLifetime) where TService : class where TImplementation : class, TService {

            return AddNamed(serviceCollection, typeof(TService), key, implementationFactory, serviceLifetime);

        }

        #endregion

    }
}
