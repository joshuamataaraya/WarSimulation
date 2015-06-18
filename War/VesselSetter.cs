using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace War
{
    class VesselSetter
    {
        private List<Vessel> _Vessels;
        private int _ProcessorsNumber;
        public VesselSetter(List<Instruction> instructions)
        {
            _ProcessorsNumber = Environment.ProcessorCount;
            _Vessels = new List<Vessel>();
            createVessels();
            setVesselsInstructions(instructions);
        }
        private void createVessels()
        {
            int processorCounter= _ProcessorsNumber;
            for (; processorCounter > 0; processorCounter--)
            {
                Vessel vessel = new Vessel();
                _Vessels.Add(vessel);
            }
        }
        private void setVesselsInstructions(List<Instruction> instructions)
        {
            //cambiando el paralelismo a instrucciones por lista 
            Parallel.ForEach(_Vessels, currentVessel =>
            {
                Random rdn = new Random((int)DateTime.Now.Ticks);
                int idNumber = rdn.Next(100, 999);

                Console.WriteLine(idNumber);
                foreach (Instruction instruction in instructions)
                {
                    if (instruction.Id == idNumber || instruction.Id % 10 == idNumber % 10)
                    {
                        currentVessel.addInstruction(instruction);
                    }
                }
            }
            );
        }
        public List<Vessel> vessels
        {
            get{
                return _Vessels;
            }
        }
    }
}
