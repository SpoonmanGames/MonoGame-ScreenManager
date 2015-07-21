using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ScreenManager.MenuScreen;
using ScreenManager.PantallasBases;
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
                content = new ContentManager(ScreenManagerController.Game.Services, "Content");

            gameFont = ScreenManagerController.Font;

        }

        public override void UnloadContent()
        {
            content.Unload();
        }


        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                        bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            if (IsActive)
            {
                // Apply some random jitter to make the enemy move around.
                const float randomization = 10;

                enemyPosition.X += (float)(random.NextDouble() - 0.5) * randomization;
                enemyPosition.Y += (float)(random.NextDouble() - 0.5) * randomization;

                // Apply a stabilizing force to stop the enemy moving off the screen.
                Vector2 targetPosition = new Vector2(
                    ScreenManagerController.GraphicsDevice.Viewport.Width / 2 - gameFont.MeasureString("Agrega tu Escenario de juego aquí.").X / 2,
                    200);

                enemyPosition = Vector2.Lerp(enemyPosition, targetPosition, 0.05f);

                // TODO: this game isn't very fun! You could probably improve
                // it by inserting something more interesting in this space :-)
            }
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManagerController.SpriteBatch;

            spriteBatch.Begin();

            spriteBatch.DrawString(gameFont, "Agrega tu Escenario de juego aquí.",
                                   enemyPosition, Color.Black);

            spriteBatch.End();
        }

        public override void HandleInput(InputState input)
        {
            PlayerIndex py;
            if (input.IsMenuCancel(null, out py))
            {
                const string message = "¿Está seguro que desea salir?";

                PopupScreen confirmExitMessageBox = new PopupScreen(message);

                confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

                ScreenManagerController.AddScreen(confirmExitMessageBox, py);
            }
        }

        void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManagerController, true, string.Empty, null, new MenuPrincipal("Menú Principal"));
        }
    }
}
