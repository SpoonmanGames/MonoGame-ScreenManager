# ScreenManager Para MonoGame

Este proyecto permite manejar varias instancias de menú y de escenarios de forma independiente, es un Game State Manager orientado
a las Screens. El ScreenManager Proyect es un GameComponent reutilizable en cualquier proyecto y muy fácil de configurar, se define
una vez al comienzo del proyecto y luego puede ser usado desde cualquier instancia del juego mismo.

Dentro de las opciones posibles a realizar con el ScreenManager tenemos:

* Realizar menú de navegación.
* Crear menú de opciones configurables.
* Paso de Menú a escenarios y viceversa.
* Traspaso entre escenarios.
* Pantalla y ación de Pause.
* Pantalla de "Cargando..."
* Popups.

# Descargar ScreenManager

//TODO

# Configurar ScreenManager en tu proyecto

//TODO

# Compatibilidades

Actualmente compatible con las siguientes versiones:

 * MonoGame 3.4

# Como contribuir al proyecto

¿Tienes alguna idea o has arreglado algún bug? Sientete libre de hacer un [Fork]() del proyecto y luego hacer un pull request ;)
Los requisitos para que tu pull request sea aceptado son los siguientes:

* Nuevos metodos publicos comentado con las [directivas de C#](https://msdn.microsoft.com/en-us/library/2d6dt3kf.aspx).
* Sigue los estandares de C#, en particular estas tres páginas:
	* [dofactory](http://www.dofactory.com/reference/csharp-coding-standards): reglas generales.
	* [Lance Hunt Coding Standars](http://se.inf.ethz.ch/old/teaching/ss2007/251-0290-00/project/CSharpCodingStandards.pdf): Naming Conventions (Pág 3 y Capítulo 2).
	* [Microsoft Coding Conventions](https://msdn.microsoft.com/en-us/library/ff926074.aspx): Para operadores, strings, arrays y LINQ.
* No se ha cambiado el nombre del autor en las clases ya creadas.
* Los archivo README.mdt LICENCE no tiene modificaciones.

# Detras de las escenas

El proyecto de ScreenManager corresponde a un DrawableGameComponent de Monogame, lo que le permite ser actualizado y dibujado de forma automática, es por ello
que este proyecto debe declararse a un nivel mayor en el vídeo juego, de tal forma que maneje todos sus aspectos internos.

el repositorio incluye todas las clases necesarias para su funcionamiento además de clases pre-establecidas para implementar rápidamente menús y escenarios, en caso de
querer investigar más a fondo como funciona este proyecto se recomienda entrar al siguiente link: [Estructura de ScreenManager]()

# Copyrights

Este código fuente está ofrecido bajo la licencia MIT y ha sido desarrollado por Spoonman Games para usarse principalmente en proyectos
MonoGames 2D. Naturalmente se seguirá dando soporte a este repositorio siempre y cuándo SG lo siga usando.
El proyecto en sí es una mejora del proyecto de [XBOXLIVE indie games: Game State Management](http://xbox.create.msdn.com/en-US/education/catalog/sample/game_state_management).

La página de presentación del repositorio está construida con [Jekyll Now](https://github.com/Theby/jekyll-now).