using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.InstructionTypes
{
    public interface IInstructionType
    {
        string Name { get; }
        double Value(Instruction instruction);
    }
}
