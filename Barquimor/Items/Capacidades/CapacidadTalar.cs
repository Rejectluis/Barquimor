using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Items.Capacidades
{
    internal class CapacidadTalar : ICapacidad
    {
        public int potencia { get; set; }
        public CapacidadTalar(int potencia) { this.potencia = potencia; } 
    }
}
