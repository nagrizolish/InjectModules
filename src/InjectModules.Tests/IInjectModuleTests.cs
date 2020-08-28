using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using InjectModules.Extensions;
using SampleLib;
using Xunit;

namespace InjectModules.Tests
{
    public class IInjectModuleTests
    {
        [Fact]
        public void RegisterModuleGeneric_InternalModule_Success()
        {
            var services = new ServiceCollection();

            services.RegisterModule<TestInjectModuleInternal>();

            Assert.Contains(services, descriptor => descriptor.ServiceType == (typeof(ITestService<int>)));
        }

        [Fact]
        public void RegisterModule_InternalModule_Success()
        {
            var services = new ServiceCollection();

            services.RegisterModule(typeof(TestInjectModuleInternal));

            Assert.Contains(services, descriptor => descriptor.ServiceType == (typeof(ITestService<int>)));
        }

        [Fact]
        public void RegisterModule_InternalModule_ArgumentException()
        {
            var services = new ServiceCollection();

            Assert.Throws<ArgumentException>(() => services.RegisterModule(typeof(FakeTestModule)));
        }

        [Fact]
        public void RegisterModule_ExternalModule_Success()
        {
            var services = new ServiceCollection();

            services.RegisterModules(assemblyMarkerType: typeof(TestService<>));

            Assert.Contains(services, descriptor => descriptor.ServiceType == (typeof(ITestService<string>)));
            Assert.Contains(services, descriptor => descriptor.ServiceType == (typeof(ITestService<DateTime>)));
        }
    }
}
