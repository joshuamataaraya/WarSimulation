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
            _PosX = rdn.Next(0, 610);
            _PosY = rdn.Next(0, 610);
            Instructions = new List<Instruction>();
            Bullets = new List<Bullet>();
            _Id = rdn.Next(100, 999);
            Grade = 0;
            Action = "STOP";
            Value = 0;
            Active = false;
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
        public List<Bullet> Bullets
        {
            set
            {
                _Bullets = value;
            }
            get
            {
                return _Bullets;
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

        //Setters-getters
        public float getAngle()
        {
            if (Action != "STOP")
            {
                return (180 * Grade) - 90;
            }
            else
            {
                return 0;
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

                        _Instructions[instructionACounter].Grade = (gradeA + gradeB) % gradeA;
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
            Console.WriteLine("N instrucciones: " + Instructions.Count);
        }
    
        //Game functions
        public Instruction getNextInstruction()
        {
            try
            {
                //if there are not instructions it returns null
                Instruction instruction = null;
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
        public void storeNextInstruction()
        {
            if(Active){
                move();
            }else{
                try
                {
                    if (_InstructionCounter < Instructions.Count)
                    {
                        Action = Instructions[_InstructionCounter].Action;
                        if(Action=="avanzar"){
                            Active = true;
                            Grade = Instructions[_InstructionCounter].Grade;
                            Value = Instructions[_InstructionCounter].Value;
                            _InstructionCounter++;
                            move();
                        }
                        else
                        {
                            shoot(Instructions[_InstructionCounter].Value, Instructions[_InstructionCounter].Grade);
                            _InstructionCounter++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Action = "STOP";
                    Active = false;
                }
            }         
        }
        //Pendiente
        private void shoot(float pValor, float pGrado)
        {
            Bullet bullet = new Bullet(pValor, pGrado, _PosX, _PosY);
            Bullets.Add(bullet);
            UpdateBullets();
        }
        public void move()
        {
            float grade = (180 * _CurrentGrade) - 90;
            PosX += 1 * (float)Math.Cos(grade);
            PosY += 1 * (float)Math.Sin(grade);
            Value -= 0.4f;
            UpdateBullets();
            if (Value < 0)
            {
                Active = false;
            }
        }
        public void UpdateBullets()
        {
            foreach(Bullet bullet in Bullets){
                if (bullet.Value > 0)
                {
                    bullet.move();
                }
                else
                {
                    Bullets.Remove(bullet);
                }
            }
        }        
        
        //Atributes
        private List<Instruction> _Instructions;
        private List<Bullet> _Bullets;
        private bool _Active;
        private int _Id;
        private int _Life;
        private int _InstructionCounter;
        private float _PosX;
        private float _PosY;
        private float _CurrentGrade;
        private float _CurrentValue;
        private String _CurrentAction;
        private static Random rdn = new Random();
    }
}
