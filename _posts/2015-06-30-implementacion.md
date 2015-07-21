---
layout: post
title: Como incluir ScreenManager en tu Vídeo Juego
category:
- tutoriales
summary: Acá podrás entender como implementar este proyecto dentro de tu juego sin romper nada. ¡Si algo se rompe fueron los duendes!
---

<p class="ribbon-alert b-red" align="justify"><strong>Alerta:</strong> Esta guía está basada en la última versión liberada de ScreenManager, la cual puedes descargar desde el <a href="https://github.com/SpoonmanGames/MonoGame-ScreenManager/releases">repositorio oficial</a>, por favor revisar bien en que IDE se encuentra ese release ya que esta guía estará hecha para funcionar en dicha plataforma.</p>

<p class="ribbon-alert b-blue" align="justify"><strong>Antes de empezar:</strong> En esta guía se asumen que deseas incluir este proyecto en la misma carpeta que la de tu vídeo juego, en caso de no ser así te recomiendo tener especial cuidado al incluirlo en tu solución y al agregar las referencias.</p>

<p class="ribbon-alert b-blue" align="justify"><strong>Antes de empezar:</strong> Se usará como proyecto de referencia a "Proyecto Tutorial", el cual representará durante esta guía tu vídeo juego o proyecto Monogame previamente creado.</p>

<p class="ribbon-alert b-green" align="justify"><strong>Pro Tip:</strong> Si quieres mantener este proyecto actualizado con la última versión te recomendamos usar <a href="https://git-scm.com/">Git</a> con <a href="http://git-scm.com/docs/git-clone">Git Clone</a> o bien con <a href="https://git-scm.com/book/es/v2/Git-Tools-Submodules">Git Submodules</a> si tu proyecto ya está en un repositorio.</p>

## 1.- Agregar proyecto a la solución de Visual Studio

Es importante que **ScreenManager** esté en la carpeta del proyecto de tu vídeo juego.

<p align="center"><img src="{{ site.baseurl }}/images/01-implementacion.png" /></p>

Luego, en Visual Studio 2013, se debe agregar el proyecto a la solución existente presionando botón derecho en la carpeta del juego, luego en agregar y finalmente en agregar existente.

<p align="center"><img src="{{ site.baseurl }}/images/02-implementacion.gif" /></p>

En la ventana abierta se debe seleccionar el archivo ScreenManager.csproj ubicado en MonogameScreenManager/

<p align="center"><img src="{{ site.baseurl }}/images/03-implementacion.gif" /></p>

De forma que el proyecto agregado se verá de la siguiente forma en Visual Studio 2013.

<p align="center"><img src="{{ site.baseurl }}/images/04-implementacion.png" /></p>

Se tiene que agregar la referencia a **ScreenManager** al proyecto Windows 8.1 y Windows Phone 8.1 (el siguiente gif solo muestra para Windows 8.1, lo mismo se debe hacer para Windows Phone 8.1)

<p align="center"><img src="{{ site.baseurl }}/images/05-implementacion.gif" /></p>

En la ventana abierta se debe seleccionar el proyecto de **ScreenManager** para vincularlos.

<p align="center"><img src="{{ site.baseurl }}/images/06-implementacion.gif" /></p>

Esto provocara que en la lista de referencias esté listado **ScreenManager** como se puede ver en la siguiente imagen.

<p align="center"><img src="{{ site.baseurl }}/images/07-implementacion.png" /></p>

## 2.- Agregar código fuente

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

Esto provocará que en cada frame del video juego los métodos Update() y Draw() de **ScreenManager** serán llamados.

## 3.- Agregar Assets necesarios

**ScreenManager** usa unas fuentes llamadas GameFontm una textura llamada blank y una gradiente llamada PopupGradient, ambas están adjuntas en la descarga del proyecto y deben agregarse al vídeo juego mediante el Content Manger de Monogame.

Para este caso basta hacerlo una sola vez, ya sea en Windows 8.1 o en Windows Phone para que el contenido se agregué a ambos. Abra el Content Manager de Windows 8.1 con doble click donde muestra la imagen.

<p align="center"><img src="{{ site.baseurl }}/images/08-implementacion.png" /></p>

Luego agregue tres carpetas llamadas Font, Gradientes y Texturas.

<p align="center"><img src="{{ site.baseurl }}/images/09-implementacion.gif" /></p>

Finalmente a cada carpeta agregue los assets correspondientes de tal forma que se vea como la siguiente imagen (debe seleccionar agregar item existente), para luego hacer un build de los assets.

<p align="center"><img src="{{ site.baseurl }}/images/10-implementacion.gif" /></p>

Si al momento de agregar los assets le pregunta si desea copiar los archivos o hacer un link a ellos, puede elegir la que más le acomode, aunque recomendamos copiar los archivos para tener todos sus assets en un lugar centralizado.

## 4.- Listo!

Ya puedes compilar e iniciar el juego sin ningún problema, al hacerlo notaras que no hay ningún cambio sustancial en tú vídeo juego, esto es debido a que aunque **ScreenManager** esta apropiadamente configurado e implementado aún no hacemos uso de sus funcionalidades.

## 5.- ¿Dónde continuar?

Desde aquí puedes implementar de muchas maneras diferentes a **ScreenManager** te invitamos a revisar [nuestros tutoriales]({{ site.baseurl }}/tutoriales/) para darte una idea de dónde empezar y como usar esta herramienta.

