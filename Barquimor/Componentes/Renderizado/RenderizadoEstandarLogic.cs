using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Dibujado
{
    internal class RenderizadoEstandarLogic : IDibujar
    {
        public void dibujar()
        {
            Console.WriteLine("Me estoy dibujando");
        }

    }
}
