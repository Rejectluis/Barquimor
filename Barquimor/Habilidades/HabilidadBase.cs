using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Habilidades
{
    internal abstract class HabilidadBase
    {
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public int nivel { get; set; }
        public int experiencia { get; set; }
        public HabilidadBase()
        {

        }
        public HabilidadBase(string tipo, string descripcion)
        {
            this.tipo = tipo;
            this.descripcion = descripcion;
            this.nivel = 1;
            this.experiencia = 0;
        }

        // Añadir aquí un método de subir nivel y sumado de experiencia 

    }
}
