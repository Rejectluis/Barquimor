using Barquimor.Componentes.Colisionado;
using Barquimor.Componentes.Comercio;
using Barquimor.Componentes.Dibujado;
using Barquimor.Core;
using Barquimor.Entidades;
using Barquimor.Entidades.Moviles;
using Barquimor.Habilidades;
using Barquimor.Habilidades.Agricultura;
using Barquimor.Habilidades.Ataques;
using Barquimor.Habilidades.Comercios;
using Barquimor.Items.Capacidades;
using Barquimor.Items.Items;
using System;
using System.Text.Json.Nodes;

using var game = new Barquimor.Game1();
//game.Run();

                                  // Probando la arquitecutra del NPC//
IComerciar comercio = new SistemaDeComercioNPCLogic();
IDibujar dibujo = new RenderizadoEstandarLogic();
IColisionar colision = new ColisionarRectanguloLogic();

Herrero CarlosElHerrero = new Herrero("Carlos el herrero",comercio, dibujo, colision);
Jugador jugador = new Jugador("Rejectluis", dibujo, colision);

CarlosElHerrero.activarComercio();
CarlosElHerrero.desactivarComercio();
CarlosElHerrero.ejecutarRender();
CarlosElHerrero.ejecutarColision();

                                // Probando la arquitecutra del sistema de items//
ItemManager.cargarItems("JSON/Herramientas.JSON");

if(ItemManager.catalago.TryGetValue("espada_de_piedra", out Item hacha))
{
    //Console.WriteLine($"[HACHA]: {hacha.nombre}");
    //Console.WriteLine($"[HACHA]: {hacha.descripcion}");
    //Console.WriteLine($"[HACHA CAPACIDADES]: {hacha.capacidades.Count}");

    foreach (var capacidad in hacha.capacidades)
    {
        //Console.WriteLine($"Tipo de lógica: {capacidad.GetType().Name}");

        if (capacidad is CapacidadAtaque ataque)
        {
            //Console.WriteLine($"      * Daño detectado: {ataque.danio}");
        }

        if (capacidad is CapacidadTalar talar)
        {
            //Console.WriteLine($"      * Potencia detectada: {talar.potencia}");
        }
    }
    jugador.objetos.Add("hacha_de_piedra", hacha);
}
else
{
    Console.WriteLine("ERROR: No se encontró el ID 'hacha_de_piedra' en el catálogo.");
}
                                 // Probando la arquitecutra del sistema de items//

Console.WriteLine($"Nombre del jugador: {jugador.nombre}");
jugador.aprenderHabilidad(HabilidadFactory.crearHabilidad("Ataque"));
jugador.aprenderHabilidad(HabilidadFactory.crearHabilidad("Agricultura"));
jugador.aprenderHabilidad(HabilidadFactory.crearHabilidad("Comercio"));

int hab = jugador.habilidades.Count >= 1 ? jugador.habilidades.Count : 0;

var habAtaque = jugador.obtenerHabilidad<HabilidadAtaque>();
var habComercio = jugador.obtenerHabilidad<HabilidadComercio>(); 
var habAgricultura = jugador.obtenerHabilidad<HabilidadAgricultura>();

Console.WriteLine($"Habilidades aprendidas: {hab} - {habAtaque.tipo} {habAtaque.descripcion} ");
Console.WriteLine($"{habComercio.tipo} {habComercio.descripcion}");
Console.WriteLine($"{habAgricultura.tipo} {habAgricultura.descripcion}");

Console.WriteLine("Items del jugador:");
int itemsInventario = jugador.objetos.Count;
Console.WriteLine($"Total: {itemsInventario}");
Console.WriteLine($"{jugador.objetos["hacha_de_piedra"].nombre}: {jugador.objetos["hacha_de_piedra"].descripcion}");

habAtaque.ejecutarHabilidad();
habComercio.ejecutarHabilidad();
habAgricultura.ejecutarHabilidad();
