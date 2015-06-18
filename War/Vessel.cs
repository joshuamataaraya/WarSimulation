using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
namespace War
{
    class Vessel
    {
        private Point _Position;
        private List<Instruction> _Instructions;
        private int instructionCounter;
        private int _Id;
        private static Random rdn=new Random();
        public Vessel()
        {
            _Position = new Point();
            _Instructions = new List<Instruction>();
            _Id = rdn.Next(100, 999);
            instructionCounter = 0;
        }
        public int Id
        {
            get
            {
                return _Id;
            }
        }
        public Point getPostition()
        {
            return _Position;
        }
        public void addInstruction(Instruction pInstruction)
        {
            _Instructions.Add(pInstruction);
        }
        public void setPosition(int pX, int pY)
        {

        }
        private void shoot(int pValor, int pGrado)
        {

        }
        public void move(int pValor,int pGrado)
        {

        }
        public Instruction getNextInstruction()
        {
            try
            {
                //if there are not instructions it returns null
                Instruction instruction=null;
                if (instructionCounter < _Instructions.Count)
                {
                    instruction = _Instructions[instructionCounter];
                    instructionCounter++;
                }
                return instruction;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }
    }
}
