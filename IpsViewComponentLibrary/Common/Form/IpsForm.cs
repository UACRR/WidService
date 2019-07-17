using IpsViewComponentLibrary.Common.Editors;
using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common.Form
{
    public class IpsForm : RadForm
    {
        public event EventHandler ReadOnlyChanged;

        private bool _readOnly = false;
        public bool ReadOnly
        {
            get => _readOnly;
            set
            {
                _readOnly = value;

                SetReadOnlyForChildControls(Controls);

                OnReadOnlyChanged();
            }
        }

        protected virtual void OnReadOnlyChanged()
        {
            ReadOnlyChanged?.Invoke(this, EventArgs.Empty);
        }

        private void SetReadOnlyForChildControls(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c is IpsDropDownList ddl)
                {
                    ddl.ReadOnly = _readOnly;
                }
                else if (c is IpsTextBox txt)
                {
                    txt.ReadOnly = _readOnly;
                }
                else if (c is IpsDateTimePicker dt)
                {
                    dt.SetReadOnly(_readOnly);
                }
                else if (c is IpsMaskedEditBox meb)
                {
                    meb.SetReadOnly(_readOnly);
                }
                else if (c is RadGridView gv)
                {
                    gv.ReadOnly = _readOnly;
                }
                else if (c is RadCheckBox cb)
                {
                    cb.ReadOnly = _readOnly;
                }

                if (c.HasChildren)
                {
                    SetReadOnlyForChildControls(c.Controls);
                }
            }
        }
    }
}
