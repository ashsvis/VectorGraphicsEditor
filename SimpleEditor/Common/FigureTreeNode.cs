using EditorModel.Figures;
using System;
using System.Windows.Forms;

namespace SimpleEditor.Common
{
    [Serializable]
    public class FigureTreeNode : TreeNode
    {
        public Figure Figure { get; set; }

        public GroupFigure Group { get; set; }

        public FigureTreeNode(string text) : base (text) { }
    }
}
