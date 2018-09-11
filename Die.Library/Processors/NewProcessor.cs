using Die.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die.Library.Processors
{
    public class NewProcessor : IProcessor
    {
        private readonly ISomeService service;
        public NewProcessor(ISomeService service)
        {
            this.service = service;
        }
        public void Run()
        {
            int number = service.AddNumbers(1, 2);
            service.DoImportantJob(number);
        }
    }
}
