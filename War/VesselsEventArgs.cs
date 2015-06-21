using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class VesselsEventArgs : EventArgs
    {
        public List<Vessel> Vessels { get; set; }
    }
}
