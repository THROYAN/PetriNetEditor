using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Drawing;

using Petri_Net_Editor.App.Models;
using Petri_Net_Editor.App.Models.Wrappers;
using Petri_Net_Editor.App.Controllers;

using MagicLibrary.MathUtils.PetriNetsUtils;

namespace Petri_Net_Editor.App.Views
{
    public class ColouredPetriNetGraphEditView : PetriNetGraphEditView
    {
        public PetriNetExecuteState executeState { get; set; }
        public ColouredPetriNet petriNet { get; set; }

        public uint marks { get; set; }
        public ColouredPetriGraphWrapper mPetriGraph { get { return graphWrapper as ColouredPetriGraphWrapper; } }
        public new ColouredPetriGraphEditorController MainController { get { return GetController("MainController") as ColouredPetriGraphEditorController; } }
        public Timer timer { get; set; }
        public int itterator { get; set; }
        public int count { get; set; }

        public ColouredPetriNetGraphEditView(Control control)
            : base(control)
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            Controllers.RemoveAll(controller => controller.Name == "MainController");
            Controllers.Add(new ColouredPetriGraphEditorController(this, "MainController"));
            MainController.ViewLoad();
            Control.Paint += new PaintEventHandler(Control_Paint);
        }

        void Control_Paint(object sender, PaintEventArgs e)
        {
            petriNet.GetAvailableTransitions().ToList().ForEach(t => graphWrapper[t.Value as string].Draw(e.Graphics, Pens.Red));
        }

        void timer_Tick(object sender, EventArgs e)
        {
            petriNet.ExecuteRandomTransition();
            itterator++;
            Refresh();
            if (itterator > count || petriNet.GetAvailableTransitions().Length == 0
                || executeState != PetriNetExecuteState.AutoExecute
                || action != GraphEditor.App.Views.GraphEditAction.SomethingElse
            )
            {
                timer.Stop();
                executeState = PetriNetExecuteState.SelectTransition;
            }
        }

        public string InputWindow(string text, string caption, string defaultValue)
        {
            return Interaction.InputBox(text, caption, defaultValue);
        }

        public void StartTimer(int interval, int count)
        {
            itterator = 1;
            timer.Interval = interval;
            this.count = count;
            timer.Start();
        }
    }
}
