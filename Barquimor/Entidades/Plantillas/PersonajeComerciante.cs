using Barquimor.Core;
using System;
using System.Collections.Generic;

namespace Barquimor.Entidades.Plantillas
{
    internal abstract class PersonajeComerciante : PersonajeBase
    {
        protected IComerciar logicaComercio;

        protected PersonajeComerciante(string nombre, IComerciar logicaComercio, IDibujar renderizar, IColisionar colision)
            : base(nombre,renderizar,colision)
        {
            this.logicaComercio = logicaComercio;
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


