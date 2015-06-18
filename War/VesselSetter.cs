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
            try
            {
                Parallel.ForEach(_Vessels, currentVessel =>
                {
                    foreach (Instruction instruction in instructions)
                    {
                        if (instruction.Id == currentVessel.Id || instruction.Id % 10 == currentVessel.Id % 10)
                        {
                            currentVessel.addInstruction(instruction);
                        }
                    }
                }
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public List<Vessel> vessels
        {
            get{
                return _Vessels;
            }
        }
    }
}
