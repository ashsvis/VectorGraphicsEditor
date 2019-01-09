using System;
using System.Windows.Forms;
using EditorModel.Figures;

namespace SimpleEditor.Controls
{
    public partial class LayerStyleEditor : UserControl, IEditor<LayerSelectionInfo>
    {
        private Layer _layer;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public LayerStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(LayerSelectionInfo item)
        {
            // check visibility
            Visible = item.Selection.Count == 0 && item.Layer.FillStyle != null;
            if (!Visible) return; // do not build anything

            // remember editing object
            _layer = item.Layer;
            // copy properties of object to GUI
            _updating++;

            lbColor.BackColor = _layer.FillStyle.Color;
            cbVisible.Checked = _layer.FillStyle.IsVisible;
            nudOpacity.Value = _layer.FillStyle.Opacity;

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Layer Fill Style"));
            // send values back from GUI to object
            _layer.FillStyle.Color = lbColor.BackColor;
            _layer.FillStyle.IsVisible = cbVisible.Checked;
            _layer.FillStyle.Opacity = (int)nudOpacity.Value;

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
            var dlg = new ColorDialog { Color = lbColor.BackColor };
            if (dlg.ShowDialog() == DialogResult.OK)
                lbColor.BackColor = dlg.Color;
        }
    }
}
