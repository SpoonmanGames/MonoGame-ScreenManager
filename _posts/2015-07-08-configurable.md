---
layout: post
title: Crear un Menú con opciones configurables
category:
- tutoriales
summary: En este tutorial aprenderás a crear un menú con opciones variadas y valores diferentes que pueden ser configurables directamente en el menú.
---

<p class="ribbon-alert b-blue" align="justify"><strong>Antes de empezar:</strong> Se recomienda tener configurado el proyecto según se especifica en la guía <a href="http://www.spoonmangames.cl/MonoGame-ScreenManager/tutoriales/implementacion/">Como incluir ScreenManager en tu Vídeo Juego</a>.</p>

<p class="ribbon-alert b-blue" align="justify"><strong>Antes de empezar:</strong> Se recomienda haber leído o hecho el tutorial de <a href="http://www.spoonmangames.cl/MonoGame-ScreenManager/tutoriales/menupantallas/">Crear un Menú con varias pantallas</a> ya que aquí se continuará dicho tutorial.</p>

En este tutorial implementaremos un menú con opciones configurables, las cuales podrán cambiar cómo muestra la siguiente imagen:

<p align="center"><img src="{{ site.baseurl }}/images/01-configurable.gif" /></p>

## 1.- Creando las opciones

En el tutorial anterior creamos dos clases llamadas MenuEscenario y MenuOpciones, en esta instancia usaremos el segundo para crear nuestras opciones configurables. El código fuente de esta clase es de la siguiente manera:

<pre class="prettyprint">
    <code class="language-cs">
using ScreenManager.MenuScreen;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenManagerShowcase
{
    class MenuOpciones : BaseMenuScreen
    {
        public MenuOpciones(string menuTitle)
            : base(menuTitle)
        {

        }
    }
}
    </code>
</pre>

Para este ejemplo crearemos cuatro opciones diferentes, elegir formato, elegir lenguaje, activar modo súper y aumentar el número de vidas. Para ello declararemos cuatro variables de tipo MenuEntry como atributos de la clase (si recuerdan antes estás las declarábamos dentro del mismo constructor) y las inicializaremos en el constructor con un String vacío.

<pre class="prettyprint">
    <code class="language-cs">
using ScreenManager.MenuScreen;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenManagerShowcase
{
    class MenuOpciones : BaseMenuScreen
    {

        MenuEntry formatoMenuEntry;
        MenuEntry lenguajeMenuEntry;
        MenuEntry superMenuEntry;
        MenuEntry vidasMenuEntry;

        public MenuOpciones(string menuTitle)
            : base(menuTitle)
        {
            formatoMenuEntry = new MenuEntry(this, string.Empty);
            lenguajeMenuEntry = new MenuEntry(this, string.Empty);
            superMenuEntry = new MenuEntry(this, string.Empty);
            vidasMenuEntry = new MenuEntry(this, string.Empty);



            MenuEntries.Add(formatoMenuEntry);
            MenuEntries.Add(lenguajeMenuEntry);
            MenuEntries.Add(superMenuEntry);
            MenuEntries.Add(vidasMenuEntry);
        }
    }
}
    </code>
</pre>

## 2.- Creando las variables

Necesitamos declarar las variables que guardaran los datos a modificar, para este ejemplo definiremos variables estáticas, sin embargo la definición de estas es libre según las necesidades de cada juego.

Para el formato definiremos un enum con tres opciones:

<pre class="prettyprint">
    <code class="language-cs">
enum Formatos
{
    CS,
    JAR,
    CPP,
}

static Formatos formatoActual = Formatos.CS;
    </code>
</pre>

También definiremos un arreglo con nombres para los lenguajes junto a una variable para saber la posición.

<pre class="prettyprint">
    <code class="language-cs">
static string[] lenguaje = { "C#", "Java", "C++" };
static int lenguajeActual = 0;
    </code>
</pre>

Luego para la opción súper y la vida podemos usar las siguientes variables.

<pre class="prettyprint">
    <code class="language-cs">
static bool super = false;
static int vida = 23;
    </code>
</pre>

## 3.- Uniendo las variables con los MenuEntry

Para mostrar la información de estas variables en la pantalla crearemos un método privado que asigna el texto que mostrará cada MenuEntry.

<pre class="prettyprint">
    <code class="language-cs">
private void SetMenuEntryText()
{
    formatoMenuEntry.Text = "Formato preferido: " + formatoActual;
    lenguajeMenuEntry.Text ="Lenguaje: "+lenguaje[lenguajeActual];
    superMenuEntry.Text = "Super: " + (super ? "on" : "off");
    vidasMenuEntry.Text = "vida: " + vida;
}
    </code>
</pre>

De esta forma cada Menuentry tendrá un texto determinado por cada variable.

<p class="ribbon-alert b-green" align="justify"><strong>Built-in:</strong> Los MenuEntry tienen la propiedad Text que permite cambiarles en cualquier momento el mensaje que estos muestran por pantalla. Esta funcionalidad viene previamente implementada en <strong>ScreenManager</strong></p>

## 4.- Creando eventos y asignando EventHandlers

