using System;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    public class RadioPanel : Panel
    {
        public event EventHandler SelectedValueChanged = delegate { };

        int? _selectedValue;
        public int? SelectedValue
        {
            get => _selectedValue;
            set
            {
                if (value != null)
                {
                    int val = 0;
                    var radioButton = this.Controls.OfType<RadRadioButton>()
                        .FirstOrDefault(radio =>
                            radio.Tag != null
                           && int.TryParse(radio.Tag.ToString(), out val) && val == value);

                    if (radioButton != null)
                    {
                        radioButton.IsChecked = true;
                        _selectedValue = val;
                    }
                }
                else
                {
                    _selectedValue = null;
                }
                OnSelectedValueChanged();
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is RadRadioButton radioButton)
                radioButton.CheckStateChanged += radioButton_CheckedChanged;
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadRadioButton)sender;
            if (radio.IsChecked && radio.Tag != null && int.TryParse(radio.Tag.ToString(), out int val))
            {
                _selectedValue = val;
                OnSelectedValueChanged();
            }
        }

        private void OnSelectedValueChanged()
        {
            SelectedValueChanged(this, new EventArgs());
        }
    }
}
