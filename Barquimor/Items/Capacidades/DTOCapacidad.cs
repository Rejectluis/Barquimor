using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Items.Capacidades
{
    /*
     * Representa a cada objeto individual dentro de la lista de capacidades:
     * acepta todos los tipos de datos posibles de los objetos JSON, como 
     * potencia (para hachas),daño (para espadas), energía (para comidas), etc.
     * 
     */
    internal class DTOCapacidad
    {
        public string tipo { get; set; }
        public int danio { get; set; }
        public int potencia { get; set; }
        public int energia { get; set; }

        

    }
}
