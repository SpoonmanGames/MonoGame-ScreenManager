---
layout: post
title: Crear un Menú con varias pantallas
category:
- tutoriales
summary: En este tutorial podrás entender lo básico para montar un menú con varias opciones y pantallas.
---

<p class="ribbon-alert b-blue" align="justify"><strong>Antes de empezar:</strong> Se recomienda tener configurado el proyecto según se especifica en la guía <a href="http://www.spoonmangames.cl/MonoGame-ScreenManager/tutoriales/implementacion/">Como incluir ScreenManager en tu Vídeo Juego</a> ya que el siguiente tutorial continua exactamente después de realizar todos los pasos allí especificados.</p>

<p class="ribbon-alert b-blue" align="justify"><strong>Antes de empezar:</strong> Para este y los siguientes tutoriales se usará un proyecto llamado ScreenManagerShowcase para incluir cada uno de los ejemplos aquí creados. De modo que al final del tutorial podrás descargarlo y ver directamente todo lo que aquí haremos.</p>

En este tutorial implementaremos un menú con varias pantallas y opciones con el fin de lograr lo siguiente:

<p align="center"><img src="{{ site.baseurl }}/images/05-menupantallas.gif" /></p>

## 1.- Crear la pantalla principal

Lo primero es crear una nueva clase para el menú principal.

<p align="center"><img src="{{ site.baseurl }}/images/01-menupantallas.gif" /></p>

La cual llamaremos MenuPrincipal.cs

<p align="center"><img src="{{ site.baseurl }}/images/02-menupantallas.png" /></p>

Al crear la clase se debiera obtener el siguiente código fuente:

<pre class="prettyprint">
    <code class="language-cs">
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace ScreenManagerShowcase
    {
        class MenuPrincipal
        {
        }
    }
    </code>
</pre>

Lo primero a hacer es que esta clase herede de BaseMenuScreen, para lo que se necesita usar la librería ScreenManager.MenuScreen, tal que la clase tome la siguiente forma.

<pre class="prettyprint">
    <code class="language-cs">
    using ScreenManager.MenuScreen;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace ScreenManagerShowcase
    {
        class MenuPrincipal : BaseMenuScreen
        {
        }
    }
    </code>
</pre>

Lo primero a declarar es el constructor, el cuál debe usar el constructor base de BaseMenuScreen que tiene de parámetro de entrada un string para definir el título del menú, esto se define de la siguiente manera.

<pre class="prettyprint">
    <code class="language-cs">
    public MenuPrincipal(string menuTitle)
        : base(menuTitle)
    {

    }
    </code>
</pre>

**ScreenManager** funciona con una lista de Screens administrada por la clase principal ScreenManager.cs, estas Screens serán dibujadas en la pantalla en el orden en el que se han agregado a la lista, sin embargo solo una a la vez estará activa, el resto estará en espera para ser mostradas en la pantalla. Para agregar nuestro MenuPrincipal en esta lista se debe usar el siguiente método:

<pre class="prettyprint">
    <code class="language-cs">
	screenManager.AddScreen(
        new MenuPrincipal("Menú Principal"), null
    );
    </code>
</pre>

El primer parámetro recibe cualquier clase que herede de GameScreen (BaseMenuScreen hereda de GameScreen, por lo que nuestro MenuPrincipal también hereda de GameScreen), mientras que el segundo permite especificar que jugador tendrá control sobre ese menú, como este es la pantalla principal le daremos un null para que cualquier jugador pueda usarlo.

Debido a que esta es nuestra primera pantalla en el juego el código debe ser agregado en el constructor inicial del vídeo juego, comúnmente en el constructor de Game1.cs, tal que este debe tener al menos lo siguiente.

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

	    // Añade el Menu Principal al ScreenManager con el
        // título "Menú Principal"
	    screenManager.AddScreen(
            new MenuPrincipal("Menú Principal"), null
        );
	}
    </code>
</pre>

Al compilar e iniciar se debiera ver una pantalla con el título Menú Principal.

<p align="center"><img src="{{ site.baseurl }}/images/03-menupantallas.png" /></p>

## 2.- Agregar opciones a la pantalla principal

Vamos a agregar dos opciones, una para ir a un menú de selección de escenarios y otra para ir a un menú de opciones. Para crear una opción se debe instansiar un objeto de la clase MenuEnrty.

<pre class="prettyprint">
    <code class="language-cs">
	MenuEntry escenarios = new MenuEntry(this, "Escenarios");
    MenuEntry opciones = new MenuEntry(this, "Opciones");
    </code>
