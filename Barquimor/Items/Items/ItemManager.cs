using Barquimor.Entidades;
using Barquimor.Entidades.Plantillas;
using Barquimor.Items.Capacidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Items.Items
{
    internal class ItemManager
    {
        public static Dictionary<string, Item> catalago = new Dictionary<string, Item>();
        public static void cargarItems(string rutaArchivo)
        {
            string jsonTexto = File.ReadAllText(rutaArchivo);

            var listaRaw = JsonConvert.DeserializeObject<List<DTOItemRow>>(jsonTexto);

            foreach (var dto in listaRaw)
            {
                Item nuevoItem = new Item { 
                    id = dto.id,
                    nombre = dto.nombre, 
                    descripcion = dto.descripcion
                };

                foreach (var capDTO in dto.capacidades)
                {
                    if(capDTO.tipo.Equals("Ataque")) {nuevoItem.capacidades.Add(new CapacidadAtaque(capDTO.danio));}

                    if(capDTO.tipo.Equals("Talar")) {nuevoItem.capacidades.Add(new CapacidadTalar(capDTO.potencia));}

                    if (capDTO.tipo.Equals("Comestible")) {nuevoItem.capacidades.Add(new CapacidadComestible(capDTO.energia));}
                }
                catalago.Add(dto.id, nuevoItem);
            }
        }

        public static void agregarItem(string clave, PersonajeBase jugador)
        {
            if (ItemManager.catalago.TryGetValue(clave, out Item item))
            {
                Console.WriteLine($"[ITEM]: {item.nombre}");
                Console.WriteLine($"[ITEM]: {item.descripcion}");
                Console.WriteLine($"[ITEM CAPACIDADES]: {item.capacidades.Count}");

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
