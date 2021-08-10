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

            //foreach (var inst in instructions.Values)
            //{
            //    foreach (var subInst in inst.Instructions)
            //    {
            //        Console.WriteLine($"    {inst.Label} -> {subInst.Label};");
            //    }
            //}


        }

        private void Value(Dictionary<int,Instruction> instructions, Instruction instruction)
        {
            if (instruction.InstructionValue != null)
                return;

            var watcher = Stopwatch.StartNew();

            foreach (var subInst in instruction.Instructions)
            {
                Value(instructions, subInst);
            }

            instruction.InstructionValue = instruction.InstructionType.Value(instruction, instruction.Instructions);

            watcher.Stop();
            Console.WriteLine($"Label {instruction.Label} took {watcher.Elapsed}");
        }

    }
}
