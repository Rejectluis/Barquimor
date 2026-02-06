using Barquimor.Componentes.Agricultura;
using Barquimor.Componentes.Ataque;
using Barquimor.Componentes.Comercio;
using Barquimor.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

    /*
     *  Esta clase se encarga de crear una habilidad a partir de un archivo JSON. Sus métodos son
     *  estáticos porque no se necesita una instancia, simplemente acceder a sus métodos.
     */
namespace Barquimor.Habilidades.CreadorDeHabilidades
{
    internal class HabilidadManager
    {
        public static Dictionary<string, DTOHabilidad> planos = new();

        /*
         * Es el encargado de inicializar el JSON. Simplemente lo lee y lo guarda en el diccionario
         * 'planos'. Ahí se almacenan los datos del archivo para posteriormente buscar un id e
         * instanciar un objeto.
         */
        public static void inicializar(string ruta)
        {
            string json = File.ReadAllText(ruta);
            var datosJson = JsonConvert.DeserializeObject<List<DTOHabilidad>> (json);

            foreach (var dto in datosJson)
            {
                planos[dto.id] = dto;
            }
        }

        /*
         *  Este método se dividió en dos partes para comodidad. El método que verdaderamente crea
         *  la habilidad se llama 'originarHabilidadDesdePlano', y está debajo de este.
         *  
         *  Su función es buscar el id en el diccionario de habilidades, si lo encuentra llama al 
         *  segundo método que realmente instancia una habilidad, si no retorna un null.
         */
        public static IHabilidad crearHabilidad(string idHabilidad)
        {
            if (!planos.TryGetValue(idHabilidad, out var dto)) { return null; }

            return originarHabilidadDesdePlano(dto);

        }

        /*
         *  Este método instancia la habilidad con los datos que se le envió desde la primera parte.
         *  Luego evalúa cuáles son los tipos de lógica que tiene la habilidad creada, con base a eso 
         *  las asigna.
         *  
         */
        private static HabBase originarHabilidadDesdePlano(DTOHabilidad dtoHabilidad)
        {
            ILogicaHab logicaDeLaHabilidad;

            HabBase nuevaHabilidad = new HabBase
            {
                id = dtoHabilidad.id,
                nombre = dtoHabilidad.nombre,
                descripcion = dtoHabilidad.descripcion,
                nivel = 1,
                experiencia = 0,
                logicas = new()

            };

            foreach (var dtoLogica in dtoHabilidad.tipoDeLogica)
            {
                /*
                 *      Nota: Este switch es sólo para probar. A futuro, habría que cambiarlo y 
                 *      usar código más eficiente y limpio.
                 */
                switch (dtoLogica.tipo)
                {
                    case "AtaqueJugadorLogic": 
                        logicaDeLaHabilidad = new AtaqueJugadorLogic();
                        nuevaHabilidad.logicas.Add(logicaDeLaHabilidad.GetType(), logicaDeLaHabilidad);
                        logicaDeLaHabilidad = null;
                    break;

                    case "SistemaDeAgriculturaJugadorLogic":
                        logicaDeLaHabilidad = new SistemaDeAgriculturaJugadorLogic();
                        nuevaHabilidad.logicas.Add(logicaDeLaHabilidad.GetType(), logicaDeLaHabilidad);
                        logicaDeLaHabilidad = null;
                    break;

                    case "SistemaDeComercioJugadorLogic":
                        logicaDeLaHabilidad = new SistemaDeComercioJugadorLogic();
                        nuevaHabilidad.logicas.Add(logicaDeLaHabilidad.GetType(), logicaDeLaHabilidad);
                        logicaDeLaHabilidad = null;
                    break;
                }
            }
            return nuevaHabilidad;
        }
    }
}
