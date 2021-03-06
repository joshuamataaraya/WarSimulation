﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class Bullet
    {
        //Constructor
        public Bullet(float pValue, float pGrade, float pPosX, float pPosY)
        {
            Grade = pGrade;
            Value = pValue;
            PosX = pPosX;
            PosY = pPosY;
            if (Grade >= 0 && Grade < 180)
            {
                PosX += ((float)Math.Cos(Grade * Math.PI / 180) * 4);
                PosY += ((float)Math.Sin(Grade * Math.PI / 180) * 4);
            }
            else
            {
                PosX -= ((float)Math.Cos(Grade * Math.PI / 180) * 4);
                PosY -= ((float)Math.Sin(Grade * Math.PI / 180) * 4);
            }
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
            if (Grade >= 0 && Grade < 180)
            {
                PosX += ((float)Math.Cos(Grade * Math.PI / 180) * 4);
                PosY += ((float)Math.Sin(Grade * Math.PI / 180) * 4);
            }
            else
            {
                PosX -= ((float)Math.Cos(Grade * Math.PI / 180) * 4);
                PosY -= ((float)Math.Sin(Grade * Math.PI / 180) * 4);
            }
            Value -= 0.1f;
        }

        private float _PosX;
        private float _PosY;
        private float _Grade;
        private float _Value;
    }
}
