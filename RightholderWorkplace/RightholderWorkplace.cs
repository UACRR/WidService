using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using ipsFormsDesign.ViewModels.ObjectsRight;
using ipsFormsDesign.ViewModels.Rightholders;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.RightholderControls;
using IpsViewComponentLibrary.Utilities;
using RightholderWorkplace.Localisation;
using RightholderWorkplace.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsViewComponentLibrary.Extensions;
using IPSViewComponentLibraryWPF;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using WPFControls = IPSViewComponentLibraryWPF.Modules.CopyrightRequest;

namespace RightholderWorkplace
{
    public partial class RightholderWorkplace : RadForm
    {
        private const string SaveNewRightholderExternalSuccessMsg = "Нового зовнішнього правовласника/видавництво додано!";
        private const string SaveNewRightholderExternalErrorMsg = "Неможливо додати нового зовнішнього правовласника/видавництво!";

        readonly RightholderService _rightholderService = new RightholderService();
        private CommunityPresenter _communityPresenter;  // main presenter for community

        public RightholderWorkplace()
        {
            var objectrightService = new ObjectRightService();
            IpsGlobal.SetObjectRightDictionaries(objectrightService.GetDictionary());

            var rightholderService = new RightholderService();
            IpsGlobal.SetAnketaDictionaties(rightholderService.GetDictionary());

            var t = Task.Factory.StartNew(async () =>
            {
                var dictionary = await DictionaryService.GetInstance().GetFrameTaskDictionary("uk-UA");
                IpsGlobal.SetFrameTaskDictionary(dictionary);
            });
            t.Wait();
            
            IpsGlobal.Properties.Add("OwnerName", _rightholderService.GetOwnerName()?.Name);

            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new IpsUARadGridLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new RadMessageUkraineLocalizationProvider();

            _communityPresenter = new CommunityPresenter(ctrlCommunity);

            //var copyrightRequestPresenter = new CopyrightRequestPresenter(ctrlCopyrightRequests, _rightholderService);

            var control = new WPFControls.CopyrightRequestControl();
            ehCopyrightRequests.Child = control;

            var control2 = new IPSViewComponentLibraryWPF.Modules.TransferOfRights.TransferOfRightsControl();
            ehTransferOfRights.Child = control2;

            var control3 = new IPSModulesLibrary.ObjectsRightList.ObjectsRightListControl();
            ehObjectRight.Child = control3;

            //oldCopyrightRequestsPage.Item.Visibility = ElementVisibility.Collapsed;
            //oldRightholdersChangePage.Item.Visibility = ElementVisibility.Collapsed;
        }

        public RightholderWorkplace(string[] args)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new IpsUARadGridLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new RadMessageUkraineLocalizationProvider();

            _communityPresenter = new CommunityPresenter(ctrlCommunity);

            //var copyrightRequestPresenter = new CopyrightRequestPresenter(ctrlCopyrightRequests, _rightholderService);

            var control = new WPFControls.CopyrightRequestControl();
            ehCopyrightRequests.Child = control;

            var control2 = new IPSViewComponentLibraryWPF.Modules.TransferOfRights.TransferOfRightsControl();
            ehTransferOfRights.Child = control2;

            var control3 = new IPSModulesLibrary.ObjectsRightList.ObjectsRightListControl();
            ehObjectRight.Child = control3;
        }

        #region Rightholders page

        private void miNewRightholderPerson_Click(object sender, EventArgs e)
        {
            ShowNewRightholder(1);
        }

        private void miNewRigthholderCompany_Click(object sender, EventArgs e)
        {
            ShowNewRightholder(3);
        }

        private static void ShowNewRightholder(int custType)
        {
            // TODO: move to rightholder list control + add AllowAdd property
            using (var rightholderView = new NewRightholderView())
            {
                var rightholderPresenter = new RightholderPresenter(rightholderView);
                rightholderPresenter.ShowNew(custType);
            }
        }

        /// <summary>
        /// Додати зовнішнього правовласника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRightholderExternal_Click(object sender, EventArgs e)
        {
            CreateNewRightholderExternal(1);
        }

        /// <summary>
        /// Додати зовнішнього правовласника (видавництво)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRightholderPublisherExternal_Click(object sender, EventArgs e)
        {
            CreateNewRightholderExternal(3);
        }

        private void CreateNewRightholderExternal(int rhType)
        {
            var customer = _rightholderService.NewExternalRightholder(rhType);
            using (var externalRightHolderForm = new NewRightholderExternalForm())
            {
                externalRightHolderForm.LoadData(customer);
                if (externalRightHolderForm.ShowDialog() == DialogResult.OK)
                {
                    var result = _rightholderService.SaveRightholderExternal(customer);
                    MessageShow.ShowInfoByResult(SaveNewRightholderExternalSuccessMsg, SaveNewRightholderExternalErrorMsg, result);
                }
            }
        }

        private void ctrlRightholderList_RightholderSelected(object sender, RightholderMainView selectedRightholder)
        {
            // TODO: move to rightholder list control + handle double click in two way: 1. For edit by default, 2. For selection using e.Cancel (in rightholder selection control)
            using (var rightholderView = new RightholderView())
            {
                var rightholderPresenter = new RightholderPresenter(rightholderView);
                rightholderPresenter.Show(selectedRightholder.CustId);
            }
        }

        #endregion

        private void RightholderWorkplace_Load(object sender, EventArgs e)
        {

        }
    }
}
