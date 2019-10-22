using System;
using Microsoft.Extensions.DependencyInjection;
using NamedServices.Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace NamedServices.Tests {
    public class AddNamedGenericTests {

        private readonly IServiceProvider _serviceProvider;

        public AddNamedGenericTests() {
            var serviceCollection = new ServiceCollection();
            _serviceProvider = serviceCollection

                // Add by Type
                .AddNamed<TestService>("ByType", ServiceLifetime.Singleton)
                .AddNamed<TestService>("ByType2", ServiceLifetime.Singleton)
                .AddNamed<TestService2>("ByType", ServiceLifetime.Singleton)
                .AddNamed<TestService2>("ByType2", ServiceLifetime.Singleton)

                // Add by Factory
                .AddNamed<TestService>("ByFactory11", sp => new TestService("ByFactory11"), ServiceLifetime.Singleton)
                .AddNamed<TestService>("ByFactory12", sp => new TestService("ByFactory12"), ServiceLifetime.Singleton)
                .AddNamed<TestService2>("ByFactory21", sp => new TestService2("ByFactory21"), ServiceLifetime.Singleton)
                .AddNamed<TestService2>("ByFactory22", sp => new TestService2("ByFactory22"), ServiceLifetime.Singleton)

                // Add by Instance
                .AddNamed<TestService>("NamedInstance1", new TestService("NamedInstance1"))
                .AddNamed<TestService>("NamedInstance2", new TestService("NamedInstance2"))
                .AddNamed<ITestService>("NamedInstance3", new TestService("NamedInstance3"))
                .AddNamed<ITestService>("NamedInstance4", new TestService2("NamedInstance4"))

                // Add by Type As Interface
                .AddNamed<ITestService, TestService>("ByTypeAsInterface1", ServiceLifetime.Singleton)
                .AddNamed<ITestService, TestService2>("ByTypeAsInterface2", ServiceLifetime.Singleton)


                // Add by Factory As Interface
                .AddNamed<ITestService>("ByFactoryAsInterface11", sp => new TestService("ByFactoryAsInterface11"), ServiceLifetime.Singleton)
                .AddNamed<ITestService>("ByFactoryAsInterface12", sp => new TestService("ByFactoryAsInterface12"), ServiceLifetime.Singleton)
                .AddNamed<ITestService>("ByFactoryAsInterface21", sp => new TestService2("ByFactoryAsInterface21"), ServiceLifetime.Singleton)
                .AddNamed<ITestService>("ByFactoryAsInterface22", sp => new TestService2("ByFactoryAsInterface22"), ServiceLifetime.Singleton)


                .BuildServiceProvider();
        }


        [Theory]
        [InlineData("ByType", typeof(TestService))]
        [InlineData("ByType2", typeof(TestService))]
        [InlineData("ByType", typeof(TestService2))]
        [InlineData("ByType2", typeof(TestService2))]
        public void AddNamedByType(string name, Type type) {


            var inst = _serviceProvider.GetNamedService(type, name);

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
        [InlineData("NamedInstance1", typeof(TestService))]
        [InlineData("NamedInstance2", typeof(TestService))]
        [InlineData("NamedInstance3", typeof(ITestService))]
        [InlineData("NamedInstance4", typeof(ITestService))]
        public void AddNamedInstance(string name, Type type) {


            var inst = _serviceProvider.GetNamedService(type, name);

            Assert.NotNull(inst);
            Assert.Equal(name, inst.GetType().GetProperty("Name")?.GetValue(inst));

        }


        [Theory]
        [InlineData("ByTypeAsInterface1", typeof(TestService))]
        [InlineData("ByTypeAsInterface2", typeof(TestService2))]
        public void AddNamedByImplementationType(string name, Type type) {


            var inst = _serviceProvider.GetNamedService(typeof(ITestService), name);

            Assert.NotNull(inst);
            Assert.Equal(type, inst.GetType());

        }


        [Theory]
        [InlineData("ByFactoryAsInterface11", typeof(TestService))]
        [InlineData("ByFactoryAsInterface12", typeof(TestService))]
        [InlineData("ByFactoryAsInterface21", typeof(TestService2))]
        [InlineData("ByFactoryAsInterface22", typeof(TestService2))]
        public void AddNamedByFactoryAsImplementationFactory(string name, Type type) {


            var inst = _serviceProvider.GetNamedService(typeof(ITestService), name);

            Assert.NotNull(inst);
            Assert.Equal(type.Name, inst.GetType().Name);
            Assert.Equal(name, inst.GetType().GetProperty("Name")?.GetValue(inst));

        }


    }
}
