---
layout: default
index: true
---

# ScreenManager v1.0.1

<p align="justify">
Este proyecto ha sido desarrollado por <a href="http://www.spoonmangames.cl"><strong>Spoonman Games</strong></a> y es
una de las tantas herramientas para Monogames creada para la construcción de vídeo juegos. Para conocer que otras herramientas tenemos has click <a href="http://www.spoonmangames.cl/download/"><strong>Aquí</strong></a>.
<br><br>
<strong>ScreenManager</strong> permite manejar varias instancias de menú y de escenarios de forma independiente, es un Game State Manager orientado a las Screens. Esta herramienta es re-utilizable en cualquier proyecto y muy fácil de configurar, se define una vez al comienzo del proyecto y luego puede ser usado desde cualquier instancia del mismo.
</p>

Con <strong>ScreenManager</strong> se puede:

* Realizar menú de navegación.
* Crear menú de opciones configurables.
* Paso de Menú a escenarios y viceversa.
* Traspaso entre escenarios.
* Pantalla y acción de Pause.
* Pantalla de "Cargando..."
* Popups.

## Descargar ScreenManager

* [ScreenManager para Monogame 3.4](https://github.com/SpoonmanGames/MonoGame-ScreenManager/releases/tag/v1.0.1)

## ¿Cómo lo uso?

Para configurar e incluir este proyecto en tu vídeo juego te recomendamos partir por esta guía:

* [Como incluir ScreenManager en tu Vídeo Juego]({{ site.baseurl }}/tutoriales/implementacion/).

Luego te recomendamos ver nuestra [lista de tutoriales]({{ site.baseurl }}/tutoriales/).

## Compatibilidades

Actualmente compatible con las siguientes versiones:

 * MonoGame 3.4

## Como contribuir al proyecto

<p align="justify">Este proyecto es código libre, puede acceder al él presionando en el mensaje que sale en la esquina superior derecha de esta página o <a href="https://github.com/SpoonmanGames/MonoGame-ScreenManager/tree/master">desde este link</a>, desde allí puedes hacer Fork del proyecto y si tienes alguna idea nueva o has arreglado algún bug, siéntete libre de un pull request con tus cambios.
<br><br>
Los requisitos para que tu pull request sea aceptado son los siguientes:
</p>

* Todos los cambios hechos son sobre la branch *master*.
* Nuevos métodos públicos comentado con las [directivas de C#](https://msdn.microsoft.com/en-us/library/2d6dt3kf.aspx).
* Sigue los estándares de C#, en particular estas tres páginas:
    * [dofactory](http://www.dofactory.com/reference/csharp-coding-standards): reglas generales.
    * [Lance Hunt Coding Standars](http://se.inf.ethz.ch/old/teaching/ss2007/251-0290-00/project/CSharpCodingStandards.pdf): Naming Conventions (Pág. 3 y Capítulo 2).
    * [Microsoft Coding Conventions](https://msdn.microsoft.com/en-us/library/ff926074.aspx): Para operadores, strings, arrays y LINQ.
* No se ha cambiado el nombre del autor en las clases ya creadas.
* Los archivos README.md y LICENCE no tiene modificaciones.

## Detrás de las escenas

<p align="justify">El proyecto de ScreenManager corresponde a un DrawableGameComponent de Monogame, lo que le permite ser actualizado y dibujado de forma automática, es por ello que este proyecto debe declararse a un nivel mayor en el vídeo juego, de tal forma que maneje todos sus aspectos internos.
<br><br>
El repositorio incluye todas las clases necesarias para su funcionamiento además de clases pre-establecidas para implementar rápidamente menús y escenarios. En caso de querer investigar más a fondo como funciona este proyecto se recomienda entrar al siguiente link: <a href="{{ site.baseurl }}/doc">Documentación del código fuente de ScreenManager</a>.
</p>
