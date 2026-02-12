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
using Barquimor.Habilidades.CreadorDeHabilidades;
using Barquimor.Items.Capacidades;
using Barquimor.Items.Items;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

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

                                //  Inicialización de los JSON   //
HabilidadManager.Instancia.inicializar("JSON/Habilidades.JSON");
ItemManager.Instancia.inicializar("JSON/Herramientas.JSON");

// probando la lógica de habilidades en NPCS    //
CarlosElHerrero.aprenderHabilidad(HabilidadManager.Instancia.crear("habilidad_ataque"));
CarlosElHerrero.aprenderHabilidad(HabilidadManager.Instancia.crear("habilidad_agricultura"));

                                // Probando la arquitecutra del sistema de items    //
Console.WriteLine("\n");
string clave = "hacha_de_piedra";
ItemManager.Instancia.crear(clave);
ItemManager.agregarItem(clave, jugador);

// Probando la arquitectura de logicas //
Console.WriteLine("\n");
Console.WriteLine($"Nombre del jugador: {jugador.nombre}");
jugador.aprenderHabilidad(HabilidadManager.Instancia.crear("habilidad_ataque"));
jugador.aprenderHabilidad(HabilidadManager.Instancia.crear("habilidad_agricultura"));
jugador.aprenderHabilidad(HabilidadManager.Instancia.crear("habilidad_comerciante"));
jugador.aprenderHabilidad(HabilidadManager.Instancia.crear("habilidad_curativa"));
jugador.aprenderHabilidad(HabilidadManager.Instancia.crear("habilidad_especial"));


int hab = jugador.habilidades.Count;

if (hab ==0) { Console.WriteLine("Las habilidades son cero. No se puede continuar con el programa."); Environment.Exit(0); }

var habAtaque = jugador.obtenerHabilidad("habilidad_ataque");
var habComercio = jugador.obtenerHabilidad("habilidad_comerciante");
var habAgricultura = jugador.obtenerHabilidad("habilidad_agricultura");
var habCurativa = jugador.obtenerHabilidad("habilidad_curativa");
var habEspecial = jugador.obtenerHabilidad("habilidad_especial");

Console.WriteLine($"Habilidades aprendidas: {hab} \n{habAtaque.nombre} {habAtaque.descripcion} ");
Console.WriteLine($"{habAgricultura.nombre} {habAgricultura.descripcion}");
Console.WriteLine($"{habComercio.nombre} {habComercio.descripcion}");
Console.WriteLine($"{habCurativa.nombre} {habCurativa.descripcion}");
Console.WriteLine($"{habEspecial.nombre} {habEspecial.descripcion}");

Console.WriteLine("\n");
Console.WriteLine("Items del jugador:");
Console.WriteLine($"Total: {jugador.objetos.Count}");
Console.WriteLine($"{jugador.objetos[clave].nombre}: {jugador.objetos[clave].descripcion}");

Console.WriteLine("\n");

jugador.obtenerHabilidad("habilidad_ataque").ejecutarHabilidad();
jugador.obtenerHabilidad("habilidad_agricultura").ejecutarHabilidad();
jugador.obtenerHabilidad("habilidad_comerciante").ejecutarHabilidad();
jugador.obtenerHabilidad("habilidad_curativa").ejecutarHabilidad();
jugador.obtenerHabilidad("habilidad_especial").ejecutarHabilidad();