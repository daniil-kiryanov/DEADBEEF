using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEADBEEF
{
    internal class XlsxWorker : AbstractWorker

    {
        protected override void ProcessFile(string name)
        {
            Console.WriteLine($"XlsxFile: {name}");// TODO;
        }
    }
}
