using CodeChallenge.InstructionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class Labeler
    {
        private readonly InstructionTypeFactory instructionTypeFactory;

        public Labeler()
        {
            instructionTypeFactory = new InstructionTypeFactory();
        }

        public void Label(Instruction instruction)
        {
            var instructionType = Regex.Matches(instruction.Text, @"[^\d\W]+")[0].Value;
            instruction.InstructionType = instructionTypeFactory.GetInstructionType(instructionType);

            var labels = Regex.Matches(instruction.Text, "[0-9]+");
            instruction.Label = Convert.ToInt32(labels[0].Value);

            if (instruction.InstructionType is InstructionTypes.Value)
            {
                instruction.InstructionValue = Convert.ToInt32(labels[1].Value);
                return;
            }

            for (int i = 1; i < labels.Count; i++)
            {
                instruction.Labels.Add(Convert.ToInt32(labels[i].Value));
            }

        }
    }
}
