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
            pageAllAnketa.SelectedPage = pvConsumerClientName;
        }

        private void rbtnCancelAnketa_Click(object sender, EventArgs e)
        {
            ClearDataConsumersControls();
            rpvConsumers.SelectedPage = pageConsumersGrid;
        }

        private void rbtnNextLicType_Click(object sender, EventArgs e)
        {
            if (Validation())
                pageAllAnketa.SelectedPage = pvConsumerLicenseType;
        }

        private void rbtnNextAnketa_Click(object sender, EventArgs e)
        {
            if (Validation())
                pageAllAnketa.SelectedPage = pvConsumerAnketa;
        }

        private void rbtnBackClientName_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerClientName;
        }

        private void rbtnNextManagers_Click(object sender, EventArgs e)
        {
            if (Validation())
                pageAllAnketa.SelectedPage = pvConsumerManagers;
        }

        private void rbtnBackLicType_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
        }

        private void rbtnNextPlaces_Click(object sender, EventArgs e)
        {
            if (Validation())
                pageAllAnketa.SelectedPage = pvConsumerPlaces;
        }

        private void rbtnBackAnketa_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerAnketa;
        }

        private void rbtnNextBankRequisites_Click(object sender, EventArgs e)
        {
            if (Validation())
                pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
        }

        private void rbtnBackManagers_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerManagers;
        }

        private void rbtnNextContract_Click(object sender, EventArgs e)
        {
            if (Validation())
                pageAllAnketa.SelectedPage = pvConsumerContracts;
        }

        private void rbtnBackPlaces_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerPlaces;
        }

        private void rbtnBackBankRequisites_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
        }

        private void rbtnConsumerSave_Click(object sender, EventArgs e)
        {
            if (Validation() && MessageBox.Show("Do you want save data?", "Save data?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rpvConsumers.SelectedPage = pageConsumersGrid;
                ClearDataConsumersControls();
            }
            //some code
        }

        /// <summary>
        /// Перевірка на правильність ввеедених даних (Consumers) 
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            bool isValid = true;


            return isValid;
        }

        /// <summary>
        /// Очищення даних на контролах розділу споживачів
        /// </summary>
        private void ClearDataConsumersControls()
        {

        }

    }
}
