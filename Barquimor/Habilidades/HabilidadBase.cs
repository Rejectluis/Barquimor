using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
    /*
     *  Esta clase está descontinuada. Representa la forma antigua de crear habilidades, donde cada 
     *  habilidad heredaba de habilidadBase. Actualmente, se usa una factory llamada 'HabilidadManager' 
     *  para crear habilidades que pertenecen a una misma clase, y cuyos datos individuales vienen de 
     *  un archivo json.
     *  
     *  No se ha borrado porque es muy reciente la transición entre habilidades por herencia y por json.
     *  Quizá, en el futuro, se decida eliminar el viejo sistema de creación de habilidades.
     */
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
    }
}
