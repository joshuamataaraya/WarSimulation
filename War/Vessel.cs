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
        private ArrayList _Instructions;
        public Vessel()
        {
            _Position = new Point();
            _Instructions = new ArrayList();
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
        public void processInstructions()
        {

        }
    }
}
