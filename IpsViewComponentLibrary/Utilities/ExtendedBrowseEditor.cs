using System;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Utilities
{
    public class ExtendedBrowseEditor : GridBrowseEditor
    {
        private string editorColumnName;

        public ExtendedBrowseEditor(string columnName) : base()
        {
            editorColumnName = columnName;
        }

        protected override RadElement CreateEditorElement()
        {
            return new ExtendedRadBrowseEditorElement(editorColumnName);
        }
    }

    public class ExtendedRadBrowseEditorElement : RadBrowseEditorElement
    {
        private string editorElementColumnName;

        public event EventHandler BrowseButtonClick;

        public ExtendedRadBrowseEditorElement(string editorColumnName) : base()
        {
            editorElementColumnName = editorColumnName;
        }

        protected override void OnBrowseButtonClick(EventArgs e)
        {
            BrowseButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
