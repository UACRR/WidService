using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.ViewModels.Consumer;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RegisterControls
{
    public partial class RegisterCCIDView : RadForm
    {
        public BindingList<RegisterItemViewModel> RegisterItemList { get; private set; } = new BindingList<RegisterItemViewModel>();
        public BindingList<RegisterExtra> RegisterExtraList { get; private set; } = new BindingList<RegisterExtra>();

        public RegisterCCIDView()
        {
            InitializeComponent();

            dtCreateDate.ReadOnly = true;

            ddlStatus.SetDataSource(IpsGlobal.ObjectRightDictionaries.RegisterStatuses);
            ddlLicCode.SetDataSource(IpsGlobal.AnketaDictionaties.agrLicenseType);
            ddlAlgorithmId.SetDataSource(IpsGlobal.AnketaDictionaties.algorithmType);

            ctrlRegisterItemList.DataSource = RegisterItemList;
            ctrlRegisterItemList.DataSourceRegisterExtra = RegisterExtraList;

            navigatorPanel.CurrentPageChanged += NavigatorPane_UpdateDataNeed;
            navigatorPanel.PageSizeChanged += (o, e) =>
            {
                navigatorPanel.TotalPages = CCIDRegisterItems.Count / navigatorPanel.PageSize;
                NavigatorPane_UpdateDataNeed(o, e);
            };

        }

        private void NavigatorPane_UpdateDataNeed(object sender, EventArgs e)
        {
            UpdateRegisterItemsList();
        }

        private RegisterCCIDPresenter _presenter;
        public RegisterCCIDPresenter Presenter
        {
            set
            {
                if (_presenter == null)
                    _presenter = value;
            }
        }

        public Register Register
        {
            get => bsRegister.DataSource as Register;
            set
            {
                if (bsRegister.DataSource != value)
                {
                    bsRegister.DataSource = value;
                    txtPeriodName.Text = value?.Rm?.Period?.PeriodName;
                    ddlLicCode.SelectedValue = value?.Rm?.Period?.Lic?.LicCode;
                    UpdateButtonsEnable();
                }
            }
        }

        public ConsumerSmallRightView ConsumerInfo
        {
            set => txtConsumerName.Text = value.Name;
        }

        private List<object[]> _CCIDRegisterItems;
        public List<object[]> CCIDRegisterItems
        {
            get => _CCIDRegisterItems;
            set
            {
                _CCIDRegisterItems = value;

                navigatorPanel.TotalPages = value.Count / navigatorPanel.PageSize;
                UpdateRegisterItemsList();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;

                if (value)
                    waitingBar.StartWaiting();
                else
                    waitingBar.StopWaiting();
            }
        }

        public void Run()
        {
            SetupRegisterItemListElementVisible();
            ShowDialog();
        }

        private void UpdateButtonsEnable()
        {
            var status = Register.RgStatus;
            
            ddlStatus.SelectedValue = status;
            btnBeginSync.Enabled = status == 12;
            btnBeginDistribution.Enabled = status == 7;
            btnBeginPayment.Enabled = status == 13;
        }

        private void SetupRegisterItemListElementVisible()
        {
            ctrlRegisterItemList.ShowDurationUse = false;
            ctrlRegisterItemList.ShowObjectDuration = false;
            ctrlRegisterItemList.ShowAuthors = true;

            ctrlRegisterItemList.AllowLinkCommand = false;
            ctrlRegisterItemList.AllowUnlinkCommand = false;
            ctrlRegisterItemList.AllowFindCommand = false;
            ctrlRegisterItemList.AllowCreateObjectCommand = false;
            ctrlRegisterItemList.AllowShowDeleteCommand = false;

            ctrlRegisterItemList.AllowShowDurationItem = false;
        }

        private async void UpdateRegisterItemsList()
        {
            var list = new ObservableListSource<RegisterItemViewModel>();

            IsBusy = true;
            await Task.Factory.StartNew(() =>
            {
                var listForConver = CCIDRegisterItems.Skip(navigatorPanel.Skip).Take(navigatorPanel.Take).ToList();
                foreach (var obj in listForConver)
                {
                    var item = new RegisterItemViewModel
                    {
                        RegId = (int)(long)obj[0],
                        ObjId = (int?)(long?)obj[1],
                        Wic = (int?)(long?)obj[2],
                        ItemName = obj[3] as string,
                        AuthorMusic = obj[4] as string,
                        AuthorText = obj[5] as string,
                        Performer = obj[6] as string,
                        CountUse = (int?)(long?)obj[7],
                        ObjectName = obj[8] as string,
                        ObjectAuthors = obj[9] as string,
                        ObjectPerformers = obj[10] as string,
                        ObjectSource = obj[11] as string,
                    };

                    list.Add(item);
                }
            });
            IsBusy = false;

            ctrlRegisterItemList.DataSource = list;
        }

        private void btnBeginSync_Click(object sender, EventArgs e)
        {
            _presenter.BeginSync();
        }

        private void btnBeginDistribution_Click(object sender, EventArgs e)
        {
            _presenter.BeginDistribution();
        }

        private void btnBeginPayment_Click(object sender, EventArgs e)
        {
            _presenter.BeginPayment();
        }
    }
}
