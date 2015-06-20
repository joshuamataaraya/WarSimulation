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
        private List<Bullet> _Bullets;
        private int _InstructionCounter;
        private int _Id;
        private static Random rdn=new Random();
        public Vessel()
        {
            _Position = new Point(rdn.Next(0, 650),rdn.Next(0, 650));
            _Instructions = new List<Instruction>();
            _Bullets = new List<Bullet>();
            _Id = rdn.Next(100, 999);
            _InstructionCounter = 0;
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
            _Position = new Point(pX, pY);
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
                if (_InstructionCounter < _Instructions.Count)
                {
                    instruction = _Instructions[_InstructionCounter];
                    _InstructionCounter++;
                }
                return instruction;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }
        public void mixInstructions()
        {
            try{
                int instructionACounter = 0;
                int instructionBCounter = 1;
                float gradeA=0;
                float gradeB=0;
                float valueA=0;
                float valueB=0;
                for (; instructionACounter < _Instructions.Count; )
                {
                    if (_Instructions[instructionACounter].Action == _Instructions[instructionBCounter].Action)
                    {
                        gradeA=_Instructions[instructionACounter].Grade;
                        gradeB=_Instructions[instructionBCounter].Grade;
                        valueA=_Instructions[instructionACounter].Value;
                        valueB=_Instructions[instructionBCounter].Value;

                        _Instructions[instructionACounter].Grade=(gradeA+gradeB)%gradeA;
                        _Instructions[instructionACounter].Value = (valueA + valueB) / 2;

                        _Instructions.RemoveAt(instructionBCounter);
                    }
                    else
                    {
                        instructionACounter++;
                        instructionBCounter++;
                    }
                }
            }catch(Exception e){
                Console.WriteLine(e.ToString());
            }
            
        }
    }
}
