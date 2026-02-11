using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Curativo
{
    internal class SistemaCurativoJugadorLogic : ICuracion, ILogicaHab
    {
        public virtual void curar()
        {
            Console.WriteLine("¡Espera un poco Manfleis, me estoy curando!");
        }

        public void ejecutarLogica() => curar();
    }
}
