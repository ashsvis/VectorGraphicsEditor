using System;
using System.Windows.Forms;

namespace SimpleEditor
{
    public partial class FormTextEditor : Form
    {
        private readonly string _text;

        public FormTextEditor(string text = "")
        {
            _text = text;
            InitializeComponent();
        }

        private void FormTextEditor_Load(object sender, EventArgs e)
        {
            tbText.Text = _text;
        }

        public string GetText { get { return tbText.Text; } }
    }
}
