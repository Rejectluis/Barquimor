using Barquimor.Entidades;
using Barquimor.Entidades.Plantillas;
using Barquimor.Habilidades.CreadorDeHabilidades;
using Barquimor.Items.Capacidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

    /*
     *  Esta clase se encarga de crear un item a partir de un archivo JSON. Sus métodos son
     *  estáticos porque no se necesita una instancia, simplemente acceder a los métodos.
     */
namespace Barquimor.Items.Items
{
    internal class ItemManager : ManagerBase<Item, DTOItemRow>
    {
        public static ItemManager Instancia {  get; } = new ItemManager();
        public static Dictionary<string, Item> catalago = new Dictionary<string, Item>();   //  Contiene los items instanciados 
        private ItemManager() { }
        public override Item originarDesdePlano(DTOItemRow item)
        {
            Item nuevoItem = new Item
            {
                id = item.id,
                nombre = item.nombre,
                descripcion = item.descripcion,
                capacidades = new()
            };

            foreach (var dto in item.capacidades)
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
