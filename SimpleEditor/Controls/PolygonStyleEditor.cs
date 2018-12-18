using System;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Geometry;
using EditorModel.Selections;

namespace SimpleEditor.Controls
{
    public partial class PolygonStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public PolygonStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f.Geometry as PolygoneGeometry != null); // show the editor only if all figures contain FillStyle
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var polygoneStyles = selection.Select(f => f.Geometry as PolygoneGeometry).ToList();
            cbIsClosed.Enabled = !polygoneStyles.Any(polyG => polyG.Points.Count() < 3);

            // copy properties of object to GUI
            _updating++;

            cbIsClosed.Checked = polygoneStyles.GetProperty(f => f.IsClosed);
            cbIsSmoothed.Checked = polygoneStyles.GetProperty(f => f.IsSmoothed);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Polygone Border Style"));

            // get list of objects
            var polygoneStyles = _selection.Select(f => f.Geometry as PolygoneGeometry).ToList();

            // send values back from GUI to object
            polygoneStyles.SetProperty(f => f.IsClosed = cbIsClosed.Checked);
            polygoneStyles.SetProperty(f => f.IsSmoothed = cbIsSmoothed.Checked);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void cbIsClosed_CheckedChanged(object sender, EventArgs e)
        {
            UpdateObject();
        }
    }
}
