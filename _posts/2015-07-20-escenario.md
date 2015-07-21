---
layout: post
title: Añadir un Escenario
category:
- tutoriales
summary: Aprende a cargar un escenario, pausar su ejecución y volver al menú principal con solo un par de teclas.
---

<p class="ribbon-alert b-blue" align="justify"><strong>Antes de empezar:</strong> Se recomienda tener configurado el proyecto según se especifica en la guía <a href="http://www.spoonmangames.cl/MonoGame-ScreenManager/tutoriales/implementacion/">Como incluir ScreenManager en tu Vídeo Juego</a>.</p>

<p class="ribbon-alert b-blue" align="justify"><strong>Antes de empezar:</strong> Se recomienda haber leído o hecho el tutorial de <a href="http://www.spoonmangames.cl/MonoGame-ScreenManager/tutoriales/configurable/">Crear un Menú con opciones configurables</a> ya que aquí se continuara dicho tutorial.</p>

En este tutorial cargaremos un escenario, tendremos una opción de pausa, un popup y una opción para volver al menú principal, tal como lo muestra la siguiente imagen:

<p align="center"><img src="{{ site.baseurl }}/images/01-escenario.gif" /></p>

## 1.- Creando el Escenario

Partiremos por crear una nueva clase llamada Escenario.cs, la cual debe heredar de GameScreen, además implementaremos dos variables para manejar el contenido del Escenario y la fuente de textos, finalmente definimos algunas variables básicas para las transiciones para cuando entremos y salgamos del Escenario:



<pre class="prettyprint">
    <code class="language-cs">
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ScreenManager.StateControl;
using System;

namespace ScreenManagerShowcase
{
    class Escenario : GameScreen
    {
        ContentManager content;
        SpriteFont gameFont;
    }

    public Escenario()
    {
        TransitionOnTime = TimeSpan.FromSeconds(1.5);
        TransitionOffTime = TimeSpan.FromSeconds(0.5);
    }
}
    </code>
</pre>

## 2.- Agregando una opción para cargar el Escenario

En el tutorial anterior creamos dos clases llamadas MenuEscenario y MenuOpciones, en esta instancia usaremos la primera para crear nuestras opciones configurables. Lo que haremos será crear un botón que nos permita cargar el Escenario:

<pre class="prettyprint">
    <code class="language-cs">
using ScreenManager.MenuScreen;
using ScreenManager.PantallasBases;

namespace ScreenManagerShowcase
{
    class MenuEscenario : BaseMenuScreen
    {
        public MenuEscenario(string menuTitle)
            : base(menuTitle)
        {
            MenuEntry escenario_uno = 
                new MenuEntry(this, "Escenario 1");

            escenario_uno.Selected += MenuEscenarioUnoSelected;

            MenuEntries.Add(escenario_uno);
        }

        private void MenuEscenarioUnoSelected(
            object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(
                ScreenManagerController, 
                true, 
                string.Empty, 
                null, 
                new Escenario()
            );
        }
    }
}
    </code>
</pre>

Cómo es posible ver esta clase se parece mucho al menú principal, solo que en vez de usar **ScreenManagerController.AddScreen** usamos **LoadingScreen..Load**, la cual nos permite cargar una nueva GameScreen desechando en el proceso todas las GameScreen previamente cargadas, de esta forma solo nuestro Escenario estará activo y en memoria. Esto se hace ya que mientras estamos en un escenario no es necesario guardar la información del menú, el cual solo sirve para navegar a través de él.

**LoadingScreen** recive como primer parametro el ScreenManager, luego una variable para indicar si la carga del escenario será rápida o lenta, un string para indicar un fondo de pantalla mientras se carga, una variable para indicar si algún jugador tendrá uso exclusivo del escenario y finalmente una lista de GameScreen separadas por comas para ser cargadas.

## 2.- Agregar un comportamiento al Escenario

Como este tutorial no busca enseñar a diseñar juegos ni a programar en C# puedes copiar y pegar el siguiente código en la clase Escenario.cs, sin embargo si deseas ver una breve explicación puedes presionar el botón que se encuentra después del código fuente.

<pre class="prettyprint">
    <code class="language-cs">
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ScreenManager.StateControl;
using System;

namespace ScreenManagerShowcase
{
    class Escenario : GameScreen
    {
        ContentManager content;
        SpriteFont gameFont;

        Vector2 enemyPosition = new Vector2(100, 100);

        Random random = new Random();

        public Escenario()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(
                            ScreenManagerController.Game.Services,
                            "Content"
                          );

            gameFont = ScreenManagerController.Font;

        }

        public override void UnloadContent()
        {
            content.Unload();
        }


        public override void Update(
            GameTime gameTime,bool otherScreenHasFocus,
                             bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            if (IsActive)
            {
              const float randomization = 10;
              
              enemyPosition.X += 
                (float)(random.NextDouble() - 0.5) * randomization;
              enemyPosition.Y += 
                (float)(random.NextDouble() - 0.5) * randomization;
  
              Vector2 targetPosition = new Vector2(
              ScreenManagerController.GraphicsDevice.Viewport.Width
              / 2 - gameFont.MeasureString(
                       "Agrega tu Escenario de juego aquí.").X / 2,
              200
              );
  
              enemyPosition = Vector2.Lerp(
                                enemyPosition, 
                                targetPosition, 
                                0.05f
                              );
            }
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = 
                ScreenManagerController.SpriteBatch;

            spriteBatch.Begin();

            spriteBatch.DrawString(
                gameFont,
                "Agrega tu Escenario de juego aquí.",
                enemyPosition,
                Color.Black
            );

            spriteBatch.End();
        }
    }
}
    </code>
</pre>


<button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
  Mostrar explicación del código fuente
