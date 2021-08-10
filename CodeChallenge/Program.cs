using System;
using System.Collections.Generic;
using System.Diagnostics;
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


            var watcher = Stopwatch.StartNew();

            var lines = File.ReadAllLines(@"c:\temp\input.txt");
            //var lines = File.ReadAllLines(@"c:\temp\input example.txt");
            var instructionsEvaluator = new InstructionEvaluator();
            var result = instructionsEvaluator.Evaluate(lines);

            watcher.Stop();
            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"Duration: {watcher.Elapsed}");
            Console.ReadLine();
        }
    }
}
