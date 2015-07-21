using ScreenManager.MenuScreen;
using ScreenManager.PantallasBases;

namespace ScreenManagerShowcase
{
    class MenuEscenario : BaseMenuScreen
    {
        public MenuEscenario(string menuTitle)
            : base(menuTitle)
        {
            MenuEntry escenario_uno = new MenuEntry(this, "Escenario 1");

            escenario_uno.Selected += MenuEscenarioUnoSelected;

            MenuEntries.Add(escenario_uno);
        }

        private void MenuEscenarioUnoSelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManagerController, true, string.Empty, null, new Escenario());
        }
    }
}
