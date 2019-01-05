using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Selections;
using EditorModel.Geometry;

namespace SimpleEditor.Controls
{
    public partial class BezierStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public BezierStyleEditor()
        {
            InitializeComponent();
            nudFlatness.Maximum = (decimal)99.99;
            nudFlatness.Minimum = (decimal)0.01;
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f.Geometry as BezierGeometry != null); // show the editor only if all figures contain FillStyle
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var bezierStyles = selection.Select(f => f.Geometry as BezierGeometry).ToList();
            cbIsClosed.Enabled = !bezierStyles.Any(polyG => polyG.Points.Count() < 3);

            // copy properties of object to GUI
            _updating++;

            cbIsClosed.Checked = bezierStyles.GetProperty(f => f.IsClosed);
            cbIsFlatten.Checked = bezierStyles.GetProperty(f => f.IsFlatten);
            nudFlatness.Value = bezierStyles.GetProperty(f => (decimal)f.Flatness, (decimal)0.25);
            nudFlatness.Enabled = cbIsFlatten.Checked;

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Bezier Border Style"));

            // get list of objects
            var bezierStyles = _selection.Select(f => f.Geometry as BezierGeometry).ToList();

            // send values back from GUI to object
            bezierStyles.SetProperty(f => f.IsClosed = cbIsClosed.Checked);
            bezierStyles.SetProperty(f => f.IsFlatten = cbIsFlatten.Checked);
            bezierStyles.SetProperty(f => f.Flatness = (float)nudFlatness.Value);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void cbIsClosed_CheckedChanged(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void cbIsFlatten_CheckedChanged(object sender, EventArgs e)
        {
            nudFlatness.Enabled = cbIsFlatten.Checked;
            UpdateObject();
        }
    }
}
