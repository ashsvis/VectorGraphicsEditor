using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Renderers;
using EditorModel.Selections;

namespace SimpleEditor.Controls
{
    public partial class ShadowStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public ShadowStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => RendererDecorator.ContainsType(f.Renderer, typeof(ShadowRendererDecorator))); 
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var shadowStyles = _selection.Select(f => 
                (ShadowRendererDecorator)RendererDecorator.GetDecorator(f.Renderer, typeof(ShadowRendererDecorator))).ToList();

            // copy properties of object to GUI
            _updating++;

            nudOpacity.Value = shadowStyles.GetProperty(f => (decimal)f.Opacity);
            nudOffsetX.Value = shadowStyles.GetProperty(f => (decimal)f.Offset.X);
            nudOffsetY.Value = shadowStyles.GetProperty(f => (decimal)f.Offset.Y);
            lbColor.BackColor = shadowStyles.GetProperty(f => f.Color, Color.Black);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Shadow Fill Style"));

            // get list of objects
            var shadowStyles = _selection.Select(f =>
                (ShadowRendererDecorator)RendererDecorator.GetDecorator(f.Renderer, typeof(ShadowRendererDecorator))).ToList();

            // send values back from GUI to object
            shadowStyles.SetProperty(f => f.Opacity = (int)nudOpacity.Value);
            shadowStyles.SetProperty(f => f.Offset = new PointF((float)nudOffsetX.Value, f.Offset.Y));
            shadowStyles.SetProperty(f => f.Offset = new PointF(f.Offset.X, (float)nudOffsetY.Value));
            shadowStyles.SetProperty(f => f.Color = lbColor.BackColor);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void nudOpacity_ValueChanged(object sender, EventArgs e)
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
