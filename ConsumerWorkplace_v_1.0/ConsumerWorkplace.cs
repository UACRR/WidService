using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

/* CONTROLS LIST
 * clientNameCtrlAnketaCompany
 * clientNameCheckBoxPlaces
 * clientNameCtrlRegistrationsCompany
 *
 *
 */

namespace ConsumerWorkplace_v_1._0
{
    public partial class ConsumerWorkplace : Telerik.WinControls.UI.RadForm
    {
        private bool nextPage = false;

        public ConsumerWorkplace()
        {
            InitializeComponent();
            rpvConsumers.ViewElement.Visibility = ElementVisibility.Hidden; // приховання вкладок


        }

        public void Tets()
        {
            
        }

        /// <summary>
        /// Кнопка створення нової анкети юр особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNext_Click(object sender, EventArgs e)
        {
            rpvConsumers.SelectedPage = pageConsumersAnketa;
            pageAllAnketa.SelectedPage = pvConsumerClientName;
        }

        /// <summary>
        /// Кнопка відміни створення анктеи юр особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnCancelAnketa_Click(object sender, EventArgs e)
        {
            nextPage = true;
            ClearDataConsumersControls();
            rpvConsumers.SelectedPage = pageConsumersGrid;
        }


        #region [- - КНОПКИ НА ВКЛАДКІ ДОДАВАННЯ НОВОЇ АНКЕТИ ЮР ОСОБИ - -]

        private void rbtnNextLicType_Click(object sender, EventArgs e)
        {
            if (Validation(1))
            {
                nextPage = true;
                lblTabLicenseTypeClientName.Text = clientNameCtrlAnketaCompany.CompanyFullName;
                pageAllAnketa.SelectedPage = pvConsumerLicenseType;
            }
        }

        private void rbtnNextAnketa_Click(object sender, EventArgs e)
        {
            if (Validation(2))
            {
                nextPage = true;
                anketaCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
                anketaCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
                anketaCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
                pageAllAnketa.SelectedPage = pvConsumerAnketa;
            }
        }

        private void rbtnBackClientName_Click(object sender, EventArgs e)
        {
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerClientName;
        }

        private void rbtnNextManagers_Click(object sender, EventArgs e)
        {
            if (Validation(3))
            {
                managersCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
                managersCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
                managersCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
                nextPage = true;
                pageAllAnketa.SelectedPage = pvConsumerManagers;
            }
        }

        private void rbtnBackLicType_Click(object sender, EventArgs e)
        {
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
        }

        private void rbtnNextPlaces_Click(object sender, EventArgs e)
        {
            if (Validation(4))
            {
                placesCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
                placesCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
                placesCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
                nextPage = true;
                pageAllAnketa.SelectedPage = pvConsumerPlaces;
            }
        }

        private void rbtnBackAnketa_Click(object sender, EventArgs e)
        {
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerAnketa;
        }

        private void rbtnNextBankRequisites_Click(object sender, EventArgs e)
        {
            if (Validation(5))
            {
                bankRequisitesCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
                bankRequisitesCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
                bankRequisitesCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
                nextPage = true;
                pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
            }
        }

        private void rbtnBackManagers_Click(object sender, EventArgs e)
        {
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerManagers;
        }

        private void rbtnNextContract_Click(object sender, EventArgs e)
        {
            if (Validation(6))
            {


                radPdfViewer.LoadDocument("InteractiveForms.pdf");
                nextPage = true;
                pageAllAnketa.SelectedPage = pvConsumerContracts;
            }
        }

        private void rbtnBackPlaces_Click(object sender, EventArgs e)
        {
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerPlaces;
        }

        private void rbtnBackBankRequisites_Click(object sender, EventArgs e)
        {
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
        }


        /// <summary>
        /// Збереження анкети юр особи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnConsumerSave_Click(object sender, EventArgs e)
        {
            if (Validation(7) && MessageBox.Show("Do you want save data?", "Save data?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GetDataSources();
                nextPage = true;
                rpvConsumers.SelectedPage = pageConsumersGrid;
                ClearDataConsumersControls();
            }
            //some code
        }

        #endregion


        /// <summary>
        /// Перевірка на правильність ввеедених даних (Consumers) 
        /// </summary>
        /// <returns></returns>
        private bool Validation(byte type)
        {
        /*
         * 1 - назва клієнта
         * 2 - тип ліцензії
         * 3 - анкета
         * 4 - керівники
         * 5 - майданчики
         * 6 - банківські реквізити
         * 7 - договір
         */
            bool isValid = true;

            switch (type)
            {
                case 1:
                {
                        
                }
                    break;

                case 2:
                {
                        
                }
                    break;

                case 3:
                {
                        
                }
                    break;

                case 4:
                {
                        
                }
                    break;

                case 5:
                {

                }
                    break;

                case 6:
                {

                }
                    break;

                case 7:
                {

                }
                    break;

            }

            return isValid;
        }

        /// <summary>
        /// Очищення даних на контролах розділу споживачів
        /// </summary>
        private void ClearDataConsumersControls()
        {

        }

        public void GetDataSources()
        {
            List<object> objList =new List<object>
            {
                //1
                clientNameCtrlAnketaCompany.DataSource,
                clientNameCtrlRegistrationsCompany.DataSource,
                clientNameCheckBoxPlaces.Checked,
                //2
                licenseTypeCtrlContractConsumerMain.DataSource,
                licenseTypeCtrlContractConsumerDetail.DataSource,
                //3
                anketaCtrlAddressFactual.DataSource,
                anketaCtrlAddressLegal.DataSource,
                //4
                managersCtrlBossNameContactsHead.DataSource,
                managersCtrlBossNameContactsBookkeeper.DataSource,
                managersCtrlBossNameContactsContactPerson.DataSource,
                //5
                placesCtrlConsumerPlaces.GetData(),
                //6
                bankRequisitesCtrlBankAccount.DataSource

            };

            var list = objList.ToList();
        }



        /// <summary>
        /// Переключати вкладки через кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageAllAnketa_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            if (nextPage)
                nextPage = false;
            else
                e.Cancel = true;
        }
    }
}
