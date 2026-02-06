using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*
     *  Esta clase representa una síntesis de todas las habilidades que se pueden crear 
     *  (es como una generalización). Todas las habilidades son instancias de esta única clase. 
     *  El archivo JSON 'Habilidades.JSON' es el que establece cuál será el id, nombre, 
     *  descripción y conjunto de lógicas que pertenecen a una habilidad. 
     *  
     *  En resumen, esta clase representa un objeto (con lógica) del archivo 
     *  'Habilidades.JSON'
     */ 
namespace Barquimor.Habilidades.CreadorDeHabilidades
{
    internal class HabBase : IHabilidad
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int nivel { get; set; }
        public int experiencia { get; set; }
        public Dictionary<Type, ILogicaHab> logicas { get; set; }
        public HabBase()
        {

        }
        public virtual void ejecutarHabilidad()
        {
            foreach(var l in logicas.Values)
            {
                l.ejecutarLogica();
            }
        }
    }
}
