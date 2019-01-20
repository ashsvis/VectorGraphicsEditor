using System;
using System.Windows.Forms;
using EditorModel.Figures;
using SimpleEditor.Controls;
using EditorModel.Selections;
using System.Linq;

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

            UpdateCheckListbox();

            _updating--;
        }

        private void UpdateCheckListbox()
        {
            clbLayers.Items.Clear();
            foreach (var item in _layer.Layers.Where(layer => 
                     !layer.AllowedOperations.HasFlag(LayerAllowedOperations.Locking)))
            {
                var index = clbLayers.Items.Add(item);
                foreach (var fig in _selection)
                {
                    if (item.Figures.Contains(fig))
                    {
                        clbLayers.SetItemChecked(index, true);
                        break;
                    }
                }
            }
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Layer Lashing"));

            // send values back from GUI to object
            for (var i = 0; i < clbLayers.Items.Count; i++)
            {
                var layer = clbLayers.Items[i] as LayerItem;
                if (layer == null) continue;
                if (clbLayers.GetItemChecked(i))
                {
                    foreach (var fig in _selection)
                    {
                        if (!layer.Figures.Contains(fig))
                            layer.Figures.Add(fig);
                    }
                }
                else
                {
                    foreach (var fig in _selection)
                    {
                        if (layer.Figures.Contains(fig))
                            layer.Figures.Remove(fig);
                    }
                }
            }

            // fire event
            Changed(this, EventArgs.Empty);

            UpdateCheckListbox();
        }

        private void btnCreateLayer_Click(object sender, EventArgs e)
        {
            var frm = new FormLayerName("Create layer");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // fire event
                StartChanging(this, new ChangingEventArgs("Create layer"));
                var layer = new LayerItem() { Name = frm.GetValue() };
                _layer.Layers.Add(layer);
                Changed(this, EventArgs.Empty);
                _updating++;
                UpdateCheckListbox();
                _updating--;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < clbLayers.Items.Count; i++)
                clbLayers.SetItemChecked(i, true);
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < clbLayers.Items.Count; i++)
                clbLayers.SetItemChecked(i, false);
        }
    }
}
