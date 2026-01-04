using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Habilidades.Comercios
{
    internal class HabilidadComercio : HabilidadBase, IHabilidad
    {
        public IComerciar logicaComercio { get; set; }
        public HabilidadComercio(IComerciar logicaComercio) 
            : base("¡Ahora eres comerciante!", "Puedes comerciar con el pueblo y los mercantes.")
        {
            this.logicaComercio = logicaComercio;
        }

        public void ejecutarHabilidad()
        {
            this.logicaComercio.comercioHabilitado();
            this.logicaComercio.comercioDeshabilitado();
        }

    }
}
