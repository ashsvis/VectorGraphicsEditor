using EditorModel.Figures;
using EditorModel.Selections;
using SimpleEditor.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

        private void AddSubItems(LayerItem item, ListViewItem lvi)
        {
            lvi.SubItems.Add(string.Format("{0}", item.Figures.Count)).Tag = 1;
            for (var i = 2; i < _allowed.Length; i++)
                lvi.SubItems.Add(string.Format("{0}", item.AllowedOperations.HasFlag(_allowed[i]))).Tag = i;
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
                {
                    item = new LayerItem() { Name = lvi.Text };
                    _layer.Layers.Add(item);
                }
                else if (item.Name != lvi.Text) item.Name = lvi.Text;
                UpdateOperations(item, lvi);
            }
            // fire event
            Changed(this, EventArgs.Empty);
            UpdateListView();
            btnApply.Enabled = false;
        }

        LayerAllowedOperations[] _allowed = new LayerAllowedOperations[]
            {
                LayerAllowedOperations.None,
                LayerAllowedOperations.None,
                LayerAllowedOperations.Visible,
                LayerAllowedOperations.Print,
                LayerAllowedOperations.Actived,
                LayerAllowedOperations.Locking,
                LayerAllowedOperations.Color
            };

        private void UpdateOperations(LayerItem item, ListViewItem lvi)
        {
            for (var i = 2; i < lvi.SubItems.Count; i++)
            {
                var state = bool.Parse(lvi.SubItems[i].Text);
                if (state)
                    item.AddAllowedOperation(_allowed[i]);
                else
                    item.RemoveAllowedOperation(_allowed[i]);
            }
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
            var enabled = btnRenameLayer.Enabled = btnDeleteLayer.Enabled = lvLayers.SelectedItems.Count > 0;
            if (!enabled) return;
            var lvi = lvLayers.SelectedItems[0];
            var visible = bool.Parse(lvi.SubItems[2].Text);
            var locking = bool.Parse(lvi.SubItems[5].Text);
            btnRenameLayer.Enabled = btnDeleteLayer.Enabled = !locking;
            lbColor.Enabled = nudOpacity.Enabled = visible && !locking;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void cboxRemoveUnusedLayers_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void lvLayers_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvLayers_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;
        }

        private void lvLayers_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var item = e.Item.Tag as LayerItem;
            if (item == null) return;
            var visible = bool.Parse(e.Item.SubItems[2].Text);
            var locking = bool.Parse(e.Item.SubItems[5].Text);
            switch (e.ColumnIndex)
            {
                case 0:
                case 1:
                    e.DrawDefault = true;
                    break;
                default:
                    var rect = e.Bounds;
                    e.DrawDefault = false;
                    rect.Size = new Size(16, 16);
                    rect.Offset((e.Bounds.Width - 16) / 2, (e.Bounds.Height - 16) / 2);
                    var state = bool.Parse(e.SubItem.Text);
                    // запрещение выбора Actived
                    var disabled = e.ColumnIndex == 4 && (!visible || locking);
                    CheckBoxRenderer.DrawCheckBox(e.Graphics, rect.Location,
                        state 
                           ? disabled ? CheckBoxState.CheckedDisabled : CheckBoxState.CheckedNormal 
                           : disabled ? CheckBoxState.UncheckedDisabled : CheckBoxState.UncheckedNormal);
                    break;
            }
        }

        private void lvLayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var ht = lvLayers.HitTest(e.Location);
            if (ht.Item == null) return;
            var visible = bool.Parse(ht.Item.SubItems[2].Text);
            var locking = bool.Parse(ht.Item.SubItems[5].Text);
            var actived = ht.SubItem.Tag != null && (int)ht.SubItem.Tag == 4;
            var enabled = !actived || actived && visible && !locking;
            bool state;
            if (enabled && bool.TryParse(ht.SubItem.Text, out state))
            {
                ht.SubItem.Text = string.Format("{0}", !state);
                lvLayers.Invalidate();
                lvLayers.SelectedItems.Clear();
                ht.Item.Selected = true;
                lvLayers.FocusedItem = ht.Item;
                btnApply.Enabled = true;
            }
        }
    }
}
