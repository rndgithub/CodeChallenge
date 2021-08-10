using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.InstructionTypes
{
    public class InstructionTypeFactory
    {
        List<IInstructionType> InstructionTypes = new List<IInstructionType> { new Value(), new Add(), new Mult() };
        public IInstructionType GetInstructionType(string type)
        {
            var instructionType = InstructionTypes.FirstOrDefault(x => x.Name == type);
            if (instructionType == null)
                throw new ArgumentException($"No InstructionType for {type}");

            return instructionType;

        }
    }
}
