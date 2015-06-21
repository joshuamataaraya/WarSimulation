using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Bullet
    {
        //Constructor
        public Bullet(float pPosX, float pPosY, float pGrade, float pValue)
        {
            Grade = (180 * pGrade) - 90;
            Value = pValue;
            setPos(pPosX, pPosY);
        }

        //Properties
        public float PosX
        {
            set
            {
                _PosX = value;
            }
            get
            {
                return _PosX;
            }
        }
        public float PosY
        {
            set
            {
                _PosY = value;
            }
            get
            {
                return _PosY;
            }
        }
        public float Grade
        {
            set
            {
                _Grade = value;
            }
            get
            {
                return _Grade;
            }
        }
        public float Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }

        //Function
        public void move()
        {
            PosX += 2 * (float)Math.Cos(Grade);
            PosY += 2 * (float)Math.Sin(Grade);
            Value -= 0.4f;
        }
        private void setPos(float pPosX, float pPosY){
            float posX = pPosX;
            float posY = pPosY;
            //funcion que calcula el centro de arriba del buque

            PosX = posX;
            PosY = posY;
        }

        private float _PosX;
        private float _PosY;
        private float _Grade;
        private float _Value;
    }
}
