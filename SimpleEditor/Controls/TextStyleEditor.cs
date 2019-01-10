using System;
using System.Collections.Generic;
using System.Drawing;
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
        private FontStyle _fontStyle;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public TextStyleEditor()
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
            Visible = selection.ForAll(f => f.Geometry is TextGeometry);
            if (!Visible) return; // do not build anything

            // remember editing object
            _selection = selection;

            // get list of objects
            var fontStyles = _selection.Select(f => f.Geometry as TextGeometry).ToList();

            // copy properties of object to GUI
            _updating++;

            cbFontName.Text = fontStyles.GetProperty(f => f.FontName);
            _fontStyle = fontStyles.GetProperty(f => f.FontStyle);
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
            fontStyles.SetProperty(f => f.FontStyle = _fontStyle);
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
