using System;
using Microsoft.Extensions.DependencyInjection;
using NamedServices.Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace NamedServices.Tests {

    
    public class AddEnumNamedNonGenericTests {

        private readonly IServiceProvider _serviceProvider;

        public AddEnumNamedNonGenericTests() {
            var serviceCollection = new ServiceCollection();
            _serviceProvider = serviceCollection

                // Add by Type
                .AddNamed(typeof(TestService), AddEnumNamedNonGenericKey.ByType, ServiceLifetime.Singleton)
                .AddNamed(typeof(TestService2), AddEnumNamedNonGenericKey.ByType, ServiceLifetime.Singleton)

                // Add by ImplementationFactory
                .AddNamed(typeof(TestService), AddEnumNamedNonGenericKey.ByFactory11, sp => new TestService("ByFactory11"), ServiceLifetime.Singleton)
                .AddNamed(typeof(TestService), AddEnumNamedNonGenericKey.ByFactory12, sp => new TestService("ByFactory12"), ServiceLifetime.Singleton)
                .AddNamed(typeof(TestService2), AddEnumNamedNonGenericKey.ByFactory21, sp => new TestService2("ByFactory21"), ServiceLifetime.Singleton)
                .AddNamed(typeof(TestService2), AddEnumNamedNonGenericKey.ByFactory22, sp => new TestService2("ByFactory22"), ServiceLifetime.Singleton)

                // Add by ImplementationType
                .AddNamed(typeof(ITestService), AddEnumNamedNonGenericKey.ByImplementationType1, typeof(TestService), ServiceLifetime.Singleton)
                .AddNamed(typeof(ITestService), AddEnumNamedNonGenericKey.ByImplementationType2, typeof(TestService2), ServiceLifetime.Singleton)

                // Add by Instance
                .AddNamed(typeof(TestService), AddEnumNamedNonGenericKey.NamedInstance1, new TestService("NamedInstance1"))
                .AddNamed(typeof(TestService), AddEnumNamedNonGenericKey.NamedInstance2, new TestService("NamedInstance2"))
                .AddNamed(typeof(ITestService), AddEnumNamedNonGenericKey.NamedInstance3, new TestService("NamedInstance3"))
                .AddNamed(typeof(ITestService), AddEnumNamedNonGenericKey.NamedInstance4, new TestService("NamedInstance4"))

                .BuildServiceProvider();
        }

        [Theory]
        [InlineData(typeof(TestService))]
        [InlineData(typeof(TestService2))]
        public void AddNamedByType(Type type) {


            var inst = _serviceProvider.GetNamedService(type, AddEnumNamedNonGenericKey.ByType);

            Assert.NotNull(inst);
            Assert.Equal(type.Name, inst.GetType().Name);

        }

        [Theory]
        [InlineData(AddEnumNamedNonGenericKey.ByFactory11, typeof(TestService))]
        [InlineData(AddEnumNamedNonGenericKey.ByFactory12, typeof(TestService))]
        [InlineData(AddEnumNamedNonGenericKey.ByFactory21, typeof(TestService2))]
        [InlineData(AddEnumNamedNonGenericKey.ByFactory22, typeof(TestService2))]
        public void AddNamedByImplementationFactory(AddEnumNamedNonGenericKey name, Type type) {


            var inst = _serviceProvider.GetNamedService(type, name);

            Assert.NotNull(inst);
            Assert.Equal(type.Name, inst.GetType().Name);
            Assert.Equal(name.ToString("F"), inst.GetType().GetProperty("Name")?.GetValue(inst));

        }


        [Theory]
        [InlineData(AddEnumNamedNonGenericKey.ByImplementationType1, typeof(TestService))]
        [InlineData(AddEnumNamedNonGenericKey.ByImplementationType2, typeof(TestService2))]
        public void AddNamedByImplementationType(AddEnumNamedNonGenericKey name, Type type) {


            var inst = _serviceProvider.GetNamedService(typeof(ITestService), name);

            Assert.NotNull(inst);
            Assert.Equal(type, inst.GetType());

        }



        [Theory]
        [InlineData(AddEnumNamedNonGenericKey.NamedInstance1, typeof(TestService))]
        [InlineData(AddEnumNamedNonGenericKey.NamedInstance2, typeof(TestService))]
        [InlineData(AddEnumNamedNonGenericKey.NamedInstance3, typeof(ITestService))]
        [InlineData(AddEnumNamedNonGenericKey.NamedInstance4, typeof(ITestService))]
        public void AddNamedInstance(AddEnumNamedNonGenericKey name, Type type) {


            var inst = _serviceProvider.GetNamedService(type, name);

            Assert.NotNull(inst);
            Assert.Equal(name.ToString("F"), inst.GetType().GetProperty("Name")?.GetValue(inst));

        }
    }

    public enum AddEnumNamedNonGenericKey {
        ByType,
        ByFactory11,
        ByFactory12,
        ByFactory21,
        ByFactory22,
        ByImplementationType1,
        ByImplementationType2,
        NamedInstance1,
        NamedInstance2,
        NamedInstance3,
        NamedInstance4
    }
}
