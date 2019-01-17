using System;
using System.Windows.Forms;
using EditorModel.Figures;
using SimpleEditor.Controls;
using EditorModel.Selections;

namespace SimpleEditor.EditorLayersInterface
{
    public partial class FormLayerLashing : Form
    {
        private Layer _layer;
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public FormLayerLashing()
        {
            InitializeComponent();
        }

        public void Build(Layer layer, Selection selection)
        {
            _layer = layer;
            _selection = selection;

            // copy properties of object to GUI
            _updating++;

            // ...

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Layer Lashing"));

            // send values back from GUI to object
            // ...

            // fire event
            Changed(this, EventArgs.Empty);

        }

        private void btnCreateLayer_Click(object sender, EventArgs e)
        {
            var frm = new FormLayerName("Create layer");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // ...
                UpdateObject();
            }
        }
    }
}
