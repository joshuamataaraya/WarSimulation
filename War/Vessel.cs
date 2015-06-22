using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
namespace War
{
    public class Vessel
    {       
        //Constructor
        public Vessel()
        {
            PosX = rdn.Next(0, 610);
            PosY = rdn.Next(0, 610);
            Instructions = new List<Instruction>();
            _Bullets = new List<Bullet>();
            _CurrentInstruction = 0;

            _Id = rdn.Next(100, 999);
            Grade = 90;
            Action = "STOP";
            Value = 0;
            Active = false;
            Life = 3;
        }
        
        //Properties
        public List<Instruction> Instructions
        {
            set
            {
                _Instructions = value;
            }
            get
            {
                return _Instructions;
            }
        }
        public bool Active
        {
            set
            {
                _Active = value;
            }
            get
            {
                return _Active;
            }
        }
        public int Id
        {
            get
            {
                return _Id;
            }
        }
        public int CurrentInstruction
        {
            set
            {
                _CurrentInstruction = value;
            }
            get
            {
                return _CurrentInstruction;
            }
        }
        public List<Bullet> Bullets
        {
            get
            {
                return _Bullets;
            }
        }
        public int Life
        {
            set
            {
                _Life = value;
            }
            get
            {
                return _Life;
            }
        }
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
                _CurrentGrade = value;
            }
            get
            {
                return _CurrentGrade;
            }
        }
        public float Value
        {
            set
            {
                _CurrentValue = value;
            }
            get
            {
                return _CurrentValue;
            }
        }
        public string Action
        {
            set
            {
                _CurrentAction = value;
            }
            get
            {
                return _CurrentAction;
            }
        }

        //Vessel preparation
        public void addInstruction(Instruction pInstruction)
        {
            Instructions.Add(pInstruction);
        }
        public void mixInstructions()
        {
            try
            {
                int instructionACounter = 0;
                int instructionBCounter = 1;
                float gradeA = 0;
                float gradeB = 0;
                float valueA = 0;
                float valueB = 0;
                for (; instructionACounter < _Instructions.Count-1; )
                {
                    if (_Instructions[instructionACounter].Action == _Instructions[instructionBCounter].Action)
                    {
                        gradeA = _Instructions[instructionACounter].Grade;
                        gradeB = _Instructions[instructionBCounter].Grade;
                        valueA = _Instructions[instructionACounter].Value;
                        valueB = _Instructions[instructionBCounter].Value;
                        if(gradeA != 0)
                        {
                            _Instructions[instructionACounter].Grade = (gradeA + gradeB) % gradeA;
                        }
                        else
                        {
                            _Instructions[instructionACounter].Grade = (gradeA + gradeB);
                        }
                        _Instructions[instructionACounter].Value = (valueA + valueB) / 2;

                        _Instructions.RemoveAt(instructionBCounter);
                    }
                    else
                    {
                        instructionACounter++;
                        instructionBCounter++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("/MixError: " + e.ToString());
            }
            //Console.WriteLine("N instrucciones: " + Instructions.Count);
        }
    
        //Game functions
        public void storeNextInstruction()
        {
            if(Active){
                move();
            }else{
                try
                {
                    if (_CurrentInstruction < Instructions.Count-1)
                    {
                        Action = Instructions[_CurrentInstruction].Action;
                        if(Action=="avanzar")
                        {
                            Active = true;
                            float temp = 180 * Instructions[_CurrentInstruction].Grade;
                            while (temp > 180)
                            {
                                temp = temp - 180;
                            }
                            temp = temp - 90;
                            Grade = Grade + temp;
                            while (Grade > 360)
                            {
                                Grade -= 360;
                            }
                            Value = Instructions[_CurrentInstruction].Value;
                            _CurrentInstruction++;
                            move();
                        }
                        else
                        {
                            float temp = 180 * Instructions[_CurrentInstruction].Grade;
                            while (temp > 180)
                            {
                                temp = temp - 180;
                            }
                            temp = temp - 90;
                            Grade = Grade + temp;
                            while (Grade > 360)
                            {
                                Grade -= 360;
                            }
                            shoot(Instructions[_CurrentInstruction].Value, Grade);
                            _CurrentInstruction++;
                            Active = false;
                        }
                    }
                    else
                    {
                        Active = false;
                        Action = "STOP";
                        Grade = 90;
                        Value = 0;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Action = "STOP";
                    Active = false;
                    Grade = 90;
                    Value = 0;
                }
            }         
        }
        public Boolean canContinue()
        {
            if (_CurrentInstruction < Instructions.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Pendiente
        private void shoot(float pValor, float pGrado)
        {
            Console.WriteLine("shooting");
            Bullet bullet = new Bullet(pValor, pGrado, this.PosX, this.PosY);
            Bullets.Add(bullet);
            UpdateBullets();
        }
        public void move()
        {
            Console.WriteLine("moving from: " + PosX + "x" + PosY);
            float nPosX = PosX + (float)Math.Sin(Grade);
            float nPosY = PosY - (float)Math.Cos(Grade);
            if(nPosX>0 && nPosX<=610 && nPosY>0 && nPosY<=610){
                PosX = nPosX;
                PosY = nPosY;
                Console.WriteLine("moving to: " + PosX + "x" + PosY);
                Value -= 0.4f;
            }
            else
            {
                Value = 0;
            }
            UpdateBullets();
            if (Value <= 0)
            {
                Active = false;
            }
        }
        public void UpdateBullets()
        {
            int currentBullet = 0;
            while (currentBullet < Bullets.Count)
            {
                if(Bullets[currentBullet].Value > 0)
                {
                    Bullets[currentBullet].move();
                }
                else
                {
                    Bullets.RemoveAt(currentBullet);
                }
                currentBullet++;
            }
        }        
        
        //Atributes
        private List<Instruction> _Instructions;
        private List<Bullet> _Bullets;
        private bool _Active;
        private int _Id;
        private int _Life;
        private int _CurrentInstruction;
        private float _PosX;
        private float _PosY;
        private float _CurrentGrade;
        private float _CurrentValue;
        private String _CurrentAction;
        private static Random rdn = new Random();
    }
}
