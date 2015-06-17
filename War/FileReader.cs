using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace War
{
    class FileReader
    {
        private string _Strategy;
        public FileReader()
        {
            _Strategy = System.IO.File.ReadAllText(@"C:\Users\Joshua\Documents\GitHub\WarSimulation\estrategia.txt");
        }
        public String Strategy{
            get
            {
                return _Strategy;
            }
        }
        public ArrayList analize()
        {
            ArrayList Instructions = new ArrayList();
            int indication=0;
            /*
             * if 
             * indication=0  -> grade
             * indication=1  -> id
             * indication=2 -> action
             * indication=3  -> value
             */
            String gradeTemp="";
            String idTemp = "";
            String actionTemp = "";
            String valueTemp = "";
            foreach (char character in _Strategy)
            {
                if(indication==0)
                {
                    if(character !='|')
                    {
                        gradeTemp += character;
                    }else{
                        indication++;
                    }
                }else if ( indication ==1)
                {
                    if(character !='|')
                    {
                        idTemp += character;
                    }else{
                        indication++;
                    }
                }else if ( indication ==2)
                {
                    if(character !='|')
                    {
                        actionTemp += character;
                    }else{
                        indication++;
                    }
                }
                else if (indication == 3)
                {
                    if (character != '|')
                    {
                        valueTemp += character;
                    }
                    else
                    {
                        Instruction instruction = new Instruction();
                        //convert data types and insert a new instruction
                        Instructions.Add(instruction);
                        indication = 0;
                    }
                }
            }
            

            return Instructions;
            //this process the string of strategy
            //this combines same actions
        }
    }
}
