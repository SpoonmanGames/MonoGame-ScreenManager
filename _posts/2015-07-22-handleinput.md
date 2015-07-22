---
layout: post
title: Entendiendo el InputState
category:
- tutoriales
summary: Comprende cómo se usa el HandleInput mediante el InputState para agregar controles en cualquier parte de tu juego.
---

<p class="ribbon-alert b-blue" align="justify"><strong>Antes de empezar:</strong> Este tutorial es explicativo y no usa un proyecto de base para mostrar las acciones, por lo que siéntete libre de implementar a gusto cada acción aquí explicada.</p>

## 1.- La clase InputState

Esta clase es independiente del proyecto y está implementada principalmente para facilitar el uso de inputs del usuario, ya sea mediante el teclado o mediante un control/joystick.

Por defecto el máximo de inputs simultáneos es 4, esto puede ser cambiado modificando la siguiente variable.

<pre class="prettyprint">
    <code class="language-cs">
public int MaxInputs
{
    get { return maxInputs; }
}
private const int maxInputs = 4;
    </code>
</pre>

El constructor y el Update de esta clase está automáticamente implementado por el **ScreenManager** por lo que no debes preocuparte de usarlos, sin embargo a continuación una breve explicación de cada uno:

<pre class="prettyprint">
    <code class="language-cs">
public InputState()
{
    CurrentKeyboardStates = new KeyboardState[MaxInputs];
    CurrentGamePadStates = new GamePadState[MaxInputs];

    LastKeyboardStates = new KeyboardState[MaxInputs];
    LastGamePadStates = new GamePadState[MaxInputs];

    GamePadWasConnected = new bool[MaxInputs];
}
    </code>
</pre>

El constructor inicializa los arreglos que permiten mantener en contexto los controles, de tal forma que detectan si se está presionando un botón o no o si un control ha sido desconectado.

<pre class="prettyprint">
    <code class="language-cs">
public void Update()
{
    for (int i = 0; i < MaxInputs; i++)
    {
        LastKeyboardStates[i] = CurrentKeyboardStates[i];
        LastGamePadStates[i] = CurrentGamePadStates[i];

        CurrentKeyboardStates[i] = Keyboard.GetState();
        CurrentGamePadStates[i] = GamePad.GetState((PlayerIndex)i);

        if (CurrentGamePadStates[i].IsConnected)
        {
            GamePadWasConnected[i] = true;
        }
    }
}
    </code>
</pre>

El update revisa en todo momento el estado de estos arreglos así como la conexión de los controles.

Aparte de estos métodos existen tres métodos principales para controlar la acción de los inputs: IsNewKeyPress, IsContinuousKeyPress y IsNewButtonPress.

## 2.- IsNewKeyPress

Este método permite detectar si es que una tecla ha sido presionada, esta detección ocurre una sola vez, es decir, si la tecla se mantiene presionada la acción no se volverá a ejecutar.

<pre class="prettyprint">
    <code class="language-cs">
