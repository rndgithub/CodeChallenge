using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class InstructionsEvaluator
    {
        private readonly Labeler labeler;
        private readonly Valuer valuer;


        public InstructionsEvaluator()
        {
            labeler = new Labeler();
            valuer = new Valuer();

        }

        public double Evaluate(string[] instructionsInput)
        {
            List<Instruction> instructions = GetInstructions(instructionsInput);

            AddSubInstructions(instructions);

            valuer.Value(instructions);
            return instructions[0].InstructionValue ?? 0;
        }

        private static void AddSubInstructions(List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                foreach (var label in instruction.Labels)
                {
                    var subInstruction = instructions.First(x => x.Label == label);
                    instruction.Instructions.Add(subInstruction);
                }
            }
        }

        private List<Instruction> GetInstructions(string[] instructionsInput)
        {
            List<Instruction> instructions = new List<Instruction>();
            foreach (var line in instructionsInput)
            {
                var instruction = new Instruction(line);
                labeler.Label(instruction);
                instructions.Add(instruction);
            }

            return instructions;
        }
    }
}
