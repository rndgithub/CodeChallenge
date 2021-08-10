using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.InstructionTypes
{
    public class Mult : IInstructionType
    {
        public string Name => "Mult";

        public double Value(Instruction instruction, List<Instruction> subInstructions)
        {
            double result = 1;
            foreach (var subInstruction in subInstructions)
            {
                result = result * subInstruction.InstructionValue ?? 0;
            }
            return result;
        }
    }
}
