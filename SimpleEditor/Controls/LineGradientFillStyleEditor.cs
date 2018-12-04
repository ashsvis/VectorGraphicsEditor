using System;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Selections;
using EditorModel.Style;

namespace SimpleEditor.Controls
{
    public partial class LineGradientFillStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public LineGradientFillStyleEditor()
        {
            InitializeComponent();
            nudAngle.Maximum = decimal.MaxValue;
            nudAngle.Minimum = decimal.MinValue;
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f.Style.FillStyle is LineGradientFill); // show the editor only if all figures contain FillStyle
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var fillStyles = selection.Select(f => f.Style.FillStyle as LineGradientFill).ToList();

            // copy properties of object to GUI
            _updating++;

            lbGradientColor.BackColor = fillStyles.GetProperty(f => f.GradientColor);
            nudAngle.Value = fillStyles.GetProperty(f => (decimal)f.Angle);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Line Gradient Fill Style"));

            // get list of objects
            var fillStyles = _selection.Select(f => f.Style.FillStyle as LineGradientFill).ToList();

            // send values back from GUI to object
            fillStyles.SetProperty(f => f.GradientColor = lbGradientColor.BackColor);
            fillStyles.SetProperty(f => f.Angle = (float)nudAngle.Value);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void lbGradientColor_BackColorChanged(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void lbGradientColor_Click(object sender, EventArgs e)
        {
            var dlg = new ColorDialog { Color = lbGradientColor.BackColor };
            if (dlg.ShowDialog() == DialogResult.OK)
                lbGradientColor.BackColor = dlg.Color;
        }

        private void nudAngle_ValueChanged(object sender, EventArgs e)
        {
            UpdateObject();
        }
    }
}
