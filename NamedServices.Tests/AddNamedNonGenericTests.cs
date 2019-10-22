using System;
using Microsoft.Extensions.DependencyInjection;
using NamedServices.Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace NamedServices.Tests {
    public class AddNamedNonGenericTests {

        private readonly IServiceProvider _serviceProvider;

        public AddNamedNonGenericTests() {
            var serviceCollection = new ServiceCollection();
            _serviceProvider = serviceCollection

                // Add by Type
                .AddNamed(typeof(TestService), "ByType", ServiceLifetime.Singleton)
                .AddNamed(typeof(TestService2), "ByType", ServiceLifetime.Singleton)

                // Add by ImplementationFactory
                .AddNamed(typeof(TestService), "ByFactory11", sp => new TestService("ByFactory11"), ServiceLifetime.Singleton)
                .AddNamed(typeof(TestService), "ByFactory12", sp => new TestService("ByFactory12"), ServiceLifetime.Singleton)
                .AddNamed(typeof(TestService2), "ByFactory21", sp => new TestService2("ByFactory21"), ServiceLifetime.Singleton)
                .AddNamed(typeof(TestService2), "ByFactory22", sp => new TestService2("ByFactory22"), ServiceLifetime.Singleton)

                // Add by ImplementationType
                .AddNamed(typeof(ITestService), "ByImplementationType1", typeof(TestService), ServiceLifetime.Singleton)
                .AddNamed(typeof(ITestService), "ByImplementationType2", typeof(TestService2), ServiceLifetime.Singleton)

                // Add by Instance
                .AddNamed(typeof(TestService), "NamedInstance1", new TestService("NamedInstance1"))
                .AddNamed(typeof(TestService), "NamedInstance2", new TestService("NamedInstance2"))
                .AddNamed(typeof(ITestService), "NamedInstance3", new TestService("NamedInstance3"))
                .AddNamed(typeof(ITestService), "NamedInstance4", new TestService("NamedInstance4"))

                .BuildServiceProvider();
        }

        [Theory]
        [InlineData(typeof(TestService))]
        [InlineData(typeof(TestService2))]
        public void AddNamedByType(Type type) {


            var inst = _serviceProvider.GetNamedService(type, "ByType");

            Assert.NotNull(inst);
            Assert.Equal(type.Name, inst.GetType().Name);

        }

        [Theory]
        [InlineData("ByFactory11", typeof(TestService))]
        [InlineData("ByFactory12", typeof(TestService))]
        [InlineData("ByFactory21", typeof(TestService2))]
        [InlineData("ByFactory22", typeof(TestService2))]
        public void AddNamedByImplementationFactory(string name, Type type) {


            var inst = _serviceProvider.GetNamedService(type, name);

            Assert.NotNull(inst);
            Assert.Equal(type.Name, inst.GetType().Name);
            Assert.Equal(name, inst.GetType().GetProperty("Name")?.GetValue(inst));

        }


        [Theory]
        [InlineData("ByImplementationType1", typeof(TestService))]
        [InlineData("ByImplementationType2", typeof(TestService2))]
        public void AddNamedByImplementationType(string name, Type type) {


            var inst = _serviceProvider.GetNamedService(typeof(ITestService), name);

            Assert.NotNull(inst);
            Assert.Equal(type, inst.GetType());

        }



        [Theory]
        [InlineData("NamedInstance1", typeof(TestService))]
        [InlineData("NamedInstance2", typeof(TestService))]
        [InlineData("NamedInstance3", typeof(ITestService))]
        [InlineData("NamedInstance4", typeof(ITestService))]
        public void AddNamedInstance(string name, Type type) {


            var inst = _serviceProvider.GetNamedService(type, name);

            Assert.NotNull(inst);
            Assert.Equal(name, inst.GetType().GetProperty("Name")?.GetValue(inst));

        }
    }
}
