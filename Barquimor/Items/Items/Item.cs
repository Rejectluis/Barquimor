using Barquimor.Items.Capacidades;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Items.Items
{
    /*  Esta clase es representa a las instancias de los items. Es decir, las cosas   
     *  que el jugador lleva en la mano o inventario. El método "tieneCapacidad<T>()"
     *  trata de identificar qué capacidades tiene un item, si puede atacar, talar o 
     *  comerse.
     *  
     *  
     *  1) El archivo JSON: Es solo texto: "potencia": 10.
     *
     *  2) En DTOCapacidad: El JsonConvert lee el 10 y lo guarda en la 
     *  propiedad potencia. En este momento, el objeto es solo un montón de datos.
     *
     *  3) En ItemManager: El if detecta que el tipo es "Talar". Entonces hace: 
     *     new CapacidadTalar(capDTO.potencia).
     *
     *  4) En el Ítem Real (Item): El número 10 ahora vive dentro de una instancia de 
     *     CapacidadTalar, la cual ha sido añadida a la lista capacidades del objeto nuevo.
     *
     *  5) Fin del DTO: El objeto capDTO se pierde porque terminó el bucle. 
     *     Solo nos queda el Item con su lógica de tala lista para usarse.
     */
    internal class Item
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        //public Texture2D textura { get; set; }

        public List<ICapacidad> capacidades {get; set;} = new List<ICapacidad>();
        //public List<DTOCapacidad> capacidades { get; set; } = new List<DTOCapacidad>();

        public Item()
        {

        }
        public bool tieneCapacidad<T>() where T : ICapacidad
        {
            return capacidades.Exists(c => c is T);
        }

    }
}
