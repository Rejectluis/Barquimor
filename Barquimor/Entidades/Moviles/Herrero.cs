using Barquimor.Componentes.Comercio;
using Barquimor.Core;
using Barquimor.Entidades.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Entidades.Moviles
{
    internal class Herrero : PersonajeComerciante
    {
        public Herrero(string nombre,IComerciar comercio, IDibujar renderizador, IColisionar colisionar) 
            : base(nombre, comercio, renderizador, colisionar)
        {
            this.nombre = nombre;
            this.vida = 100;
        }







    }
}
