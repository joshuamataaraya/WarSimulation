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
        public Game()
        {
            _Id = 0;
            _Name = "";
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
    }
}
