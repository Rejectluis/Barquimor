using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Comercio
{
    internal class SistemaDeComercioJugadorLogic : IComerciar, IHabilidad
    {

        public void comercioHabilitado()
        {
            Console.WriteLine("¡Soy el jugador, y estoy comerciando ahora!");
        }

        public void comercioDeshabilitado()
        {
            Console.WriteLine("¡Soy el jugador y cerré el comercio!");
        }
    }
}
