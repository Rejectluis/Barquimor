using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Items.Capacidades
{
    internal class CapacidadComestible : ICapacidad
    {
        public int energia { get; set; }
        public CapacidadComestible(int energia) { this.energia= energia; }


    }
}
