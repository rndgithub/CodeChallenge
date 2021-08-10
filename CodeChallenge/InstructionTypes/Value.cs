using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.InstructionTypes
{
    public class Value : IInstructionType
    {
        public string Name => "Value";

        double IInstructionType.Value(Instruction instruction, List<Instruction> instructions)
        {
            return instruction.InstructionValue ?? 0;
        }
    }
}
