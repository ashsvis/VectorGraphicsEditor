using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Selections;
using EditorModel.Geometry;

namespace SimpleEditor.Controls
{
    public partial class WedgeStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public WedgeStyleEditor()
        {
            InitializeComponent();
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f.Geometry as WedgeGeometry != null);
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var wedgeStyles = selection.Select(f => f.Geometry as WedgeGeometry).ToList();

            // copy properties of object to GUI
            _updating++;

            nudStartAngle.Value = wedgeStyles.GetProperty(f => (decimal)f.StartAngle);
            nudSweepAngle.Value = wedgeStyles.GetProperty(f => (decimal)f.SweepAngle);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Wedge Style"));

            // get list of objects
            var wedgeStyles = _selection.Select(f => f.Geometry as WedgeGeometry).ToList();

            // send values back from GUI to object
            wedgeStyles.SetProperty(f => f.StartAngle = (float)nudStartAngle.Value);
            wedgeStyles.SetProperty(f => f.SweepAngle = (float)nudSweepAngle.Value);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void nudStartAngle_ValueChanged(object sender, EventArgs e)
        {
            UpdateObject();
        }
    }
}
