using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Die.Library.Services
{
    public class SomeService : ISomeService
    {
        public int AddNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        public void DoImportantJob(int number)
        {
            //doing something
            Thread.Sleep(100);
        }
    }
}