</pre>

El primer parámetro recibe un objeto de tipo BaseMenuEntry, el cual representa a que Menú pertenecerá dicha opción; el segundo parámetro, un string, determina el nombre que se mostrará en la pantalla. Ambas opciones deben ser declaradas en el constructor del BaseMenuEntry que tendrá dichas opciones, en nuestro caso: El constructor de **MenuPrincipal**.

Para incluir finalmente estas opciones a la pantalla se debe agregar cada MenuEntry a una lista llamada MenuEntries, la cual es una propiedad de BaseMenuScree, por lo que en el mismo constructor, a continuación de lo agregado anteriormente se debe incluir lo siguiente.

<pre class="prettyprint">
    <code class="language-cs">
	MenuEntries.Add(escenarios);
    MenuEntries.Add(opciones);
    </code>
</pre>

Al compilar y ejecutar se debieran ver las dos opciones en el menú principal, las cuales se pueden navegar con las flechas del teclado.

<p align="center"><img src="{{ site.baseurl }}/images/04-menupantallas.gif" /></p>

<p class="ribbon-alert b-green" align="justify"><strong>Built-in:</strong> Al estar en cualquier menú es posible usar las <kbd>Flechas direccionales</kbd> del teclado para moverse hacia arriba y hacia abajo en las opciones. Esta funcionalidad viene previamente implementada en <strong>ScreenManager</strong></p>

## 3.- Crear Menú Escenarios y Menú Opciones

El objetivo a continuación es crear dos menús más, de forma que al presionar la opción Escenarios nos lleve a un menú de selección de escenarios y que al presionar Opciones nos lleve a un menú de opciones configurables. Para ello se necesitarán dos clases nuevas similares a la clase MenuPrincipal.

<p class="ribbon-alert b-green" align="justify"><strong>Pro Tip:</strong> Te invitamos a que, con los conocimientos adquiridos hasta ahora, crees tu mismo los menú MenuEscenario.cs y MenuOpciones.cs y te saltes a la parte "4.- Unir los menús" de este tutorial.</p>
<br>
<button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
  Mostrar solución
</button>
<div class="collapse" id="collapseExample">
    <div class="well">

<h3>MenuEscenario.cs</h3>

<pre class="prettyprint">
    <code class="language-cs">
    using ScreenManager.MenuScreen;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace ScreenManagerShowcase
    {
        class MenuEscenario : BaseMenuScreen
        {
            public MenuEscenario(string menuTitle)
                : base(menuTitle)
            {

            }
        }
    }
    </code>
</pre>

<h3>MenuOpciones.cs</h3>

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
</div>
</div>

## 4.- Unir los Menús

En la parte anterior creamos dos menús nuevos, pero estos no están vinculados con el Menú Principal de ninguna forma y al presionar las opciones que ya hemos implementado no ocurre nada. Todo esto se debe a que es necesario agregar **eventos** a cada botón. Agregar eventos en C# es bastante sencillo, como estos son parte del menú principal declararemos cada uno de ellos en la clase MenuPrincipal.cs.

