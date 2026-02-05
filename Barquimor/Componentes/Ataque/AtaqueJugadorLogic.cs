using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Ataque
{
    internal class AtaqueJugadorLogic : IAtacar, IHabilidad
    {
        public virtual void atacar()
        {
            Console.WriteLine("¡Soy el jugador, y estoy atacando con mi esapda mamalona!");
        }
    }
}
