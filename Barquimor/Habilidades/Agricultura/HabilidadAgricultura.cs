using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
    /*
     *  Esta clase está descontinuada. Ver explicación en la clase 'HabilidadBase'.
     */
namespace Barquimor.Habilidades.Agricultura
{
    internal class HabilidadAgricultura : HabilidadBase, IHabilidad
    {
        public IAgricultura logicaAgricultura;
        public HabilidadAgricultura(IAgricultura logicaAgricultura) 
            : base("¡Habilidad de agricultura desbloqueada!", "Ahora puedes cultivar en tu huerto")
        {
            this.logicaAgricultura = logicaAgricultura;
        }

        public void ejecutarHabilidad()
        {
            this.logicaAgricultura.cultivar();
        }
    }
}
