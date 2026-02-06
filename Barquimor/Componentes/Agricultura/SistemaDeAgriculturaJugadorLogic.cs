using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Agricultura
{
    internal class SistemaDeAgriculturaJugadorLogic : IAgricultura, ILogicaHab
    {
        public void cultivar()
        {
            Console.WriteLine("El jugador está cultivando");
        }

        public void ejecutarLogica() => cultivar();
    }
}
