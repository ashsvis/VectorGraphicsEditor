using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;
using EditorModel.Selections;

namespace SimpleEditor.Controls
{
    public partial class TextStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection selection;
        private int updating;

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
            this.selection = selection;

            // get list of objects
            var fontStyles = selection.Select(f => f.Renderer as EditorModel.Figures.TextRenderer).ToList();

            // copy properties of object to GUI
            updating++;

            cbFontName.Text = fontStyles.GetProperty(f => f.FontName);
            cbFontSize.Text = fontStyles.GetProperty(f => f.FontSize.ToString());
            tbText.Text = fontStyles.GetProperty(f => f.Text);

            updating--;
        }

        private void UpdateObject()
        {
            if (updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Text Style"));

            // get list of objects
            var fontStyles = selection.Select(f => f.Renderer as EditorModel.Figures.TextRenderer).ToList();

            // send values back from GUI to object
            fontStyles.SetProperty(f => f.FontName = cbFontName.Text);
            fontStyles.SetProperty(f => f.FontSize = float.Parse(cbFontSize.Text));
            fontStyles.SetProperty(f => f.Text = tbText.Text);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void cbFontName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateObject();
        }
    }
}