Finalmente falta crear los eventos y agregarlos a los EventHandlers de cada MenuEntry, en caso de tener dudas con esto se sugiere revisar el tutorial anterior donde se habla en detalle de cómo funcionan los eventos con los MenuEntry.

Para la opción de Formato tendremos.

<pre class="prettyprint">
    <code class="language-cs">
void FormatoMenuEntrySelected(
    object sender, PlayerIndexEventArgs e)
{
    formatoActual++;

    if (formatoActual > Formatos.CPP)
        formatoActual = 0;

    SetMenuEntryText();
}
    </code>
</pre>

Es decir, cada vez que se active este evento se avanzará al siguiente formato, y si se supera el último formato se volverá al principio. También pueden ver como al final es llamado el método privado que creamos **SetMenuEntryText()** el cual permite actualizar el cambio de la variable en el menú.

Para el lenguaje tendremos.

<pre class="prettyprint">
    <code class="language-cs">
void LenguajeMenuEntrySelected(
    object sender, PlayerIndexEventArgs e)
{
    lenguajeActual = (lenguajeActual + 1) % lenguaje.Length;

    SetMenuEntryText();
}
    </code>
</pre>

La cuál trabaja bajo la misma lógica que con el Formato, solo que esta vez como es un array podemos usar la propiedad Length para calcular el modulo y no salirnos de memoria al recorrer los valores.

Para súper tendremos.

<pre class="prettyprint">
    <code class="language-cs">
void SuperMenuEntrySelected(
    object sender, PlayerIndexEventArgs e)
{
    super = !super;

    SetMenuEntryText();
}
    </code>
</pre>

Está variable es un booleano por lo que basta con negarla para cambiar su valor.

Para vida tendremos.

<pre class="prettyprint">
    <code class="language-cs">
void VidaMenuEntrySelected(
    object sender, PlayerIndexEventArgs e)
{
    ++vida;

    SetMenuEntryText();
}
    </code>
</pre>

Al ser una variable entera lo que haremos será sumar uno a su valor cada vez que se accione este evento.

Cómo pueden ver cada evento llama al final al método **SetMenuEntryText()** para actualizar el valor del MenuEntry en la pantalla. De esta forma lo único que falta es agregar los eventos a los EventHandlers, lo cual haremos en el Constructor de nuestra clase MenuOpciones. Además es necesario agregar el **SetMenuEntryText()** después de instanciar los MenuEntry para asignar los valores iniciales.

<pre class="prettyprint">
    <code class="language-cs">
public MenuOpciones(string menuTitle)
    : base(menuTitle)
{
    formatoMenuEntry = new MenuEntry(this, string.Empty);
    lenguajeMenuEntry = new MenuEntry(this, string.Empty);
    superMenuEntry = new MenuEntry(this, string.Empty);
    vidasMenuEntry = new MenuEntry(this, string.Empty);

    SetMenuEntryText();

    formatoMenuEntry.Selected += FormatoMenuEntrySelected;
    lenguajeMenuEntry.Selected += LenguajeMenuEntrySelected;
    superMenuEntry.Selected += SuperMenuEntrySelected;
    vidasMenuEntry.Selected += VidaMenuEntrySelected;

    MenuEntries.Add(formatoMenuEntry);
    MenuEntries.Add(lenguajeMenuEntry);
    MenuEntries.Add(superMenuEntry);
    MenuEntries.Add(vidasMenuEntry);
}
    </code>
</pre>

## 5.- Listo!

Al hacer build e iniciar el juego se obtendrá el siguiente resultado.

<p align="center"><img src="{{ site.baseurl }}/images/01-configurable.gif" /></p>

<p class="ribbon-alert b-green" align="justify"><strong>Built-in:</strong> Al estar en cualquier menú es posible usar la tecla <kbd>ENTER</kbd> para activar el EventHandler Selected en el MenuEntry seleccionado. Esta funcionalidad viene previamente implementada en <strong>ScreenManager</strong></p>

Como es posible ver en la imagen, el salir y volver al menú guarda los datos elegidos ya que estos son **static**, sin embargo se pueden usar otras formas para guardar estos valores, ya sean pasándolos a un **XML** u otro tipo de archivo, modificando una **Base de Datos**, pasándolos de parámetros a otra función, etc. Todo este comportamiento puede ser fácilmente alterado en cada evento de cada variable.

<p class="ribbon-alert b-blue" align="justify"><strong>Descarga el Proyecto:</strong> Descarga el <strong><a href="https://github.com/SpoonmanGames/MonoGame-ScreenManager/archive/opc-cv1.0.zip">proyecto de Menú de Opciones Configurables</a></strong>para ver cómo todo este código es aplicado. Incluye el contenido del tutorial anterior.</p>

# 6.- ¿Dónde continuar?

Con esto ya puedes tener un menú con opciones configurables, pero ¿cómo cargar un escenario y que además haga uso de estas variables?, para saber cómo hacer esto y mucho más te invitamos a revisar nuestros [tutoriales en la página principal](http://www.spoonmangames.cl/MonoGame-ScreenManager/tutoriales/).
