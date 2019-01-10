using System;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Renderers;
using EditorModel.Selections;

namespace SimpleEditor.Controls
{
    public partial class GlowStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public GlowStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => RendererDecorator.ContainsType(f.Renderer, typeof(GlowRendererDecorator)));
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var glowStyles = _selection.Select(f =>
                 (GlowRendererDecorator)RendererDecorator.GetDecorator(f.Renderer, typeof(GlowRendererDecorator))).ToList();

            // copy properties of object to GUI
            _updating++;

            lbColor.BackColor = glowStyles.GetProperty(f => f.Color);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Glow Fill Style"));

            // get list of objects
            var glowStyles = _selection.Select(f =>
                (GlowRendererDecorator)RendererDecorator.GetDecorator(f.Renderer, typeof(GlowRendererDecorator))).ToList();

            // send values back from GUI to object
            glowStyles.SetProperty(f => f.Color = lbColor.BackColor);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void lbColor_BackColorChanged(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void lbColor_Click(object sender, EventArgs e)
        {
            var dlg = new ColorDialog { Color = lbColor.BackColor };
            if (dlg.ShowDialog() == DialogResult.OK)
                lbColor.BackColor = dlg.Color;
        }
    }
}
