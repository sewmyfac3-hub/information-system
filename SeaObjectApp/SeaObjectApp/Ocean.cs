using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaObjectApp
{
    class Ocean : Sea
    {
        public bool HasCurrents { get; set; }

        public override string GetInfo()
        {
            return $"Океан \"{Name}\" {Depth} {Salinity} {HasCurrents}";
        }
    }
}
