using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class Valuer
    {
        public void Value(List<Instruction> instructions)
        {
            while (instructions.Any(x => x.InstructionValue == null))
            {
                foreach (var inst in instructions.OrderBy(x => x.Instructions.Count()))
                {
                    Value(inst);
                }
            }

        }
        public void Value(Instruction instruction)
        {
            if (instruction.InstructionValue != null)
                return;

            if (instruction.Instructions.Count > 0 && instruction.Instructions.All(x => x.InstructionValue != null))
            {
                instruction.InstructionValue = instruction.InstructionType.Value(instruction, instruction.Instructions);
            }

        }

    }
}