Lo primero a hacer al crear un evento es crear el método, crearemos uno para el menú de escenarios y otro para el menú de opciones, llamaremos MenuEscenarioSelected y MenuOpcionesSelected respectivamente, ambos deben ([por definición de eventos en MSDN C#](https://msdn.microsoft.com/en-us/library/ms366768.aspx)) tener dos argumentos como mínimo, el object que se subscribe al evento y un indice del evento.

<pre class="prettyprint">
    <code class="language-cs">
	private void MenuEscenarioSelected(
        object sender, PlayerIndexEventArgs e)
	{
		ScreenManagerController.AddScreen(
            new MenuEscenario("Selecciona un Escenario"),
            e.PlayerIndex
        );
	}
    </code>
</pre>

Para el **ScreenManager** existe un indice de evento llamado PlayerIndexEventArgs, el cuál nos permite identificar que player gatilló el evento, este es el segundo argumento de entrada pasado al método. El cuerpo de este evento nos permitirá agregar un nuevo menú al **ScreenManager**, para eso basta con usar el ScreenManagerController (el cual es una propiedad de GameScreen) y que nos permite acceder a la instancia de **ScreenManager** del juego.

De esta forma si se lanza el evento se cargará el MenuEscenario con el título "Selecciona un Escenario" y el Menú Principal quedará en segundo plano. Sin embargo, necesitamos suscribir algún evento para que este método se gatille bajo alguna condición, la cuál debiera ser seleccionar la opción "Escenarios" del Menú Principal, para ello contamos con un EventHandler llamado Selected en la clase MenuEntry, el cual se gatilla al presionar <kbd>Enter</kbd> sobre una opción. Basado en esto debemos agregar la siguiente línea de código en el constructor del MenuPrincipal.cs, después de instanciar el MenuEntry y antes de agregarlo a la lista de MenuEntries.

<pre class="prettyprint">
    <code class="language-cs">
    // Event Handler suscrito al evento MenuEscenarioSelected,
    // esto se activará al presionar Enter sobre la opción 
    // "Escenarios"
    escenarios.Selected += MenuEscenarioSelected;

    </code>
</pre>

Tal que el constructor quedará del a siguiente forma.

<pre class="prettyprint">
    <code class="language-cs">
	public MenuPrincipal(string menuTitle)
        : base(menuTitle)
    {
        MenuEntry escenarios = new MenuEntry(this, "Escenarios");
        MenuEntry opciones = new MenuEntry(this, "Opciones");

        // Event Handler suscrito al evento MenuEscenarioSelected,
        // esto se activará al presionar Enter sobre la opción 
        // "Escenarios"
        escenarios.Selected += MenuEscenarioSelected;

        MenuEntries.Add(escenarios);
        MenuEntries.Add(opciones);
    }
    </code>
</pre>

<p class="ribbon-alert b-green" align="justify"><strong>Built-in:</strong> Al estar en cualquier menú es posible usar la tecla <kbd>ENTER</kbd> ingresar a la opción seleccionada. Esta funcionalidad viene previamente implementada en <strong>ScreenManager</strong></p>

Como ya debes estar intuyendo, para el Menú de Opciones debes hacer lo mismo, crear un nuevo método de evento que cargue la clase MenuOpciones y suscribir dicho evento al Event Handler del MenuEntry opciones. El código resultante de esto será como el siguiente.

<pre class="prettyprint">
    <code class="language-cs">
    public MenuPrincipal(string menuTitle)
        : base(menuTitle)
    {
        MenuEntry escenarios = new MenuEntry(this, "Escenarios");
        MenuEntry opciones = new MenuEntry(this, "Opciones");

        // Event Handler suscrito al evento MenuEscenarioSelected,
        // esto se activará al presionar Enter sobre la opción
        // "Escenarios"
        escenarios.Selected += MenuEscenarioSelected;
        
        // Event Handler suscrito al evento MenuOpcionesSelected,
        // esto se activará al presionar Enter sobre la opción
        // "Opciones"
        opciones.Selected += MenuOpcionesSelected;

        MenuEntries.Add(escenarios);
        MenuEntries.Add(opciones);
    }

    private void MenuEscenarioSelected(
        object sender, PlayerIndexEventArgs e)
    {
        ScreenManagerController.AddScreen(
            new MenuEscenario("Selecciona un Escenario"),
            e.PlayerIndex
        );
    }

    private void MenuOpcionesSelected(
        object sender, PlayerIndexEventArgs e)
    {
        ScreenManagerController.AddScreen(
            new MenuOpciones("Configura las opciones"),
            e.PlayerIndex
        );
    }        
    </code>
</pre>

## 5.- Listo!

Al hacer build e iniciar el juego se obtendrá el siguiente resultado.

<p align="center"><img src="{{ site.baseurl }}/images/05-menupantallas.gif" /></p>

<p class="ribbon-alert b-green" align="justify"><strong>Built-in:</strong> Al estar en cualquier menú es posible usar la tecla <kbd>ESC</kbd> para volver al menú anterior. Esta funcionalidad viene previamente implementada en <strong>ScreenManager</strong></p>

<p class="ribbon-alert b-blue" align="justify"><strong>Descarga el Proyecto:</strong> Descarga el <strong><a href="https://github.com/SpoonmanGames/MonoGame-ScreenManager/archive/mpv1.0.zip">proyecto de Menu y Pantallas</a></strong>para ver cómo todo este código es aplicado.</p>

# 6.- ¿Dónde continuar?

Con esto ya puedes cargar diferentes escenarios desde el MenuEscenarios.cs o tener un menú de opciones configurables en MenuOpciones.cs, para saber cómo hacer esto y mucho más te invitamos a revisar nuestros [tutoriales en la página principal](http://www.spoonmangames.cl/MonoGame-ScreenManager/tutoriales/).