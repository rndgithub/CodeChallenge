using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.InstructionParsers
{
    public interface IInstructionParser
    {
        void Parse(Instruction instruction);
    }
}
