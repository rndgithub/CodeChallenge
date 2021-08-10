using CodeChallenge.InstructionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var label = instruction.Text.Substring(0, instruction.Text.IndexOf(':'));
            instruction.Label = Convert.ToInt32(label);
            var remainingText = instruction.Text.Substring(instruction.Text.IndexOf(':') + 1).Trim();

            var instructionType = remainingText.Substring(0, remainingText.IndexOf(' ')).Trim();
            instruction.InstructionType = instructionTypeFactory.GetInstructionType(instructionType);
            remainingText = remainingText.Substring(remainingText.IndexOf(' ')).Trim();

            if (instruction.InstructionType is InstructionTypes.Value)
            {
                instruction.InstructionValue = Convert.ToInt32(remainingText);
                return;
            }

            while (true)
            {
                var indexOf = remainingText.IndexOf(' ');

                if (indexOf > 0)
                    label = remainingText.Substring(0, indexOf).Trim();
                else
                    label = remainingText.Substring(0).Trim();

                instruction.Labels.Add(Convert.ToInt32(label));

                if (indexOf <= 0)
                    break;

                remainingText = remainingText.Substring(remainingText.IndexOf(' ')).Trim();
            }

        }
    }
}
