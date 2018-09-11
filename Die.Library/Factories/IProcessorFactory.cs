using Die.Library.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die.Library.Factories
{
    public interface IProcessorFactory
    {
        IProcessor CreateProcessorOldWay(Type type);
        IProcessor CreateProcessorNewWay(Type type);
    }
}
