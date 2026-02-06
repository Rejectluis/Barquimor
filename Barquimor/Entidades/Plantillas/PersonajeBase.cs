using Barquimor.Core;
using Barquimor.Habilidades.CreadorDeHabilidades;
using Barquimor.Items.Items;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Barquimor.Entidades.Plantillas
{
    internal abstract class PersonajeBase : IActualizar
    {
        public Dictionary<string, IHabilidad> habilidades { get; set; }
        public Dictionary<string, Item> objetos { get; set; }
        public string nombre { get; set; }
        protected int vida { get; set; }
        protected Texture2D skin { get; set; }
        protected Vector2 posicion { get; set; }
        protected Vector2 velocidad { get; set; }
        protected IDibujar renderizador { get; set; }
        protected IColisionar colision { get; set; }

        public PersonajeBase(string nombre, IDibujar renderizador, IColisionar colision)
        {
            this.nombre = nombre;
            this.vida = 100;
            this.posicion = Vector2.Zero;
            this.velocidad = Vector2.Zero;
            this.renderizador = renderizador;
            this.colision = colision;
            this.habilidades = new Dictionary<string, IHabilidad>();
            this.objetos = new Dictionary<string, Item>();
        }

        public virtual void ejecutarRender()
        {
            renderizador.dibujar();
        }
        public virtual void ejecutarColision()
        {
            this.colision.colisionar();
        }
        public virtual void actualizar()
        {

        }

        public void aprenderHabilidad(IHabilidad nuevaHabilidad)
        {
            if (nuevaHabilidad is HabBase hab) 
            {
                if (habilidades.ContainsKey(hab.id)) { return; }

                habilidades.Add(hab.id, hab);
            }

        }

        public T obtenerHabilidad<T>() where T : class
        {
            return habilidades.Values.OfType<T>().FirstOrDefault();

        }

        public HabBase obtenerHabilidad(string idHabilidad)
        {
            if (habilidades.TryGetValue(idHabilidad, out var h))
            {
                return (HabBase)h;
            }
            return null;
        }





    }
}
