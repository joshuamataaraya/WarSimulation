using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Instruction
    {
        private float _Grade;
        private int _Id;
        private String _Action;
        private float _Value;
        public float Grade
        {
            get
            {
                return _Grade;
            }
            set
            {
                _Grade = value;
            }
        }
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public String Action
        {
            get
            {
                return _Action;
            }
            set
            {
                _Action = value;
            }
        }
        public float Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }


    }
}
