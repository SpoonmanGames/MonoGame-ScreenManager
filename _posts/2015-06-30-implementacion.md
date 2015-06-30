---
layout: post
title: Como incluir ScreenManager en tu Vídeo Juego
category:
- tutoriales
summary: Acá podrás entender como implementar este proyecto dentro de tu juego sin romper nada. ¡Si algo se rompe fueron los duendes!
---

Esta guía está basada en la última versión liberada de ScreenManager, la cuaĺ puedes descargar desde el [repositorio oficial](https://github.com/SpoonmanGames/MonoGame-ScreenManager/releases), por favor revisar bien en que IDE se encuentra ese release ya que esta guía estará hecha para funcionar en dicha plataforma.

En esta guía se asumen que deseas incluir este proyecto en la misma carpeta que la de tu vídeo juego, en caso de no ser así te recomiendo tener especial cuidado al incluirlo en tu solución y al agregar las referencias.

Se usará como proyecto de referencia a "Proyecto Tutorial", el cual representará durante esta guía tu vídeo juego o proyecto Monogame previamente creado.

Pro Tip: Si quieres mantener este proyecto actualizado con la última versión te recomendamos usar [Git](https://git-scm.com/) con [Git Clone](http://git-scm.com/docs/git-clone) o bien con [Git Submodules](https://git-scm.com/book/es/v2/Git-Tools-Submodules) si tu proyecto ya está en un repositorio.

# 1.- Agregar proyecto a la solución de Visual Studio

Es importante que **ScreenManager** esté en la carpeta del proyecto de tu vídeo juego.

<p align="center"><img src="{{ site.baseurl }}/images/01-implementacion.png" /></p>

Luego, en Visual Studio 2013, se debe agregar el proyecto a la solución existente presionando botón derecho en la carpeta del juego, luego en agregar y finalmente en agregar existente.

<p align="center"><img src="{{ site.baseurl }}/images/02-implementacion.gif" /></p>

En la ventana abierta se debe seleccionar el archivo ScreenManager.csproj ubicado en MonogameScreenManager/

<p align="center"><img src="{{ site.baseurl }}/images/03-implementacion.gif" /></p>

De forma que el proyecto agregado se verá de la siguiente forma en Visual Studio 2013.

<p align="center"><img src="{{ site.baseurl }}/images/04-implementacion.png" /></p>

Se tiene que agregar la referencia a **ScreenManager** a el proyecto Windows 8.1 y Windows Phone 8.1 (el siguiente gif solo muestra para Windows 8.1, lo mismo se debe hacer para Windows Phone 8.1)

<p align="center"><img src="{{ site.baseurl }}/images/05-implementacion.gif" /></p>

En la ventana abierta se debe seleccionar el proyecto de **ScreenManager** para vincularlos.

<p align="center"><img src="{{ site.baseurl }}/images/06-implementacion.gif" /></p>

Esto provocara que en la lista de referencias esté listado **ScreenManager** como se puede ver en la siguiente imagen.

<p align="center"><img src="{{ site.baseurl }}/images/07-implementacion.png" /></p>

Lo siguiente es abrir el archivo inicial del proyecto (usualmente llamado Game1.cs en el proyecto Shared) y agregar el siguiente atributo a la clase.

<pre class="prettyprint">
    <code class="language-cs">
        ScreenManager.ScreenManager screenManager;
    </code>
</pre>

El constructor de Game1 debe tener al menos los siguientes elementos.

<pre class="prettyprint">
    <code class="language-cs">
        public Game1()
        {
          graphics = new GraphicsDeviceManager(this);
          Content.RootDirectory = "Content";

          // Crea el ScreenManager
          screenManager = new ScreenManager.ScreenManager(this);
         
          // Añade el ScreenManager a los componentes del juego
          Components.Add(screenManager);
        }
    </code>
</pre>

Esto provocará que en cada frame del video juego, los metodos Update y Draw de **ScreenManager** serán llamados.