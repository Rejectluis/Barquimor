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

CarlosElHerrero.aprenderHabilidad(HabilidadFactory.crearHabilidad("Ataque"));
CarlosElHerrero.obtenerHabilidad<HabilidadAtaque>().ejecutarHabilidad();

                                // Probando la arquitecutra del sistema de items//
ItemManager.cargarItems("JSON/Herramientas.JSON");

string clave = "espada_de_piedra";

if(ItemManager.catalago.TryGetValue(clave, out Item item))
{
    //Console.WriteLine($"[ITEM]: {item.nombre}");
    //Console.WriteLine($"[ITEM]: {item.descripcion}");
    //Console.WriteLine($"[ITEM CAPACIDADES]: {item.capacidades.Count}");

    foreach (var capacidad in item.capacidades)
    {
        //Console.WriteLine($"Tipo de lógica: {capacidad.GetType().Name}");

        if (capacidad is CapacidadAtaque ataque) { } //Console.WriteLine($"      * Daño detectado: {ataque.danio}");
        if (capacidad is CapacidadTalar talar) { } //Console.WriteLine($"      * Potencia detectada: {talar.potencia}");
        if (capacidad is CapacidadComestible comestible) { } //Console.WriteLine($"      * energía detectada: {comestible.energia}");
    }
    jugador.objetos.Add(clave, item);
}
else
{
    Console.WriteLine($"ERROR: No se encontró el ID {clave} en el catálogo.");
}
                                 // Probando la arquitecutra del sistema de items//

Console.WriteLine($"Nombre del jugador: {jugador.nombre}");
jugador.aprenderHabilidad(HabilidadFactory.crearHabilidad("Ataque"));
jugador.aprenderHabilidad(HabilidadFactory.crearHabilidad("Agricultura"));
jugador.aprenderHabilidad(HabilidadFactory.crearHabilidad("Comercio"));

int hab = jugador.habilidades.Count;

var habAtaque = jugador.obtenerHabilidad<HabilidadAtaque>();
var habComercio = jugador.obtenerHabilidad<HabilidadComercio>(); 
var habAgricultura = jugador.obtenerHabilidad<HabilidadAgricultura>();

Console.WriteLine($"Habilidades aprendidas: {hab} - {habAtaque.tipo} {habAtaque.descripcion} ");
Console.WriteLine($"{habComercio.tipo} {habComercio.descripcion}");
Console.WriteLine($"{habAgricultura.tipo} {habAgricultura.descripcion}");

Console.WriteLine("Items del jugador:");
int itemsInventario = jugador.objetos.Count;
Console.WriteLine($"Total: {itemsInventario}");
Console.WriteLine($"{jugador.objetos[clave].nombre}: {jugador.objetos[clave].descripcion}");

habAtaque.ejecutarHabilidad();
habComercio.ejecutarHabilidad();
habAgricultura.ejecutarHabilidad();
