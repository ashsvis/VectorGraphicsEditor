using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
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
            cbWrap.Items.Clear();
            cbWrap.Items.AddRange(GetWrapModeNames()); // получение всех имён доступных типов линий
            cbWrap.SelectedIndex = 0;
        }

        static readonly WrapMode[] WrapModeArray = (WrapMode[])Enum.GetValues(typeof(WrapMode));
        static readonly int WrapModeCount = WrapModeArray.Length - 1;

        private object[] GetWrapModeNames()
        {
            var wrapNameArray = Enum.GetNames(typeof(WrapMode));
            var names = new object[WrapModeCount];
            for (var i = 0; i < WrapModeCount; i++)
                names[i] = wrapNameArray[i];
            return names;
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
            lbWrap.Enabled = cbWrap.Enabled = lbScale.Enabled = nudScale.Enabled = _image != null;

            cbWrap.SelectedIndex = (int)textureFillStyles.GetProperty(f => f.WrapMode);
            nudScale.Value = (decimal)textureFillStyles.GetProperty(f => f.Scale, 1);

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
            textureFillStyles.SetProperty(f => f.WrapMode = (WrapMode)cbWrap.SelectedIndex);
            textureFillStyles.SetProperty(f => f.Scale = (float)nudScale.Value);

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
            lbWrap.Enabled = cbWrap.Enabled = lbScale.Enabled = nudScale.Enabled = _image != null;
            UpdateObject();
        }

        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            UpdateObject();
        }
    }
}
