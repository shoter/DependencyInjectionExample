using Die.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die.Library.Processors
{
    public class OldProcessor : IProcessor
    {
        public void Run()
        {
            ISomeService service = DependencyService.Resolve<ISomeService>();

            int number = service.AddNumbers(1, 2);
            service.DoImportantJob(number);
        }
    }
}
