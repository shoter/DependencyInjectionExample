using Die.Library.Processors;
using Die.Library.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die.Tests
{
    [TestClass]
    public class NewProcessorTests
    {
        Mock<ISomeService> someService = new Mock<ISomeService>();
        IProcessor processor;

        public NewProcessorTests()
        {
            this.processor = new NewProcessor(someService.Object);
        }

        [TestMethod]
        public void NewProcessor_Run_NormalExecution_IsRunWithNumbersFromSomeService()
        {
            int someNumber = 123456;
            someService.Setup(x => x.AddNumbers(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(someNumber);

            this.processor.Run();

            someService.Verify(x => x.DoImportantJob(someNumber), Times.Once);
        }
        
    }
}
