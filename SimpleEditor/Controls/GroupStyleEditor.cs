using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Common;
using EditorModel.Figures;
using EditorModel.Renderers;
using EditorModel.Selections;

namespace SimpleEditor.Controls
{
    public partial class GroupStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;
        private readonly List<Figure> _figures;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public GroupStyleEditor()
        {
            InitializeComponent();
            _figures = new List<Figure>();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f is GroupFigure) && selection.Any(f =>
            {
                var groupFigure = f as GroupFigure;
                return groupFigure != null && groupFigure.Figures.Count() == 1;
            });

            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var pictureFillStyles = _selection.Select(f => f as GroupFigure).ToList();

            // copy properties of object to GUI
            _updating++;

            _figures.Clear();
            _figures.AddRange(pictureFillStyles.GetProperty(f => f.Figures, 
                                                            pictureFillStyles.First().Figures));

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Group Selection Style"));

            // get list of objects
            var pictureFillStyles = _selection.Select(f => f as GroupFigure).ToList();

            // send values back from GUI to object
            pictureFillStyles.SetProperty(f => f.Figures = _figures);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void lbPicture_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = @"Файл редактора (*.vge)|*.vge" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                var loaded = SaverLoader.LoadSelection(dlg.FileName);
                _figures.Clear();
                foreach (var fig in loaded)
                    _figures.Add(fig.DeepClone());
                UpdateObject();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, @"Загрузка файла отменена",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbJoin_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateObject();
        }
    }
}
