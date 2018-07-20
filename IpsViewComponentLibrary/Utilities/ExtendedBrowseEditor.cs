using System;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Utilities
{
    public class ExtendedBrowseEditor : GridBrowseEditor
    {
        protected override RadElement CreateEditorElement()
        {
            return new ExtendedRadBrowseEditorElement();
        }
    }

    public class ExtendedRadBrowseEditorElement : RadBrowseEditorElement
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(RadBrowseEditorElement);
            }
        }

        public event EventHandler BrowseButtonClick;

        protected override void OnBrowseButtonClick(EventArgs e)
        {
            BrowseButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
