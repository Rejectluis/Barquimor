using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Comercio
{
    internal class SistemaDeComercioNPCLogic : IComerciar
    {
        public void comercioHabilitado()
        {
            Console.WriteLine("Comercio abierto");

        }

        public void comercioDeshabilitado()
        {
            Console.WriteLine("Comercio cerrado");
        }
    }
}
