using Barquimor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /* 
     * Esta clase representa brevemente los objetos del archivo 'Habilidad.JSON'
    */
namespace Barquimor.Habilidades.CreadorDeHabilidades
{
    internal class DTOHabilidad : IDTOBase
    {
        public string id {  get; set; }
        public string nombre {  get; set; }
        public string descripcion { get; set; }
        public List<DTOLogica> tipoDeLogica {  get; set; }
    }
}
