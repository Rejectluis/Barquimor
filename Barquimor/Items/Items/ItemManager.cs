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
                Item nuevo = new Item { 
                    id = dto.id,
                    nombre = dto.nombre, 
                    descripcion = dto.descripcion
                };

                foreach (var capDTO in dto.capacidades)
                {
                    if(capDTO.tipo == "Ataque")
                    {
                        nuevo.capacidades.Add(new CapacidadAtaque(capDTO.danio));
                    }

                    if(capDTO.tipo == "Talar")
                    {
                        nuevo.capacidades.Add(new CapacidadTalar(capDTO.potencia));
                    }
                }
                catalago.Add(dto.id, nuevo);
            }
        }
    }
}
