using Barquimor.Core;
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
        public Dictionary<Type, Object> habilidades;
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
            this.habilidades = new Dictionary<Type, Object>();
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
            var tipo = nuevaHabilidad.GetType();

            if (habilidades.ContainsKey(tipo)) { return; }

            habilidades.Add(tipo, nuevaHabilidad);
        }

        public T obtenerHabilidad<T>() where T : class
        {
            if (habilidades.TryGetValue(typeof(T), out object habilidad)) { return habilidad as T; }

            return null;
        }




    }
}
