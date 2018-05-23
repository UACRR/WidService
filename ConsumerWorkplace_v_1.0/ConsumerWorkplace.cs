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
using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using Telerik.WinControls;



namespace ConsumerWorkplace_v_1._0
{
    public partial class ConsumerWorkplace : Telerik.WinControls.UI.RadForm
    {
        private bool nextPage = false;
        private sbyte validTabs = 0;

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
            validTabs = 0;
            nextPage = false;
        }


        #region [- - КНОПКИ НА ВКЛАДКІ ДОДАВАННЯ НОВОЇ АНКЕТИ ЮР ОСОБИ - -]

        private void rbtnNextLicType_Click(object sender, EventArgs e)
        {
            lblTabLicenseTypeClientName.Text = clientNameCtrlAnketaCompany.CompanyFullName;
            nextPage = true;
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
        }

        private void rbtnNextAnketa_Click(object sender, EventArgs e)
        {
            nextPage = true;
                anketaCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
                anketaCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
                anketaCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
                pageAllAnketa.SelectedPage = pvConsumerAnketa;
        }

        private void rbtnBackClientName_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerClientName;
        }

        private void rbtnNextManagers_Click(object sender, EventArgs e)
        {
            nextPage = true;

            managersCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
                managersCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
                managersCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
                pageAllAnketa.SelectedPage = pvConsumerManagers;

        }

        private void rbtnBackLicType_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerLicenseType;
        }

        private void rbtnNextPlaces_Click(object sender, EventArgs e)
        {
            nextPage = true;
                placesCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            placesCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
                placesCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
                pageAllAnketa.SelectedPage = pvConsumerPlaces;
        }

        private void rbtnBackAnketa_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerAnketa;
        }

        private void rbtnNextBankRequisites_Click(object sender, EventArgs e)
        {
            nextPage = true;
                bankRequisitesCtrlTitleLbl.ClientName = clientNameCtrlAnketaCompany.CompanyFullName;
            bankRequisitesCtrlTitleLbl.ContractBeginDate = licenseTypeCtrlContractConsumerMain.ContractBeginDate;
                bankRequisitesCtrlTitleLbl.ContractNumber = licenseTypeCtrlContractConsumerMain.ContractNumber;
                pageAllAnketa.SelectedPage = pvConsumerBankRequisites;
        }

        private void rbtnBackManagers_Click(object sender, EventArgs e)
        {
            pageAllAnketa.SelectedPage = pvConsumerManagers;
        }

        private void rbtnNextContract_Click(object sender, EventArgs e)
        {
            nextPage = true;
                radPdfViewer.LoadDocument("InteractiveForms.pdf");
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
                rpvConsumers.SelectedPage = pageConsumersGrid;
                ClearDataConsumersControls();
            }
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
                    if (!clientNameCtrlAnketaCompany.Validator())
                        isValid = false;
                    if(!clientNameCtrlRegistrationsCompany.Validator())
                        isValid = false;
                }
                    break;

                case 2:
                {
                    if (!licenseTypeCtrlContractConsumerMain.Validator())
                        isValid = false;
                    if (!licenseTypeCtrlContractConsumerDetail.Validator())
                        isValid = false;
                }
                    break;

                case 3:
                {
                    if (!anketaCtrlAddressFactual.Validator())
                        isValid = false;
                    if (!anketaCtrlAddressLegal.Validator())
                        isValid = false;
                    //додаткові поля
                }
                    break;

                case 4:
                {
                    if (!managersCtrlBossNameContactsBookkeeper.Validator())
                        isValid = false;
                    if (!managersCtrlBossNameContactsContactPerson.Validator())
                        isValid = false;
                    if (!managersCtrlBossNameContactsHead.Validator())
                        isValid = false;

                    //додаткові поля
                }
                    break;

                case 5:
                {
                        // майданчики
                }
                    break;

                case 6:
                {
                    if (!bankRequisitesCtrlBankAccount.Validator())
                        isValid = false;
                }
                    break;

                case 7:
                {
                        //друк PDF
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
            clientNameCtrlAnketaCompany.ClearData();
            clientNameCtrlRegistrationsCompany.ClearData();
            licenseTypeCtrlContractConsumerMain.ClearData();
            
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
            // У М О В У
            if ( Validation(Convert.ToByte(pageAllAnketa.SelectedPage.TabIndex+1)))
            {
                if (e.Page.TabIndex <= validTabs)
                {
                    e.Cancel = false;
                    nextPage = false;
                }
                else if (pageAllAnketa.SelectedPage.TabIndex == validTabs && nextPage)
                {
                    validTabs++;
                    //pageAllAnketa.Pages[validTabs].Item.TextParams.foreColor = Color.DarkGray;
                    e.Cancel = false;
                    nextPage = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
                e.Cancel = true;
        }
    }
}
