using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Petri_Net_Editor.App.Views;

namespace Petri_Net_Editor
{
    static class Program
    {
        /// <summary>
        /// Main entry point to program.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MarkedPetriGraphEditFormView());
        }
    }
}
