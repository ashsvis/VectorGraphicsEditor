using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Image _image;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public ImageStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => RendererDecorator.GetBaseRenderer(f.Renderer) is ImageRenderer);
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var imageFillStyles = _selection.Select(f =>
                            (ImageRenderer) RendererDecorator.GetBaseRenderer(f.Renderer)).ToList();

            // copy properties of object to GUI
            _updating++;

            _image = imageFillStyles.GetProperty(f => f.Image);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Image Fill Style"));

            // get list of objects
            //var imageFillStyles = _selection.Select(f =>
            //                (ImageRenderer)RendererDecorator.GetBaseRenerer(f.Renderer)).ToList();

            //imageFillStyles.SetProperty(f => f.Image = (Bitmap)_image);
            foreach (var fig in _selection.Where(f => 
                RendererDecorator.GetBaseRenderer(f.Renderer) is ImageRenderer))
            {
                var renderer = (ImageRenderer)RendererDecorator.GetBaseRenderer(fig.Renderer);
                var firstIsEmpty = renderer.Image.Bitmap == null;
                renderer.Image = (Bitmap)_image;
                if (firstIsEmpty)
                {
                    var bounds = fig.GetTransformedPath().Path.GetBounds();
                    var x = bounds.X;
                    var y = bounds.Y;
                    var width = renderer.Image.Bitmap.Width;
                    var height = renderer.Image.Bitmap.Height;
                    var m = new Matrix();
                    m.Translate(x + width / 2f, y + height / 2f);
                    m.Scale(width, height);
                    fig.Transform.Matrix = m;
                }
            }

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void lbImage_Click(object sender, EventArgs e)
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
