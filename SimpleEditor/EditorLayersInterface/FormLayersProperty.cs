using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEditor.EditorLayersInterface
{
    public partial class FormLayersProperty : Form
    {
        public FormLayersProperty()
        {
            InitializeComponent();
        }

        private void btnCreateLayer_Click(object sender, EventArgs e)
        {
            var frm = new FormLayerName("Create layer");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnRenameLayer_Click(object sender, EventArgs e)
        {
            var frm = new FormLayerName("Rename layer");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void btnDeleteLayer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "При удалении этого слоя будут удалены все" + Environment.NewLine +
                "размещённые на нём фигуры. Удалить слой?", "Удаление слоя", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

            }
        }
    }
}
