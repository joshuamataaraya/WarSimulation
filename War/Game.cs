using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Game
    {
        private int _Id;
        private String _Name;
        private String _Date;
        public Game(int pId, String pNombre,String pDate)
        {
            _Id = pId;
            _Name = pNombre;
            _Date = pDate;
        }
        public String Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }
        public int id
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
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        override
        public string ToString()
        {
            return _Name + " "+ _Date;
        }
    }
}
