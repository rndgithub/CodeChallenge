using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.InstructionTypes
{
    public class Add : IInstructionType
    {
        public string Name => "Add";

        public double Value(Instruction instruction)
        {
            return instruction.SubInstructions.Sum(x => x.InstructionValue.Value);
        }
    }
}
