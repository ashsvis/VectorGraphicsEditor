using System.Windows.Forms;

namespace SimpleEditor.Controls
{
    public partial class TextDialog : Form
    {
        public TextDialog()
        {
            InitializeComponent();
        }

        public string Content
        {
            get { return tbText.Text; }
            set { tbText.Text = value; }
        }
    }
}
