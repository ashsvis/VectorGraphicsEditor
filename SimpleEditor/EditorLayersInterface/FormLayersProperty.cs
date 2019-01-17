using EditorModel.Figures;
using EditorModel.Selections;
using SimpleEditor.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SimpleEditor.EditorLayersInterface
{
    public partial class FormLayersProperty : Form
    {
        private Layer _layer;
        private Selection _selection;
        private int _updating;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public FormLayersProperty()
        {
            InitializeComponent();
        }

        public void Build(Layer layer, Selection selection)
        {
            _layer = layer;
            _selection = selection;

            // copy properties of object to GUI
            _updating++;

            UpdateListView();

            _updating--;
        }

        private void UpdateListView()
        {
            lvLayers.Items.Clear();
            if (_layer.Layers == null) return;
            foreach (var item in _layer.Layers)
            {
                AddItem(item);
            }
        }

        private void AddItem(LayerItem item)
        {
            var lvi = new ListViewItem(item.Name) { Name = item.Name, Tag = item };
            AddSubItems(item, lvi);
            lvLayers.Items.Add(lvi);
        }

        private static void AddSubItems(LayerItem item, ListViewItem lvi)
        {
            lvi.SubItems.Add(string.Format("{0}", item.Figures.Count));
            lvi.SubItems.Add(string.Format("{0}", item.AllowedOperations.HasFlag(LayerAllowedOperations.Visible)));
            lvi.SubItems.Add(string.Format("{0}", item.AllowedOperations.HasFlag(LayerAllowedOperations.Print)));
            lvi.SubItems.Add(string.Format("{0}", item.AllowedOperations.HasFlag(LayerAllowedOperations.Actived)));
            lvi.SubItems.Add(string.Format("{0}", item.AllowedOperations.HasFlag(LayerAllowedOperations.Locking)));
            lvi.SubItems.Add(string.Format("{0}", item.AllowedOperations.HasFlag(LayerAllowedOperations.Lashing)));
            lvi.SubItems.Add(string.Format("{0}", item.AllowedOperations.HasFlag(LayerAllowedOperations.Gluing)));
            lvi.SubItems.Add(string.Format("{0}", item.AllowedOperations.HasFlag(LayerAllowedOperations.Color)));
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Layer Property"));

            // send values back from GUI to object
            // поиск удаляемых
            var found = new List<LayerItem>(_layer.Layers);
            foreach (var item in _layer.Layers)
                foreach (var lvi in lvLayers.Items.Cast<ListViewItem>())
                    if (item == lvi.Tag) found.Remove(item);
            _layer.Layers.RemoveAll(item => found.Contains(item));

            // удаление слоёв с пустыми списками фигур, если указано
            if (cboxRemoveUnusedLayers.Checked)
                _layer.Layers.RemoveAll(item => item.Figures.Count == 0);

            // поиск новых и изменённых
            foreach (var lvi in lvLayers.Items.Cast<ListViewItem>())
            {
                var item = lvi.Tag as LayerItem;
                if (item.Name == null)
                    _layer.Layers.Add(new LayerItem() { Name = lvi.Text });
                else if (item.Name != lvi.Text) item.Name = lvi.Text;
            }
            // fire event
            Changed(this, EventArgs.Empty);
            UpdateListView();
            btnApply.Enabled = false;
        }

        private void btnCreateLayer_Click(object sender, EventArgs e)
        {
            var frm = new FormLayerName("Create layer");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                var item = new LayerItem();
                var lvi = new ListViewItem(frm.GetValue()) { Tag = item };
                AddSubItems(item, lvi);
                lvLayers.Items.Add(lvi);
                btnApply.Enabled = true;
            }
        }

        private void btnRenameLayer_Click(object sender, EventArgs e)
        {
            if (lvLayers.SelectedItems.Count == 0) return;
            var item = lvLayers.SelectedItems[0].Tag as LayerItem;
            if (item == null) return;
            var frm = new FormLayerName("Rename layer", lvLayers.SelectedItems[0].Text);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                lvLayers.SelectedItems[0].Text = lvLayers.SelectedItems[0].Name = frm.GetValue();
                btnApply.Enabled = true;
            }
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            if (lvLayers.SelectedItems.Count == 0) return;
            var item = lvLayers.SelectedItems[0].Tag as LayerItem;
            if (item == null) return;
            if (MessageBox.Show(this, "При удалении этого слоя будут удалены все" + Environment.NewLine +
                "размещённые на нём фигуры. Удалить слой?", "Удаление слоя", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lvLayers.Items.Remove(lvLayers.SelectedItems[0]);
                btnApply.Enabled = true;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void lvLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRenameLayer.Enabled = btnDeleteLayer.Enabled = lvLayers.SelectedItems.Count > 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void cboxRemoveUnusedLayers_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }
    }
}