</button>
<div class="collapse" id="collapseExample">
    <div class="well">
        <p align="justify">
            Este código consiste en mostrar un string en la pantalla y que este se mueva aleatoriamente. Para ello se usa un Vector2, al cual se le aplican valores aleatorios en sus ejes x e y que luego son ajustados usando el método Lerp, el cual interpola la posición según un punto dado, en este caso, un poco más arriba del centro de la pantalla.
            <br>
            Todo esto ocurre en el Update, en el Draw solo se dibuja el string.
        </p>
    </div>
</div>

Al implementar este código y ejecutar el juego se tendrá el siguiente comportamiento:

<p align="center"><img src="{{ site.baseurl }}/images/02-escenario.gif" /></p>

## 4.- Crear un PopUp que Pausa el juego

<p class="ribbon-alert b-red" align="justify"><strong>Importante:</strong> En el método update del código anterior existe un if que verifica el valor de IsActive, esto es elemental implementarlo si se planea tener un Pause en el juego.</p>

A continuación haremos que al presionar la tecla Escape se abra un popup que nos permita pausar el juego y que nos dé la opción de salir o seguir jugando, para ello haremos uso del método HandleInput.

<pre class="prettyprint">
    <code class="language-cs">
public override void HandleInput(InputState input)
{
    PlayerIndex py;
    if (input.IsMenuCancel(null, out py))
    {
        
    }
}
    </code>
</pre>

Este código nos permite detectar cuando se ha hecho la acción "MenuCancel", la cual está vinculada a presionar el botón Escape del teclado, en el siguiente tutorial explicaremos todo sobre el manejo de inputs, por lo que por ahora te pedimos que implementes el código tal cuál sale aquí para utilizarlo.

Para crear un PopUp simplemente necesitamos instanciar un objeto y pasarle un mensaje para mostrar:

<pre class="prettyprint">
    <code class="language-cs">
const string message = "¿Está seguro que desea salir?";

PopupScreen confirmExitMessageBox = new PopupScreen(message);
    </code>
</pre>

No es necesario indicar las teclas a usar ya que automáticamente el PopUp mostrará esta información por pantalla.

También necesitamos agregar este PopupScreen al ScreenManager ya que es una nueva GameScreen, para esto basta hacer:

<pre class="prettyprint">
    <code class="language-cs">
ScreenManagerController.AddScreen(confirmExitMessageBox, py);
    </code>
</pre>

Todo esto debe ser declarado dentro de la acción del HandleInput:

<pre class="prettyprint">
    <code class="language-cs">
public override void HandleInput(InputState input)
{
    PlayerIndex py;
    if (input.IsMenuCancel(null, out py))
    {
        const string message = "¿Está seguro que desea salir?";

        PopupScreen confirmExitMessageBox = new PopupScreen(message);

        ScreenManagerController.AddScreen(confirmExitMessageBox, py);
    }
}
    </code>
</pre>    

Si ejecutamos este código obtendremos lo siguiente:

//TODO gif del popup

Es posible notar que al abrir el popup la Screen que queda atrás queda en modo pausa, sin embargo si aceptamos con Escape la acción no se ejecuta. Esto es debido a que nos falta vincular un evento al Popup.

## 5.- Agregar un Evento al Popup

Esto es similar a agregar un evento para un Menú, primero definimos un metodo y luego usamos el HandleInput del Popup para vincularlo:

<pre class="prettyprint">
    <code class="language-cs">
void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
{
    LoadingScreen.Load(ScreenManagerController, true, string.Empty, null, new MenuPrincipal("Menú Principal"));
}
    </code>
</pre>

Usamos un **LoadingScreen.Load** ya que al salir del Escenario no queremos que se guarde información de todo lo que hemos hecho, queremos que se limpie y se cargue en cero el menú principal. Este evento se debe vincular al Popup de la siguiente manera:

<pre class="prettyprint">
    <code class="language-cs">
confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;
    </code>
</pre>

Esto debe ser antes de agregarlo al **ScreenManagerController.AddScreen**.

## 6.- Listo!

Al hacer build e iniciar el juego se obtendrá el siguiente resultado.

<p align="center"><img src="{{ site.baseurl }}/images/01-escenario.gif" /></p>

<p class="ribbon-alert b-green" align="justify"><strong>LoadingScreen:</strong> Este método siempre borra toda información y contenido previamente guardado antes de cargar las GameScreen que se le dan por parámetros de entrada, por lo que se recomienda usar sabiamente el método UnloadContent() para su correcto funcionamiento.</p>

De esta misma forma es posible cargar más escenarios desde el MenuEscenarios.cs o desde el mismo Escenario.cs, tan solo se debe usar sabiamente el AddScreen o el LoadinScreen según sea necesario. Por ejemplo: *un nuevo escenario usaría LoadingScreen, cargar el interior de una casa en un escenario podría funcionar mejor con un AddScreen, etc*. Siempre ten en cuenta tus necesidades antes de usar una de estas dos opciones.

//TODO: proyecto
<p class="ribbon-alert b-blue" align="justify"><strong>Descarga el Proyecto:</strong> Descarga el <strong><a href="https://github.com/SpoonmanGames/MonoGame-ScreenManager/archive/opc-cv1.0.zip">proyecto de Menú de Opciones Configurables</a></strong>para ver cómo todo este código es aplicado. Incluye el contenido del tutorial anterior.</p>

# 6.- ¿Dónde continuar?

Con esto ya puedes tener cargar un Escenario, pausar el juego y salir del escenario cargado, pero  hay algo que no hemos dejado en claro y es como usar el HandleInput y el InputState, para saber cómo usar estos componentes y mucho más te invitamos a revisar nuestros [tutoriales en la página principal](http://www.spoonmangames.cl/MonoGame-ScreenManager/tutoriales/).
