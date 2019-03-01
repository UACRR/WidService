using System;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Utilities
{
    public class ValueSelectionEventArgs : EventArgs
    {
        public string Value { get; set; }
    }

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

        public event EventHandler<ValueSelectionEventArgs> ValueSelection;

        protected override void OnBrowseButtonClick(EventArgs e)
        {
            var eventArgs = new ValueSelectionEventArgs { Value = this.Value };

            ValueSelection?.Invoke(this, eventArgs);

            this.Value = eventArgs.Value;
        }
    }
}
