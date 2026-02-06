using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*
     *  Esta clase está descontinuada. Ver explicación en la clase 'HabilidadBase'.
     */
namespace Barquimor.Habilidades.Ataques
{
    internal class HabilidadAtaque : HabilidadBase, IHabilidad
    {
        public IAtacar logicaAtaque { get; set; }

        public HabilidadAtaque(IAtacar logicaAtaque) 
            : base("¡Ataque físico!", "Permite atacar con arma equipada")
        {
            this.logicaAtaque = logicaAtaque;
        }

        public void ejecutarHabilidad()
        {
            logicaAtaque.atacar();
        }

    }
}
