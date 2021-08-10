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
            return instruction.Instructions.Aggregate(1.0, (product, subInst) => product * subInst.InstructionValue.Value);
        }
    }
}
