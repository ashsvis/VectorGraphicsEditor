using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Renderers;
using EditorModel.Selections;

namespace SimpleEditor.Controls
{
    public partial class ImageStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public ImageStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f.Renderer as ImageRenderer != null); // show the editor only if all figures contain FillStyle
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var imageFillStyles = selection.Select(f => f.Renderer as ImageRenderer).ToList();

            // copy properties of object to GUI
            _updating++;

            lbImage.Image = imageFillStyles.GetProperty(f => f.Image);

            cbStretch.Enabled = lbImage.Image != null;

            cbStretch.Checked = imageFillStyles.GetProperty(f => f.IsStretch);

            cbTile.Enabled = !cbStretch.Checked && lbImage.Image != null;

            cbTile.Checked = imageFillStyles.GetProperty(f => f.IsTile);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Image Fill Style"));

            // get list of objects
            var imageFillStyles = _selection.Select(f => f.Renderer as ImageRenderer).ToList();

            // send values back from GUI to object
            imageFillStyles.SetProperty(f => f.Image = lbImage.Image);
            imageFillStyles.SetProperty(f => f.IsStretch = cbStretch.Checked);
            imageFillStyles.SetProperty(f => f.IsTile = cbTile.Checked);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void lbImage_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog {Filter = @"*.png;*.jpg;*.bmp|*.png;*.jpg;*.bmp"};
            if (dlg.ShowDialog() != DialogResult.OK) return;
            lbImage.Image = Image.FromFile(dlg.FileName);
            cbStretch.Enabled = lbImage.Image != null;
            cbTile.Enabled = !cbStretch.Checked && lbImage.Image != null;
            UpdateObject();
        }

        private void cbStretch_CheckedChanged(object sender, EventArgs e)
        {
            cbTile.Enabled = !cbStretch.Checked;
            UpdateObject();
        }
    }
}
