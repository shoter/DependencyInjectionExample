using Die.Library.Factories;
using Die.Library.Processors;
using Die.Library.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
namespace Die.Tests
{
    [TestClass]
    public class ProcessorFactoryTests
    {
        IProcessorFactory processorFactory = new ProcessorFactory();

        public ProcessorFactoryTests()
        {

        }

        [TestMethod]
        public void ProcessorFactory_CreateProcessorOldWay_CreatesGoodProcessor()
        {
            var processor = processorFactory.CreateProcessorOldWay(typeof(OldProcessor));

            Assert.IsTrue(processor is OldProcessor);
        }

        [TestMethod]
        public void ProcessorFactory_CreateProcessorNewWay_CreatesGoodProcessor()
        {
            Mock<IProcessor> mock = new Mock<IProcessor>();
            DependencyService.GetConfiguredContainer().RegisterInstance(mock.Object);

            var processor = processorFactory.CreateProcessorNewWay(typeof(IProcessor));

            Assert.IsTrue(processor == mock.Object);
        }

        [TestMethod]
        public void ProcessorFactory_CreateProcessorNewWay_IsNewProcessorProperlyConstructed()
        {
            Mock<ISomeService> mock = new Mock<ISomeService>();
            DependencyService.GetConfiguredContainer().RegisterInstance<ISomeService>(mock.Object);

            var processor = processorFactory.CreateProcessorNewWay(typeof(NewProcessor));

            processor.Run();
            mock.Verify(x => x.DoImportantJob(It.IsAny<int>()), Times.Once);
        }
    }
}
