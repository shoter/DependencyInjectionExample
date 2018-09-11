using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Die.Library.Processors;
using Die.Library.Services;

namespace Die.Library.Factories
{
    public class ProcessorFactory : IProcessorFactory
    {
        public IProcessor CreateProcessorNewWay(Type type)
        {
            return DependencyService.Resolve(type) as IProcessor;
        }

        public IProcessor CreateProcessorOldWay(Type type)
        {
            return Activator.CreateInstance(type) as IProcessor;
        }
    }
}
