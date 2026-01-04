using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Items.Capacidades
{
    internal class CapacidadAtaque : ICapacidad
    {
        public int danio { get; set; }
        public CapacidadAtaque(int danio) { this.danio = danio; }

    }
}