private bool IsNewKeyPress(
    Keys key, PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
{
    //Si hay un player controlando las teclas
    if (controllingPlayer.HasValue)
    {
        playerIndex = controllingPlayer.Value;

        int i = (int)playerIndex;

        return (CurrentKeyboardStates[i].IsKeyDown(key) &&
                LastKeyboardStates[i].IsKeyUp(key));
    }
    else
    {
        //Acepta el input de cualquier player
        return (
          IsNewKeyPress(key, PlayerIndex.One, out playerIndex) ||
          IsNewKeyPress(key, PlayerIndex.Two, out playerIndex) ||
          IsNewKeyPress(key, PlayerIndex.Three, out playerIndex) ||
          IsNewKeyPress(key, PlayerIndex.Four, out playerIndex)
        );
    }
}
    </code>
</pre>

Esto se logra revisando si es que el estado anterior de la Key era no estar presionado y el nuevo estado es estar presionado.

## 3.- IsContinuousKeyPress

Este método permite detectar si una tecla es presionada de forma continua, tal que cualquier acción vinculada a ella se realizará constantemente mientras se tenga presionado el botón.

<pre class="prettyprint">
    <code class="language-cs">
private bool IsContinuousKeyPress(
    Keys key, PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
{
    //Si hay un player controlando las teclas
    if (controllingPlayer.HasValue)
    {
        playerIndex = controllingPlayer.Value;

        int i = (int)playerIndex;

        return (CurrentKeyboardStates[i].IsKeyDown(key));
    }
    else
    {
      //Acepta el input de cualquier player
      return (
        IsContinuousKeyPress(key, PlayerIndex.One, out playerIndex) ||
        IsContinuousKeyPress(key, PlayerIndex.Two, out playerIndex) ||
        IsContinuousKeyPress(key, PlayerIndex.Three, out playerIndex) ||
        IsContinuousKeyPress(key, PlayerIndex.Four, out playerIndex)
      );
    }
}
    </code>
</pre>

Esto simplemente se logra revisando si la tecla presionada sigue presionada.

## 4.- IsNewButtonPress

Este método hace exactamente lo mismo que IsNewKeyPress, con la diferencia que en vez de detectar teclas detecta botones de un control.

## 5.- Crear y usar un Input

Hay dos formas de declarar una acción sobre una Key:

<pre class="prettyprint">
    <code class="language-cs">
public bool IsMenuCancel(PlayerIndex? controllingPlayer,
                         out PlayerIndex playerIndex)
{
    return IsNewKeyPress(
        Keys.Escape, controllingPlayer, out playerIndex
    );
}
    </code>
</pre>

Este método usa dos parámetros de entrada, el primero es el player controlando el menú dónde se ejecuta esta acción y el segundo es el player que ha realizado la acción. En este ejemplo se hace uso de IsNewKeyPress, por lo que la tecla Escape solo será detectada una vez.

<pre class="prettyprint">
    <code class="language-cs">
public bool IsG(PlayerIndex? controllingPlayer)
{
    PlayerIndex playerIndex;

    return IsContinuousKeyPress(
        Keys.G , controllingPlayer, out playerIndex
    );
}
    </code>
</pre>

Esta otra forma solo acepta un parámetro de entrada, correspondiente al player que controla la acción en la pantalla de donde ha sido llamado. En este caso se usa IsContinuousKeyPress, por lo que **G** será detectada siempre que se mantenga presionado.

Para usar estos métodos desde una **GameScreen** se debe hacer uso del método HandleInput, para este caso usaremos el método implementado en la clase **PopupScreen**.

<pre class="prettyprint">
    <code class="language-cs">
public override void HandleInput(InputState input)
{
    PlayerIndex playerIndex;

    /* Pasamos el ControllingPlayer como nulo si queremos que
     * cualquier player realice acciones, o con un valor para 
     * el player que deseamos que realice la acción.
     * Luego playerIndex guardará la información de quien
     * hizo la acción.
     */
    if (input.IsMenuSelect(ControllingPlayer, out playerIndex))
    {
        // Levanta el evento Accepted y se sale del Popup
        if (Accepted != null)
            Accepted(this, new PlayerIndexEventArgs(playerIndex));

        ExitScreen();
    }
    else if (input.IsMenuCancel(ControllingPlayer, out playerIndex))
    {
        // Levanta el evento Cancelled y se sale del Popup
        if (Cancelled != null)
            Cancelled(this, new PlayerIndexEventArgs(playerIndex));

        ExitScreen();
    }
}
    </code>
</pre>

Como es posible ver el InputState es recibido como parámetro, por lo que no es necesario instanciarlo ni hacer Update.

## 6.- Listo!

Esto termina la explicación de HandleInput e InputState, si tienes más dudas escríbenos en los comentarios más abajo!

<p class="ribbon-alert b-red" align="justify"><strong>Importante:</strong> No se deben modificar los métodos definidos por defecto en el <strong>InputState.cs</strong> a no ser que se sepa muy bien que es lo que se hace, ya que en diferentes partes del proyecto <strong>ScreenManager</strong> se hacen llamados a los diferentes métodos de esta clase.</p>
