using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugFormForControls
{
    public partial class ContractControl : UserControl
    {
        public string Number => rtxtBoxNumber.Text;
        public DateTime NumberFromDate => rdtPickerBirth.Value;

        public ContractControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Очищення введених даних
        /// </summary>
        public void ClearData()
        {
            rtxtBoxNumber.Clear();
            rdtPickerBirth.SetToNullValue();
        }
    }
}
