using Barquimor.Core;
using Barquimor.Entidades.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Entidades
{
    internal class Jugador : PersonajeBase
    {
        public Jugador(String nombre, IDibujar renderizador, IColisionar colision) 
            : base(nombre, renderizador, colision)
        {
        }

    }
}
