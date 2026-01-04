using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Colisionado
{
    internal class ColisionarCirculoLogic : IColisionar
    {
        public void colisionar()
        {
            Console.WriteLine("Me colisiono en circulo");
        }
    }
}
