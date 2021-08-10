using CodeChallenge.InstructionParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class InstructionEvaluator
    {
        private readonly IInstructionParser instructionParser;
        private readonly Valuer valuer;


        public InstructionEvaluator()
        {
            instructionParser = new StandardParser();
            valuer = new Valuer();

        }

        public double Evaluate(string[] instructionsInput)
        {
            var instructions = GetInstructions(instructionsInput);

            AddSubInstructions(instructions);

            valuer.Value(instructions);
            return instructions.ElementAt(0).Value.InstructionValue ?? 0;
        }

        private static void AddSubInstructions(Dictionary<int,Instruction> instructions)
        {
            foreach (var instruction in instructions.Values)
            {
                foreach (var label in instruction.Labels)
                {
                    var subInstruction = instructions[label];
                    instruction.SubInstructions.Add(subInstruction);
                }
            }
        }

        private Dictionary<int,Instruction> GetInstructions(string[] instructionsInput)
        {
            var instructions = new Dictionary<int, Instruction>();
            foreach (var line in instructionsInput)
            {
                var instruction = new Instruction(line);
                instructionParser.Parse(instruction);
                instructions.Add(instruction.Label, instruction);
            }

            return instructions;
        }
    }
}
