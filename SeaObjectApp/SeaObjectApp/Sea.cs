using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaObjectApp
{
    class Sea
    {
        public string Name { get; set; }
        public double Depth { get; set; }
        public double Salinity { get; set; }

        public virtual string GetInfo()
        {
            return $"Море \"{Name}\" {Depth} {Salinity}";
        }
    }

}
