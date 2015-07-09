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

        enum Formatos
        {
            CS,
            JAR,
            CPP,
        }

        static Formatos formatoActual = Formatos.CS;

        static string[] lenguaje = { "C#", "Java", "C++" };
        static int lenguajeActual = 0;

        static bool super = false;
        static int vida = 23;

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

        private void SetMenuEntryText()
        {
            formatoMenuEntry.Text = "Formato preferido: " + formatoActual;
            lenguajeMenuEntry.Text = "Lenguaje: " + lenguaje[lenguajeActual];
            superMenuEntry.Text = "Super: " + (super ? "on" : "off");
            vidasMenuEntry.Text = "vida: " + vida;
        }

        void FormatoMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            formatoActual++;

            if (formatoActual > Formatos.CPP)
                formatoActual = 0;

            SetMenuEntryText();
        }


        void LenguajeMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            lenguajeActual = (lenguajeActual + 1) % lenguaje.Length;

            SetMenuEntryText();
        }

        void SuperMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            super = !super;

            SetMenuEntryText();
        }

        void VidaMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ++vida;

            SetMenuEntryText();
        }

    }
}
