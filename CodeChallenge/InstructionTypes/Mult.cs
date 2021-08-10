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

        public decimal Value(Instruction instruction)
        {
            return instruction.SubInstructions.Aggregate(1m, (product, subInst) => product * subInst.InstructionValue.Value);
        }
    }
}
