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

                    if (capDTO.tipo.Equals("Comer")) {nuevoItem.capacidades.Add(new CapacidadComestible(capDTO.energia));}
                }
                catalago.Add(dto.id, nuevoItem);
            }
        }
    }
}
