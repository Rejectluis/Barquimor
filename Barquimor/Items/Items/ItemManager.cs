using Barquimor.Entidades;
using Barquimor.Entidades.Plantillas;
using Barquimor.Habilidades.CreadorDeHabilidades;
using Barquimor.Items.Capacidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*
     *  Esta clase se encarga de crear un item a partir de un archivo JSON. Sus métodos son
     *  estáticos porque no se necesita una instancia, simplemente acceder a los métodos.
     */
namespace Barquimor.Items.Items
{
    internal class ItemManager
    {
        public static Dictionary<string, DTOItemRow> planos = new();                        //  Contine los datos del JSON
        public static Dictionary<string, Item> catalago = new Dictionary<string, Item>();   //  Contiene los items instanciados 

        /*
         * Es el encargado de inicializar el JSON. Simplemente lo lee y lo guarda en el diccionario
         * 'planos'. Ahí se almacenan los datos del archivo para posteriormente buscar un id e
         * instanciar un objeto.
         */
        public static void inicializar(string rutaJson)
        {
            string json = File.ReadAllText(rutaJson);
            var datos = JsonConvert.DeserializeObject<List<DTOItemRow>>(json);

            foreach(var item in datos )
            {
                planos[item.id] = item;
            }
        }

        /*
         *  Este método se dividió en dos partes para comodidad. El método que verdaderamente crea
         *  la habilidad se llama 'originarHabilidadDesdePlano', y está debajo de este.
         *  
         *  Su función es buscar el id en los planos. Si lo encuentra; llama al 
         *  segundo método que realmente instancia una habilidad, si no; retorna un null.
         */
        public static Item crearItem(string idItem)
        {
            if (planos.TryGetValue(idItem, out var DTOitem)) { return originarItemDesdePlano(DTOitem); }

            return null;
        }

        /*
         *  Este método instancia el item con los datos que se le envió desde la primera parte.
         *  Luego evalúa cuáles son los tipos de lógica que posee el item, con base a eso 
         *  los asigna al objeto.
         *  
         */
        private static Item originarItemDesdePlano(DTOItemRow item)
        {
            Item nuevoItem = new Item
            {
                id = item.id,
                nombre = item.nombre,
                descripcion = item.descripcion,
                capacidades = new()
            };
            
            foreach(var dto in item.capacidades)
            {
                if (dto.tipo.Equals("Ataque")) { nuevoItem.capacidades.Add(new CapacidadAtaque(dto.danio)); }

                if (dto.tipo.Equals("Talar")) { nuevoItem.capacidades.Add(new CapacidadTalar(dto.potencia)); }

                if (dto.tipo.Equals("Comestible")) { nuevoItem.capacidades.Add(new CapacidadComestible(dto.energia)); }
            }
            catalago.Add(item.id, nuevoItem);
            return nuevoItem;
        }

        /*
         *  La única función de esta clase es agregar los items al catálogo de objetos que el jugador
         *  tiene en su inventario. Se agregaron mensajes para ver las características del item agregado.
         */
        public static void agregarItem(string clave, PersonajeBase jugador)
        {
            if (ItemManager.catalago.TryGetValue(clave, out Item item))
            {
                Console.WriteLine($"[ITEM]: {item.nombre}");
                Console.WriteLine($"[ITEM]: {item.descripcion}");
                Console.WriteLine($"[ITEM LÓGICAS]: {item.capacidades.Count}");

                foreach (var capacidad in item.capacidades)
                {
                    Console.WriteLine($"Tipo de lógica: {capacidad.GetType().Name}");

                    if (capacidad is CapacidadAtaque ataque) { Console.WriteLine($"      * Daño detectado: {ataque.danio}"); } //Console.WriteLine($"      * Daño detectado: {ataque.danio}");
                    if (capacidad is CapacidadTalar talar) { Console.WriteLine($"      * Potencia detectada: {talar.potencia}"); } //Console.WriteLine($"      * Potencia detectada: {talar.potencia}");
                    if (capacidad is CapacidadComestible comestible) { Console.WriteLine($"      * energía detectada: {comestible.energia}"); } //Console.WriteLine($"      * energía detectada: {comestible.energia}");
                }
                jugador.objetos.Add(clave, item);
            }
            else
            {
                Console.WriteLine($"ERROR: No se encontró el ID {clave} en el catálogo.");
            }
        }

    }
}
