using System;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Selections;
using EditorModel.Style;

namespace SimpleEditor.Controls
{
    public partial class GradientStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public GradientStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f.Style.FillStyle is IGradientFill);
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var fillStyles = selection.Select(f => f.Style.FillStyle as IGradientFill).ToList();

            // copy properties of object to GUI
            _updating++;

            lbGradientColor.BackColor = fillStyles.GetProperty(f => f.GradientColor);
            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Gradient Fill Style"));

            // get list of objects
            var fillStyles = _selection.Select(f => f.Style.FillStyle as IGradientFill).ToList();

            // send values back from GUI to object
            fillStyles.SetProperty(f => f.GradientColor = lbGradientColor.BackColor);

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
    }
}
