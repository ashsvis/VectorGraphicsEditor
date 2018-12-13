using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Geometry;
using EditorModel.Selections;

namespace SimpleEditor.Controls
{
    public partial class TextStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;
        private StringAlignment _alignment;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public TextStyleEditor()
        {
            InitializeComponent();
            cbFontName.Items.Clear();
            using (var ifc = new InstalledFontCollection())
            {
                var ie = ifc.Families.GetEnumerator();
                while (ie.MoveNext())
                {
                    var fontFamily = ie.Current.ToString();
                    //вид возвращаемой строки: [FontFamily: Name=Algerian]
                    var fontName = fontFamily.Substring(18, fontFamily.Length - 19);
                    if (!string.IsNullOrWhiteSpace(fontName))
                        cbFontName.Items.Add(fontName);
                }
            }
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f.Geometry is TextGeometry);
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var fontStyles = _selection.Select(f => f.Geometry as TextGeometry).ToList();

            // copy properties of object to GUI
            _updating++;

            cbFontName.Text = fontStyles.GetProperty(f => f.FontName);
            cbFontSize.Text = fontStyles.GetProperty(f => f.FontSize.ToString("0"));
            lbText.Text = fontStyles.GetProperty(f => f.Text);
            _alignment = fontStyles.GetProperty(f => f.Alignment);
            switch (_alignment)
            {
                case StringAlignment.Near:
                    lbText.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case StringAlignment.Center:
                    lbText.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case StringAlignment.Far:
                    lbText.TextAlign = ContentAlignment.MiddleRight;
                    break;
            }

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Text Style"));

            // get list of objects
            var fontStyles = _selection.Select(f => f.Geometry as TextGeometry).ToList();

            // send values back from GUI to object
            fontStyles.SetProperty(f => f.FontName = cbFontName.Text);
            fontStyles.SetProperty(f => f.FontSize = float.Parse(cbFontSize.Text));
            fontStyles.SetProperty(f => f.Text = lbText.Text);
            switch (_alignment)
            {
                case StringAlignment.Near:
                    lbText.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case StringAlignment.Center:
                    lbText.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case StringAlignment.Far:
                    lbText.TextAlign = ContentAlignment.MiddleRight;
                    break;
            }
            fontStyles.SetProperty(f => f.Alignment = _alignment);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void cbFontName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void lbText_Click(object sender, EventArgs e)
        {
            var dlg = new TextDialog { Content = lbText.Text };
            if (dlg.ShowDialog() == DialogResult.OK)
                lbText.Text = dlg.Content;
        }

        private void btnLeftAllign_Click(object sender, EventArgs e)
        {
            _alignment = StringAlignment.Near;
            UpdateObject();
        }

        private void btnCenterAllign_Click(object sender, EventArgs e)
        {
            _alignment = StringAlignment.Center;
            UpdateObject();
        }

        private void btnRightAllign_Click(object sender, EventArgs e)
        {
            _alignment = StringAlignment.Far;
            UpdateObject();
        }
    }
}
