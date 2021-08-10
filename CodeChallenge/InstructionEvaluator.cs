﻿using CodeChallenge.InstructionParsers;
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
                instructionParser.Parse(instruction);
                instructions.Add(instruction);
            }

            return instructions;
        }
    }
}