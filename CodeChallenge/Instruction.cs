using CodeChallenge.InstructionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class Instruction
    {
        public Instruction()
        {
            SubInstructions = new List<Instruction>();
            Labels = new List<int>();
        }

        public Instruction(string text) : this()
        {
            Text = text;
        }

        public Instruction(int label) : this()
        {
            this.Label = label;
        }

        public IInstructionType InstructionType { get; set; }

        public int Label { get; set; }
        public List<int> Labels { get; set; }
        public List<Instruction> SubInstructions { get; set; }

        public decimal? InstructionValue { get; set; }

        public string Text { get; set; }

    }
}
