using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Figures;
using EditorModel.Selections;
using SimpleEditor.Common;

namespace SimpleEditor.Controls
{
    public partial class PictureStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;
        private readonly List<Figure> _figures;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public PictureStyleEditor()
        {
            InitializeComponent();
            _figures = new List<Figure>();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f is GroupFigure);
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var pictureFillStyles = _selection.Select(f => f as GroupFigure).ToList();

            // copy properties of object to GUI
            _updating++;

            _figures.Clear();
            _figures.AddRange(pictureFillStyles.GetProperty(f => f.Figures));

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Image Fill Style"));

            // get list of objects
            var pictureFillStyles = _selection.Select(f => f as GroupFigure).ToList();

            // send values back from GUI to object
            pictureFillStyles.SetProperty(f => f.Figures = _figures);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void lbPicture_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = @"Группа фигур графического редактора (*.sge)|*.sge" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            var loaded = LoadSelection(dlg.FileName);
            if (loaded == null) return;
            _figures.Clear();
            foreach (var fig in loaded)
                _figures.Add(fig.DeepClone());
            UpdateObject();
        }

        private IEnumerable<Figure> LoadSelection(string fileName)
        {
            using (var stream = new MemoryStream())
            {
                Helper.Decompress(fileName, stream);
                stream.Position = 0;
                var versionInfo = (VersionInfo)Helper.LoadFromStream(stream);
                if (versionInfo.Version != Helper.GetVersionInfo().Version)
                {
                    MessageBox.Show(this, @"Формат загружаемого файла не поддерживается.",
                                    @"Загрузка файла отменена",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return (List<Figure>)Helper.LoadFromStream(stream);
            }
        }
    }
}
