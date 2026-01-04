using Barquimor.Componentes.Agricultura;
using Barquimor.Componentes.Ataque;
using Barquimor.Componentes.Comercio;
using Barquimor.Core;
using Barquimor.Habilidades.Agricultura;
using Barquimor.Habilidades.Ataques;
using Barquimor.Habilidades.Comercios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Habilidades
{
    internal class HabilidadFactory
    {
        public static IHabilidad crearHabilidad(string tipoHabilidad)
        {
            return tipoHabilidad switch
            {
                "Ataque" => new HabilidadAtaque(new AtaqueJugadorLogic()),
                "Comercio" => new HabilidadComercio(new SistemaDeComercioJugadorLogic()),
                "Agricultura" => new HabilidadAgricultura(new SistemaDeAgriculturaJugadorLogic()),
                _ => null 
            };
        }
    }
}
