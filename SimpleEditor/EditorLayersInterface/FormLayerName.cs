using System;
using System.Windows.Forms;

namespace SimpleEditor.EditorLayersInterface
{
    public partial class FormLayerName : Form
    {
        private string _operation;
        private string _value;

        public FormLayerName(string operation, string value = "")
        {
            InitializeComponent();
            _operation = operation;
            _value = value;
        }

        private void FormLayerName_Load(object sender, EventArgs e)
        {
            Text = _operation;
            tbName.Text = _value;
        }

        public string GetValue()
        {
            return tbName.Text;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = tbName.Text.Trim().Length > 0;
        }
    }
}
