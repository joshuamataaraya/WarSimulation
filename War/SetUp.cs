using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace War
{
    class SetUp
    {
        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        private List<Vessel> _Vessels;
        private int _ProcessorsNumber;
        public SetUp(List<Instruction> instructions)
        {
            _ProcessorsNumber = Environment.ProcessorCount;
            _Vessels = new List<Vessel>();
            createVessels();
            setAndMixVesselsInstructions(instructions);
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
        private void function(List<Instruction> instructions, Vessel currentVessel,int index)
        {
            foreach (ProcessThread proc in Process.GetCurrentProcess().Threads)
            {
                int currentThreadId = (int)GetCurrentThreadId();
                if (currentThreadId == proc.Id)
                {
                    if (index == 1)
                    {
                        proc.ProcessorAffinity = (IntPtr)1;
                        Console.WriteLine("Here");
                    }
                    else if (index == 2)
                    {
                        proc.ProcessorAffinity = (IntPtr)2;
                        Console.WriteLine("Here2");
                    }
                    else if (index == 3)
                    {
                        proc.ProcessorAffinity = (IntPtr)4;
                        Console.WriteLine("Here3");
                    }
                    else if (index == 4)
                    {
                        proc.ProcessorAffinity = (IntPtr)8;
                        Console.WriteLine("Here4");
                    }
                    
                }                
            }
            foreach (Instruction instruction in instructions)
            {
                if (instruction.Id == currentVessel.Id || instruction.Id % 10 == currentVessel.Id % 10)
                {
                    currentVessel.addInstruction(instruction);
                }
            }
            currentVessel.mixInstructions();
        }
        private void setAndMixVesselsInstructions(List<Instruction> instructions)
        {
            try
            {
                int counter=_Vessels.Count;
                foreach (Vessel vess in _Vessels)
                {
                    Thread thread = new Thread(delegate() { function(instructions, vess,counter); });
                    thread.Start();
                    Thread.Sleep(100);
                    counter--;
                }                            
                //Parallel.ForEach(_Vessels, currentVessel =>
                //{
                //    foreach (Instruction instruction in instructions)
                //    {
                //        if (instruction.Id == currentVessel.Id || instruction.Id % 10 == currentVessel.Id % 10)
                //        {
                //            currentVessel.addInstruction(instruction);
                //        }
                //    }
                //    currentVessel.mixInstructions();
                //}
                //);
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
