using Barquimor.Items.Capacidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Items.Items
{   
    /*
     *  Esta clase representa el Item completo que viene en un JSON
     */ 
    internal class DTOItemRow
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<DTOCapacidad> capacidades { get; set; }

        
    }
}
