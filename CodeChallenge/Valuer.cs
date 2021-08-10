using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class Valuer
    {
        public void Value(Dictionary<int,Instruction> instructions)
        {
            while (instructions.ElementAt(0).Value.InstructionValue==null)
            {
                foreach (var inst in instructions.Values.OrderBy(x => x. Instructions.Count()))
                {
                    Value(inst);
                }
            }

        }
        public void Value(Instruction instruction)
        {
            if (instruction.InstructionValue != null || instruction.InstructionType is InstructionTypes.Value)
                return;

            if (instruction.Instructions.All(x => x.InstructionValue != null))
            {
                instruction.InstructionValue = instruction.InstructionType.Value(instruction, instruction.Instructions);
            }

        }

    }
}
