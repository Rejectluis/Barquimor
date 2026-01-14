using Barquimor.Core;
using Barquimor.Entidades.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Entidades.Moviles
{
    internal class NPC : PersonajeBase
    {
        public enum estadoNPC {
            libre,
            ocupado,
            patrullando
        };
        public estadoNPC estadoActual { get; protected set; } = estadoNPC.libre;

        public NPC(string nombre, IDibujar renderizador, IColisionar colision) 
            : base(nombre, renderizador, colision)
        {
        }

        public void setLiberar() {this.estadoActual = estadoNPC.libre; }
        public void setOcupar() { this.estadoActual = estadoNPC.ocupado; }
        public void setPatrullar() { this.estadoActual = estadoNPC.patrullando; }
        

    }
}
