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
CarlosElHerrero.aprenderHabilidad(HabilidadFactory.crearHabilidad("Agricultura"));
CarlosElHerrero.obtenerHabilidad<HabilidadAtaque>().ejecutarHabilidad();
CarlosElHerrero.obtenerHabilidad<HabilidadAgricultura>().ejecutarHabilidad();

Console.WriteLine("\n");
                                // Probando la arquitecutra del sistema de items//
ItemManager.cargarItems("JSON/Herramientas.JSON");
string clave = "hacha_de_piedra";
ItemManager.agregarItem(clave, jugador);

                                 // Probando la arquitectura de habilidades//

Console.WriteLine("\n");
Console.WriteLine($"Nombre del jugador: {jugador.nombre}");
jugador.aprenderHabilidad(HabilidadFactory.crearHabilidad("Ataque"));
jugador.aprenderHabilidad(HabilidadFactory.crearHabilidad("Agricultura"));
jugador.aprenderHabilidad(HabilidadFactory.crearHabilidad("Comercio"));

int hab = jugador.habilidades.Count;

var habAtaque = jugador.obtenerHabilidad<HabilidadAtaque>();
var habComercio = jugador.obtenerHabilidad<HabilidadComercio>(); 
var habAgricultura = jugador.obtenerHabilidad<HabilidadAgricultura>();

Console.WriteLine($"Habilidades aprendidas: {hab} \n{habAtaque.tipo} {habAtaque.descripcion} ");
Console.WriteLine($"{habComercio.tipo} {habComercio.descripcion}");
Console.WriteLine($"{habAgricultura.tipo} {habAgricultura.descripcion}");

Console.WriteLine("\n");
Console.WriteLine("Items del jugador:");
int itemsInventario = jugador.objetos.Count;
Console.WriteLine($"Total: {itemsInventario}");
Console.WriteLine($"{jugador.objetos[clave].nombre}: {jugador.objetos[clave].descripcion}");

habAtaque.ejecutarHabilidad();
habComercio.ejecutarHabilidad();
habAgricultura.ejecutarHabilidad();
