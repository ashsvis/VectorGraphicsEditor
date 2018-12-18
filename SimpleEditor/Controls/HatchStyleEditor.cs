using System;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EditorModel.Selections;
using System.Drawing.Drawing2D;
using EditorModel.Style;

namespace SimpleEditor.Controls
{
    public partial class HatchStyleEditor : UserControl, IEditor<Selection>
    {
        private Selection _selection;
        private int _updating;
        private HatchStyle _hatchFill;
        private Color _color;

        public event EventHandler<ChangingEventArgs> StartChanging = delegate { };
        public event EventHandler<EventArgs> Changed = delegate { };

        public HatchStyleEditor()
        {
            InitializeComponent();
            cbHatch.Items.Clear();
            cbHatch.Items.AddRange(GetHatchNames()); // получение всех имён доступных типов линий
            cbHatch.SelectedIndex = 0;
            _hatchFill = (HatchStyle)cbHatch.SelectedIndex;
            _color = lbHatchColor.BackColor;
        }

        static readonly HatchStyle[] HatchStyleArray = (HatchStyle[])Enum.GetValues(typeof(HatchStyle));

        static readonly int HatchStyleCount = HatchStyleArray.Length - 3;

        private static object[] GetHatchNames()
        {
            var hatchNameArray = Enum.GetNames(typeof(HatchStyle));
            var names = new object[HatchStyleCount];
            for (var i = 0; i < HatchStyleCount; i++)
                names[i] = hatchNameArray[i];
            return names;
        }

        public void Build(Selection selection)
        {
            // check visibility
            Visible = selection.ForAll(f => FillDecorator.ContainsType(f.Style.FillStyle, typeof(HatchFill)));
            // show the editor only if all figures contain BorderStyle
            if (!Visible) return; // do not build anything            

            // remember editing object
            _selection = selection;

            // get list of objects
            var hatchStyles = _selection.Select(f =>
                (HatchFill)FillDecorator.GetDecorator(f.Style.FillStyle, typeof(HatchFill))).ToList();

            // copy properties of object to GUI
            _updating++;

            cbHatch.SelectedIndex = (int)hatchStyles.GetProperty(f => f.HatchStyle, _hatchFill);
            lbHatchColor.BackColor = hatchStyles.GetProperty(f => f.HatchColor, _color);

            _updating--;
        }

        private void UpdateObject()
        {
            if (_updating > 0) return; // we are in updating mode

            // fire event
            StartChanging(this, new ChangingEventArgs("Hatch Fill Style"));

            // get list of objects
            var hatchStyles = _selection.Select(f =>
                (HatchFill)FillDecorator.GetDecorator(f.Style.FillStyle, typeof(HatchFill))).ToList();

            // send values back from GUI to object
            _hatchFill = (HatchStyle)cbHatch.SelectedIndex;
            hatchStyles.SetProperty(f => f.HatchStyle = _hatchFill);
            _color = lbHatchColor.BackColor;
            hatchStyles.SetProperty(f => f.HatchColor = _color);

            // fire event
            Changed(this, EventArgs.Empty);
        }

        private void cbHatch_DrawItem(object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            // Draw the background of the item.
            e.DrawBackground();
            var rect = new Rectangle(e.Bounds.X, e.Bounds.Top, e.Bounds.Width - 1, e.Bounds.Height - 1);
            rect.Inflate(-4, 0);
            using (var brush = new HatchBrush((HatchStyle)e.Index, Color.Black, Color.White))
            {
                g.FillRectangle(brush, rect);
                g.DrawRectangle(Pens.Black, rect);
            }
            e.DrawFocusRectangle();

        }

        private void lbGradientColor_BackColorChanged(object sender, EventArgs e)
        {
            UpdateObject();
        }

        private void lbHatchColor_Click(object sender, EventArgs e)
        {
            var dlg = new ColorDialog { Color = lbHatchColor.BackColor };
            if (dlg.ShowDialog() == DialogResult.OK)
                lbHatchColor.BackColor = dlg.Color;
        }

        private void cbHatch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateObject();
        }
    }
}
