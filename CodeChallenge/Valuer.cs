using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class Valuer
    {
        public void Value(Dictionary<int,Instruction> instructions)
        {
            Value(instructions, instructions.Values.ElementAt(0));
        }

        private void Value(Dictionary<int,Instruction> instructions, Instruction instruction)
        {
            if (instruction.InstructionValue != null)
                return;

            var watcher = Stopwatch.StartNew();

            foreach (var subInst in instruction.SubInstructions)
            {
                Value(instructions, subInst);
            }

            instruction.InstructionValue = instruction.InstructionType.Value(instruction);

            watcher.Stop();
            Console.WriteLine($"Label {instruction.Label} took {watcher.Elapsed}");
        }

    }
}
