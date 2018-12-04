using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;
using EditorModel.Common;
using EditorModel.Selections;

namespace SimpleEditor.Controls
{
    public partial class TextStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;

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
                    //[FontFamily: Name=Algerian]
                    var fontName = fontFamily.Substring(18, fontFamily.Length - 19);
                    if (!string.IsNullOrWhiteSpace(fontName))
                        cbFontName.Items.Add(fontName);
                }
            }
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => f.Renderer as EditorModel.Figures.TextRenderer != null); // show the editor only if all figures contain BorderStyle
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var fontStyles = selection.Select(f => f.Renderer as EditorModel.Figures.TextRenderer).ToList();

            // copy properties of object to GUI
            _updating++;

            cbFontName.Text = fontStyles.GetProperty(f => f.FontName);
            cbFontSize.Text = fontStyles.GetProperty(f => f.FontSize.ToString("0"));
            lbText.Text = fontStyles.GetProperty(f => f.Text);
            lbText.TextAlign = fontStyles.GetProperty(f => f.TextAlign);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Text Style"));

            // get list of objects
            var fontStyles = _selection.Select(f => f.Renderer as EditorModel.Figures.TextRenderer).ToList();

            // send values back from GUI to object
            fontStyles.SetProperty(f => f.FontName = cbFontName.Text);
            fontStyles.SetProperty(f => f.FontSize = float.Parse(cbFontSize.Text));
            fontStyles.SetProperty(f => f.Text = lbText.Text);
            fontStyles.SetProperty(f => f.TextAlign = lbText.TextAlign);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void cbFontName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void lbText_Click(object sender, EventArgs e)
        {
            var dlg = new TextDialog {Content = lbText.Text};
            if (dlg.ShowDialog() == DialogResult.OK)
                lbText.Text = dlg.Content;
        }

        private void btnTopLeftAllign_Click(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.TopLeft;
        }

        private void btnTopCenterAllign_Click(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.TopCenter;
        }

        private void btnTopRightAllign_Click(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.TopRight;
        }

        private void btnMiddleLeftAllign_Click(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void btnMiddleCenterAllign_Click(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void btnMiddleRightAllign_Click(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.MiddleRight;
        }

        private void btnBottomLeftAllign_Click(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.BottomLeft;
        }

        private void btnBottomCenterAllign_Click(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.BottomCenter;
        }

        private void btnBottomRightAllign_Click(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.BottomRight;
        }

        private void lbText_Paint(object sender, PaintEventArgs e)
        {
            var text = lbText.Text.Substring(0, 5);
            if (lbText.Text.TrimEnd().Length > 5) text += "...";
            var rect = new Rectangle(0, 0, lbText.Width-1, lbText.Height-1);
            using (var brush = new SolidBrush(lbText.BackColor))
                e.Graphics.FillRectangle(brush, rect);
            using (var sf = new StringFormat())
            {
                EditorModel.Common.Helper.UpdateStringFormat(sf, lbText.TextAlign);
                e.Graphics.DrawString(text, lbText.Font, Brushes.Black, rect, sf);
            }
        }
    }
}
