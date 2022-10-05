// See https://aka.ms/new-console-template for more information

using DEADBEEF;
using System.Collections.Concurrent;

namespace ProcessFiles
{ 
    class Program

    { 
        static void Main()
        {
            FileProcessing fileProcessing = new FileProcessing();
            fileProcessing.Start();
            
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

    }
}