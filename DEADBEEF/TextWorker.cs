using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEADBEEF
{
    internal class TextWorker : AbstractWorker
    {
        protected override void ProcessFile(string name)
        {
            Console.WriteLine($"TextFile: {name}");// TODO;
        }
    }
}
