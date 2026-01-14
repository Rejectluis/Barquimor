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
        public enum estadoJugador { libre, ocupado, combate, aturdido } // estados del jugador
        public estadoJugador estadoActual {  get; protected set; } = estadoJugador.libre; // estado actual
        
        public Jugador(String nombre, IDibujar renderizador, IColisionar colision) 
            : base(nombre, renderizador, colision)
        {
        }
        public void setLibre() {this.estadoActual = estadoJugador.libre;}
        public void setOcupado() { this.estadoActual = estadoJugador.ocupado; }
        public void setCombate() { this.estadoActual = estadoJugador.combate; }
        public void setAturdido() { this.estadoActual = estadoJugador.aturdido; }

    }
}
