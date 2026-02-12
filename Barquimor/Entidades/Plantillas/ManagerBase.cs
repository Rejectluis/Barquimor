using Barquimor.Core;
using Barquimor.Habilidades.CreadorDeHabilidades;
using Barquimor.Items.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Entidades.Plantillas
{
    internal abstract class ManagerBase<T_Objeto, T_DTO> where T_DTO: IDTOBase
    {
        protected static Dictionary<string, T_DTO> planos = new();

        /*
         * Es el encargado de inicializar el JSON. Simplemente lo lee y lo guarda en el diccionario
         * 'planos'. Ahí se almacenan los datos del archivo para posteriormente buscar un id e
         * instanciar un objeto.
         */
        public void inicializar(string ruta)
        {
            string json = File.ReadAllText(ruta);
            var datosJson = JsonConvert.DeserializeObject<List<T_DTO>>(json);

            foreach (var dto in datosJson)
            {
                planos[dto.id] = dto;
            }
        }

        /*
         *  Este método se dividió en dos partes para comodidad. El método que verdaderamente crea
         *  la habilidad se llama 'originarDesdePlano', y está debajo de este.
         *  
         *  Su función es buscar el id en los planos, si lo encuentra llama al 
         *  segundo método que realmente instancia una habilidad, si no retorna un null.
         */
        public T_Objeto crear(string idItem)
        {
            if (!planos.TryGetValue(idItem, out var dto)) { return default; }

            return originarDesdePlano(dto);
        }

        /*
         *  Este método instancia el objeto con los datos que se le envió desde la primera parte.
         *  Luego evalúa cuáles son los tipos de lógicas que tiene el objeto creado, con base a eso 
         *  las asigna.
         */
        public abstract T_Objeto originarDesdePlano(T_DTO dtoHabilidad);
    }
}
