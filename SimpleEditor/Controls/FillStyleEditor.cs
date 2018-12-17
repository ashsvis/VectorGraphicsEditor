using System;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Selections;

namespace SimpleEditor.Controls
{
    public partial class FillStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public FillStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll( f => f.Style.FillStyle != null);
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var fillStyles = selection.Select(f => f.Style.FillStyle).ToList();

            // copy properties of object to GUI
            _updating++;

            lbColor.BackColor = fillStyles.GetProperty(f => f.Color);
            cbVisible.Checked = fillStyles.GetProperty(f => f.IsVisible);
            nudOpacity.Value = fillStyles.GetProperty(f => f.Opacity, 255);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Fill Style"));

            // get list of objects
            var fillStyles = _selection.Select(f => f.Style.FillStyle).ToList();

            // send values back from GUI to object
            fillStyles.SetProperty(f => f.Color = lbColor.BackColor);
            fillStyles.SetProperty(f => f.IsVisible = cbVisible.Checked);
            fillStyles.SetProperty(f => f.Opacity = (int)nudOpacity.Value);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void cbVisible_CheckedChanged(object sender, EventArgs e)
        {
            lbColor.Enabled = lbOpacity.Enabled = nudOpacity.Enabled = cbVisible.Checked;
            UpdateObject();
        }

        private void lbColor_Click(object sender, EventArgs e)
        {
            var dlg = new ColorDialog {Color = lbColor.BackColor};
            if (dlg.ShowDialog() == DialogResult.OK)
                lbColor.BackColor = dlg.Color;
        }
    }
}
