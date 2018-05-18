using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ConsumerWorkplace_v_1._0
{
    public partial class ConsumerWorkplace : Telerik.WinControls.UI.RadForm
    {
        public ConsumerWorkplace()
        {
            InitializeComponent();
            Tets();
        }

        public void Tets()
        {
            rpvConsumers.ViewElement.Visibility = ElementVisibility.Hidden;
        }

        private void rbtnNext_Click(object sender, EventArgs e)
        {
            rpvConsumers.SelectedPage = pageConsumersAnketa;
        }

        private void rbtnCancelAnketa_Click(object sender, EventArgs e)
        {
            rpvConsumers.SelectedPage = pageConsumersGrid;
        }

        private void rbtnNextLicType_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
        }

    }
}
