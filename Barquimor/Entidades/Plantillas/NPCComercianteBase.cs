using Barquimor.Core;
using Barquimor.Entidades.Moviles;
using System;
using System.Collections.Generic;

namespace Barquimor.Entidades.Plantillas
{
    internal abstract class NPCComercianteBase : NPC
    {

        protected IComerciar logicaComercio;

        protected NPCComercianteBase(string nombre, IComerciar logicaComercio, IDibujar renderizar, IColisionar colision)
            : base(nombre,renderizar,colision)
        {
            this.logicaComercio = logicaComercio;
            this.estadoActual = estadoNPC.ocupado;
        }

        public virtual void activarComercio()
        {
            logicaComercio.comercioHabilitado();
        }

        public virtual void desactivarComercio()
        {
            logicaComercio.comercioDeshabilitado();
        }

        

        
    }
}


