using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Common;
using EditorModel.Selections;
using EditorModel.Style;

namespace SimpleEditor.Controls
{
    public partial class TextureStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;
        private Image _image;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public TextureStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => FillDecorator.ContainsType(f.Style.FillStyle, typeof(TextureFill)));
            // show the editor only if all figures contain BorderStyle
            if (!Visible) return; // do not build anything            

            // remember editing object
            _selection = selection;

            // get list of objects
            var textureFillStyles = _selection.Select(f =>
                (TextureFill)FillDecorator.GetDecorator(f.Style.FillStyle, typeof(TextureFill))).ToList();

            // copy properties of object to GUI
            _updating++;

            _image = textureFillStyles.GetProperty(f => f.Image);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Texture Fill Style"));

            // get list of objects
            var textureFillStyles = _selection.Select(f =>
                (TextureFill)FillDecorator.GetDecorator(f.Style.FillStyle, typeof(TextureFill))).ToList();

            // send values back from GUI to object
            textureFillStyles.SetProperty(f => f.Image = (Bitmap)_image);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void btnLoadPicture_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = @"*Файлы графических форматов (.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _image = (Bitmap)Image.FromFile(dlg.FileName);
            UpdateObject();
        }
    }
}
