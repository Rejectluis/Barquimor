using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Componentes.Agricultura
{
    internal class SistemaDeAgriculturaNPCLogic : IAgricultura
    {
        public void cultivar()
        {
            Console.WriteLine("Soy el Cipriano el agricultor, y estoy cultivando");
        }
    }
}
