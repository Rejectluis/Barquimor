using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Agricultura
{
    internal class SistemaDeAgriculturaJugadorLogic : IAgricultura
    {
        public void cultivar()
        {
            Console.WriteLine("El jugador está cultivando");
        }
    }
}
