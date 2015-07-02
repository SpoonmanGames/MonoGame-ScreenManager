using ScreenManager.MenuScreen;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenManagerShowcase
{
    class MenuPrincipal : BaseMenuScreen
    {
        public MenuPrincipal(string menuTitle)
            : base(menuTitle)
        {
            MenuEntry escenarios = new MenuEntry(this, "Escenarios");
            MenuEntry opciones = new MenuEntry(this, "Opciones");

            // Event Handler suscrito al evento MenuEscenarioSelected, esto se activará al presionar Enter sobre la opción "Escenarios"
            escenarios.Selected += MenuEscenarioSelected;
            // Event Handler suscrito al evento MenuOpcionesSelected, esto se activará al presionar Enter sobre la opción "Opciones"
            opciones.Selected += MenuOpcionesSelected;

            MenuEntries.Add(escenarios);
            MenuEntries.Add(opciones);
        }

        private void MenuEscenarioSelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManagerController.AddScreen(new MenuEscenario("Selecciona un Escenario"), e.PlayerIndex);
        }

        private void MenuOpcionesSelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManagerController.AddScreen(new MenuOpciones("Configura las opciones"), e.PlayerIndex);
        }
    }
}
