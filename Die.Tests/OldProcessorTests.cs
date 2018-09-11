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
    public class OldProcessorTests
    {
        Mock<ISomeService> someService = new Mock<ISomeService>();
        IProcessor processor = new OldProcessor();
    
        public OldProcessorTests()
        {
            DependencyService.GetConfiguredContainer().RegisterInstance(someService.Object);
        }

        [TestMethod]
        public void OldProcessor_Run_NormalExecution_IsRunWithNumbersFromService()
        {
            int someNumber = 123456;
            someService.Setup(x => x.AddNumbers(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(someNumber);

            this.processor.Run();

            someService.Verify(x => x.DoImportantJob(someNumber), Times.Once);
        }
    }
}
