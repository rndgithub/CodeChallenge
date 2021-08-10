using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    partial class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff", CultureInfo.InvariantCulture));

            var lines = File.ReadAllLines(@"c:\temp\input.txt");
            //var lines = File.ReadAllLines(@"c:\temp\input example.txt");
            var instructionsEvaluator = new InstructionsEvaluator();
            var result = instructionsEvaluator.Evaluate(lines);

            Console.WriteLine($"Result: {result}");
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff", CultureInfo.InvariantCulture));
            Console.ReadLine();

        }

    }
}
