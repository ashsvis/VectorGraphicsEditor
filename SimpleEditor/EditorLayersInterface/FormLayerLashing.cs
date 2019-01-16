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
    public partial class FormLayerLashing : Form
    {
        public FormLayerLashing()
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
    }
}
