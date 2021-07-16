using System;

namespace BowlingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new ProgramClass();

            program.Run(args);

            Console.ReadKey();
        }
    }
}
