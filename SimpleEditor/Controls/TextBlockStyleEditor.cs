using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Renderers;
using EditorModel.Selections;
using EditorModel.Common;

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
            InitFontNamesSelector();
        }

        private async void InitFontNamesSelector()
        {
            cbFontName.Items.Clear();
            var fontNames = new List<string>();
            foreach (var fontName in await ControlsHelper.GetInstalledFontCollectionAsync())
                cbFontName.Items.Add(fontName);
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => 
                         RendererDecorator.GetBaseRenderer(f.Renderer) is ITextBlock ||
                         RendererDecorator.GetDecorator(f.Renderer, typeof(TextBlockDecorator)) is ITextBlock);
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            var textBlockStyles = from figure in _selection
                        where RendererDecorator.GetBaseRenderer(figure.Renderer) is ITextBlock ||
                              RendererDecorator.GetDecorator(figure.Renderer, typeof(TextBlockDecorator)) is ITextBlock
                        let decorator = RendererDecorator.GetBaseRenderer(figure.Renderer) is ITextBlock ?
                                          RendererDecorator.GetBaseRenderer(figure.Renderer) as ITextBlock :
                                          RendererDecorator.GetDecorator(figure.Renderer, typeof(TextBlockDecorator)) as ITextBlock
                        select decorator;

            var isBezierText = selection.ForAll(f => RendererDecorator.GetBaseRenderer(f.Renderer) is BezierTextRenderer);

            _updating++;

            cbFontName.Text = textBlockStyles.GetProperty(f => f.FontName);
            cbFontSize.Text = textBlockStyles.GetProperty(f => f.FontSize.ToString("0"));
            _fontStyle = textBlockStyles.GetProperty(f => f.FontStyle);
            lbText.Text = textBlockStyles.GetProperty(f => f.Text);
            lbText.TextAlign = textBlockStyles.GetProperty(f => f.Alignment);
            nudLeft.Value = textBlockStyles.GetProperty(f => f.Padding.Left);
            nudTop.Value = textBlockStyles.GetProperty(f => f.Padding.Top);
            nudRight.Value = textBlockStyles.GetProperty(f => f.Padding.Right);
            nudBottom.Value = textBlockStyles.GetProperty(f => f.Padding.Bottom);
            cbWrap.Checked = textBlockStyles.GetProperty(f => f.WordWrap);

            cbWrap.Enabled = nudLeft.Enabled = nudTop.Enabled = nudRight.Enabled = nudBottom.Enabled =
               btnTopLeftAllign.Enabled = btnMiddleLeftAllign.Enabled = btnBottomLeftAllign.Enabled =
               btnTopRightAllign.Enabled = btnMiddleRightAllign.Enabled = btnBottomRightAllign.Enabled = !isBezierText;

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Text Block Style"));

            // get list of objects
            var textBlockStyles = from figure in _selection
                                 where RendererDecorator.GetBaseRenderer(figure.Renderer) is ITextBlock ||
                                       RendererDecorator.GetDecorator(figure.Renderer, typeof(TextBlockDecorator)) is ITextBlock
                                 let decorator = RendererDecorator.GetBaseRenderer(figure.Renderer) is ITextBlock ?
                                                   RendererDecorator.GetBaseRenderer(figure.Renderer) as ITextBlock :
                                                   RendererDecorator.GetDecorator(figure.Renderer, typeof(TextBlockDecorator)) as ITextBlock
                                 select decorator;

            // send values back from GUI to object
            textBlockStyles.SetProperty(f => f.FontName = cbFontName.Text);
            float fontSize;
            if (float.TryParse(cbFontSize.Text, out fontSize))
                textBlockStyles.SetProperty(f => f.FontSize = fontSize);
            textBlockStyles.SetProperty(f => f.FontStyle = _fontStyle);
            textBlockStyles.SetProperty(f => f.Text = lbText.Text);
            textBlockStyles.SetProperty(f => f.Alignment = lbText.TextAlign);
            var padding = new Padding((int)nudLeft.Value, (int)nudTop.Value, 
                                      (int)nudRight.Value, (int)nudBottom.Value);
            textBlockStyles.SetProperty(f => f.Padding = padding);
            textBlockStyles.SetProperty(f => f.WordWrap = cbWrap.Checked);
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
                Helper.UpdateStringFormat(sf, lbText.TextAlign);
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
