using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Selections;
using EditorModel.Renderers;

namespace SimpleEditor.Controls
{
    public partial class ArrowStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;
        private ArrowPosition _arrowPosition;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public ArrowStyleEditor()
        {
            InitializeComponent();
            cbPosition.Items.Clear();
            cbPosition.Items.Add(ArrowPosition.End);
            cbPosition.Items.Add(ArrowPosition.Start);
            cbPosition.Items.Add(ArrowPosition.Both);
            cbPosition.SelectedIndex = 0;
            _arrowPosition = (ArrowPosition)cbPosition.SelectedIndex;
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => RendererDecorator.ContainsType(f.Renderer, typeof(ArrowRendererDecorator)));
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var arrowStyles = _selection.Select(f =>
                (ArrowRendererDecorator)RendererDecorator.GetDecorator(f.Renderer, typeof(ArrowRendererDecorator))).ToList();

            // copy properties of object to GUI
            _updating++;

            cbColor.Checked = arrowStyles.GetProperty(f => f.IsOtherColorFilled);
            lbColor.BackColor = arrowStyles.GetProperty(f => f.OtherColor, Color.White);
            cbPosition.SelectedIndex = (int)arrowStyles.GetProperty(f => f.ArrowPosition, _arrowPosition);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Arrow Style"));

            // get list of objects
            var arrowStyles = _selection.Select(f =>
                (ArrowRendererDecorator)RendererDecorator.GetDecorator(f.Renderer, typeof(ArrowRendererDecorator))).ToList();

            // send values back from GUI to object
            arrowStyles.SetProperty(f => f.OtherColor = lbColor.BackColor);
            arrowStyles.SetProperty(f => f.IsOtherColorFilled = cbColor.Checked);
            _arrowPosition = (ArrowPosition)cbPosition.SelectedIndex;
            arrowStyles.SetProperty(f => f.ArrowPosition = _arrowPosition);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void cbColor_CheckedChanged(object sender, EventArgs e)
        {
            lbColor.Enabled = cbColor.Checked;
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
