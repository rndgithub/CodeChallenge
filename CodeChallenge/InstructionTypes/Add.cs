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

        public double Value(Instruction instruction, List<Instruction> subInstructions)
        {
            return subInstructions.Sum(x => x.InstructionValue ?? 0);
        }
    }
}
