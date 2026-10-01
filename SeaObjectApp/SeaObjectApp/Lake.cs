using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaObjectApp
{
    class Lake : Sea
    {
        public bool IsFreshwater { get; set; }

        public override string GetInfo()
        {
            return $"Озеро \"{Name}\" {Depth} {Salinity} {IsFreshwater}";
        }
    }
}
