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
       
        public delegate void UpdateViewEventHandler(object source, VesselsEventArgs args);
        public event UpdateViewEventHandler updateView;

        //Constructors
        public SetUp()
        {
            FileReader f = new FileReader();
            List<Instruction> ins = f.getInstructions();
            _ProcessorsNumber = Environment.ProcessorCount;
            _Vessels = new List<Vessel>();
            createVessels();
            setAndMixVesselsInstructions(ins);
        }
        public SetUp(List<Instruction> instructions)
        {
            _ProcessorsNumber = Environment.ProcessorCount;
            _Vessels = new List<Vessel>();
            createVessels();
            setAndMixVesselsInstructions(instructions);
        }
        
        //Properties
        public List<Vessel> vessels
        {
            get
            {
                return _Vessels;
            }
        }
        
        //Functions
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
                    index--;
                    int bit = 1;
                    if (index > 0)
                    {
                        bit = bit << index;
                    }
                    proc.ProcessorAffinity = (IntPtr)bit;
                    Console.WriteLine(bit);
                    /**
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
                    }*/
                    
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
                Console.WriteLine("*SetMix Error: " + e.ToString());
            }
        }
        private void game(Vessel currentVessel, int index)
        {
            foreach (ProcessThread proc in Process.GetCurrentProcess().Threads)
            {
                int currentThreadId = (int)GetCurrentThreadId();
                if (currentThreadId == proc.Id)
                {
                    index--;
                    int bit = 1;
                    if (index > 0)
                    {
                        bit = bit << index;
                    }
                    proc.ProcessorAffinity = (IntPtr)bit;
                    Console.WriteLine(bit);
                }
            }
            currentVessel.storeNextInstruction();
            Thread.Sleep(1000);
            OnBoatAction();
        }
        private void runGame()
        {
            try
            {
                int counter = _Vessels.Count;
                foreach (Vessel vess in _Vessels)
                {
                    Thread thread = new Thread(delegate() { game(vess, counter); });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("-RunGame Error: " + e.ToString());
            }
        }
      
        //Delegate functions
        protected virtual void OnBoatAction()
        {
            if (updateView != null)
            {
                updateView(this, new VesselsEventArgs() { Vessels = vessels });
            }
        }

        //Attributes
        private List<Vessel> _Vessels;
        private int _ProcessorsNumber;
    }
}
