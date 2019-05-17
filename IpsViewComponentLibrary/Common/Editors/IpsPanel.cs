using System.ComponentModel;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common.Editors
{
    public class IpsPanel : RadPanel
    {
        private bool _borderVisible = false;
        public override string ThemeClassName => typeof(RadPanel).FullName;

        /// <summary>
        /// Visible border of panel. Default value is false.
        /// </summary>
        [Browsable(true)]
        public bool BorderVisible
        {
            get => _borderVisible;
            set
            {
                _borderVisible = value;
                PanelElement.PanelBorder.Width = value ? 1f : 0f;
            }
        }
    }
}
