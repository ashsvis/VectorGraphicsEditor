using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Renderers;
using EditorModel.Selections;
using TextRenderer = EditorModel.Renderers.TextRenderer;

namespace SimpleEditor.Controls
{
    public partial class TextBlockStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;
        private FontStyle _fontStyle;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public TextBlockStyleEditor()
        {
            InitializeComponent();
            cbFontName.Items.Clear();
            foreach (var fontName in ControlsHelper.GetInstalledFontCollection())
                cbFontName.Items.Add(fontName);
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => RendererDecorator.GetBaseRenderer(f.Renderer) is TextRenderer);
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var fontStyles = _selection.Select(f =>
                            (TextRenderer)RendererDecorator.GetBaseRenderer(f.Renderer)).ToList();

            // copy properties of object to GUI
            _updating++;

            cbFontName.Text = fontStyles.GetProperty(f => f.FontName);
            cbFontSize.Text = fontStyles.GetProperty(f => f.FontSize.ToString("0"));
            _fontStyle = fontStyles.GetProperty(f => f.FontStyle);
            lbText.Text = fontStyles.GetProperty(f => f.Text);
            lbText.TextAlign = fontStyles.GetProperty(f => f.Alignment);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Text Block Style"));

            // get list of objects
            var fontStyles = _selection.Select(f =>
                            (TextRenderer)RendererDecorator.GetBaseRenderer(f.Renderer)).ToList();

            // send values back from GUI to object
            fontStyles.SetProperty(f => f.FontName = cbFontName.Text);
            fontStyles.SetProperty(f => f.FontSize = float.Parse(cbFontSize.Text));
            fontStyles.SetProperty(f => f.FontStyle = _fontStyle);
            fontStyles.SetProperty(f => f.Text = lbText.Text);
            fontStyles.SetProperty(f => f.Alignment = lbText.TextAlign);
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
            var text = lbText.Text.Length >= 5 ? lbText.Text.Substring(0, 5) : lbText.Text;
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

        private void btnTopLeftAllignClick(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.TopLeft;
            UpdateObject();
        }

        private void btnTopCenterAllignClick(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.TopCenter;
            UpdateObject();
        }

        private void btnTopRightAllignClick(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.TopRight;
            UpdateObject();
        }

        private void btnMiddleLeftAllignClick(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.MiddleLeft;
            UpdateObject();
        }

        private void btnMiddleCenterAllignClick(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.MiddleCenter;
            UpdateObject();
        }

        private void btnMiddleRightAllignClick(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.MiddleRight;
            UpdateObject();
        }

        private void btnBottomLeftAllignClick(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.BottomLeft;
            UpdateObject();
        }

        private void btnBottomCenterAllignClick(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.BottomCenter;
            UpdateObject();
        }

        private void btnBottomRightAllignClick(object sender, EventArgs e)
        {
            lbText.TextAlign = ContentAlignment.BottomRight;
            UpdateObject();
        }

        private void btnTextBold_Click(object sender, EventArgs e)
        {
            if (_fontStyle.HasFlag(FontStyle.Bold))
                _fontStyle = _fontStyle & ~FontStyle.Bold;
            else
                _fontStyle = _fontStyle | FontStyle.Bold;
            UpdateObject();
        }

        private void btnTextItalic_Click(object sender, EventArgs e)
        {
            if (_fontStyle.HasFlag(FontStyle.Italic))
                _fontStyle = _fontStyle & ~FontStyle.Italic;
            else
                _fontStyle = _fontStyle | FontStyle.Italic;
            UpdateObject();
        }

        private void btnTextUnderline_Click(object sender, EventArgs e)
        {
            if (_fontStyle.HasFlag(FontStyle.Underline))
                _fontStyle = _fontStyle & ~FontStyle.Underline;
            else
                _fontStyle = _fontStyle | FontStyle.Underline;
            UpdateObject();
        }
    }
}
