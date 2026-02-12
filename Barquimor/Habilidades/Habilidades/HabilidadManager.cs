using Barquimor.Componentes.Agricultura;
using Barquimor.Componentes.Ataque;
using Barquimor.Componentes.Comercio;
using Barquimor.Componentes.Curativo;
using Barquimor.Core;
using Barquimor.Entidades.Plantillas;
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
    internal class HabilidadManager : ManagerBase<HabBase, DTOHabilidad>
    {
        public static HabilidadManager Instancia {  get; } = new HabilidadManager();
        private HabilidadManager() { }
        public override HabBase originarDesdePlano(DTOHabilidad dtoHabilidad)
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
                    case nameof(AtaqueJugadorLogic):
                        logicaDeLaHabilidad = new AtaqueJugadorLogic();
                        nuevaHabilidad.logicas.Add(logicaDeLaHabilidad.GetType(), logicaDeLaHabilidad);
                        logicaDeLaHabilidad = null;
                        continue;

                    case nameof(SistemaDeAgriculturaJugadorLogic):
                        logicaDeLaHabilidad = new SistemaDeAgriculturaJugadorLogic();
                        nuevaHabilidad.logicas.Add(logicaDeLaHabilidad.GetType(), logicaDeLaHabilidad);
                        logicaDeLaHabilidad = null;
                        continue;

                    case nameof(SistemaDeComercioJugadorLogic):
                        logicaDeLaHabilidad = new SistemaDeComercioJugadorLogic();
                        nuevaHabilidad.logicas.Add(logicaDeLaHabilidad.GetType(), logicaDeLaHabilidad);
                        logicaDeLaHabilidad = null;
                        continue;

                    case nameof(SistemaCurativoJugadorLogic):
                        logicaDeLaHabilidad = new SistemaCurativoJugadorLogic();
                        nuevaHabilidad.logicas.Add(logicaDeLaHabilidad.GetType(), logicaDeLaHabilidad);
                        logicaDeLaHabilidad = null;
                        continue;
                }
            }
            return nuevaHabilidad;
        }
    }
}
