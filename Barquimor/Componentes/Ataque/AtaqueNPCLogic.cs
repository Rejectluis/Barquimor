using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Ataque
{
    internal class AtaqueNPCLogic : IAtacar
    {
        public void atacar()
        {
            Console.WriteLine("¡Soy el Rey Arturo, y estoy atacando con mi esapda Excalibur!");
        }
    }
}
