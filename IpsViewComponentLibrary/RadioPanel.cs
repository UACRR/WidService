using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public class RadioPanel : Panel
    {
        public event EventHandler SelectedValueChanged = delegate { };

        int _selectedValue;
        public int SelectedValue
        {
            get
            {
                return _selectedValue;
            }
            set
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
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            var radioButton = e.Control as RadRadioButton;
            if (radioButton != null)
                radioButton.CheckStateChanged += radioButton_CheckedChanged;
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadRadioButton)sender;
            int val = 0;
            if (radio.IsChecked && radio.Tag != null
                 && int.TryParse(radio.Tag.ToString(), out val))
            {
                _selectedValue = val;
                SelectedValueChanged(this, new EventArgs());
            }
        }
    }
}
