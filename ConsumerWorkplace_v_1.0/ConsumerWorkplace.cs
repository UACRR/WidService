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
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
using Telerik.WinControls;
using Telerik.WinControls.UI;


namespace ConsumerWorkplace_v_1._0
{
    public partial class ConsumerWorkplace : Telerik.WinControls.UI.RadForm, IConsumerForm
    {
        private bool nextPage = false;
        private sbyte validTabs = 0;
        private SwitchPresenter _presenterSmallRights;
        private SwitchPresenterBigRights _presenterBigRights;
        private ConsumerService _serviceSmallRights, _serviceBigRights;

        public event Func<bool> Save;
        
        public ConsumerWorkplace()
        {
            InitializeComponent();
        }

        public ConsumerWorkplace(TypeRights rights)
        {
            InitializeComponent();
            ThemeResolutionService.ApplicationThemeName = "Office2013Light";


            switch (rights)
            {
                case TypeRights.BigRights:
                {
                    RadTreeNode[] list = new[]
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                        new RadTreeNode {Text = "Діючі", Value = ConsumerFilterEnum.Working},
                        new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.NotAccepted},
                        new RadTreeNode {Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation},
                        new RadTreeNode {Text = "Не розподіленні", Value = ConsumerFilterEnum.ForDistribution}
                    };

                    foreach (var item in list)
                    {
                        treeViewBR.Nodes.Add(item);
                    }

                    _serviceBigRights = new ConsumerService();
                    _presenterBigRights = new SwitchPresenterBigRights(mainViewSwitcherBR, _serviceBigRights, treeViewBR);
                    treeViewBR.SelectedNode = treeViewBR.Nodes["Всі"];

                        
                    // * * * END CASE
                }
                    break;

                case TypeRights.SmallRights:
                {
                    RadTreeNode[] list = new[]
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                        new RadTreeNode {Text = "Діючі", Value = ConsumerFilterEnum.Working},
                        new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.NotAccepted},
                        new RadTreeNode {Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation},
                        new RadTreeNode {Text = "Не розподіленні", Value = ConsumerFilterEnum.ForDistribution}
                    };
                        
                    foreach (var item in list)
                    {
                        treeViewSR.Nodes.Add(item);
                    }

                    _serviceSmallRights = new ConsumerService();
                    _presenterSmallRights = new SwitchPresenter(mainViewSwitcherSR, _serviceSmallRights, treeViewSR);
                    treeViewSR.SelectedNode = treeViewSR.Nodes["Всі"];

                    // * * * * END CASE
                }
                    break;

                case TypeRights.All:
                {
                    RadTreeNode[] list = new[]
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                        new RadTreeNode {Text = "Діючі", Value = ConsumerFilterEnum.Working},
                        new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.NotAccepted},
                        new RadTreeNode {Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation},
                        new RadTreeNode {Text = "Не розподіленні", Value = ConsumerFilterEnum.ForDistribution}
                    };
                    RadTreeNode[] list2 = new[]
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                        new RadTreeNode {Text = "Діючі", Value = ConsumerFilterEnum.Working},
                        new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.NotAccepted},
                        new RadTreeNode {Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation},
                        new RadTreeNode {Text = "Не розподіленні", Value = ConsumerFilterEnum.ForDistribution}
                    };
                    
                    foreach (var item in list)
                    {
                        treeViewSR.Nodes.Add(item);
                    }
                    foreach (var item in list2)
                    {
                        treeViewBR.Nodes.Add(item);
                    }

                        _serviceSmallRights = new ConsumerService();
                    _presenterSmallRights = new SwitchPresenter(mainViewSwitcherSR, _serviceSmallRights, treeViewSR);
                    treeViewSR.SelectedNode = treeViewSR.Nodes["Всі"];
                    
                    
                    _serviceBigRights = new ConsumerService();
                    _presenterBigRights = new SwitchPresenterBigRights(mainViewSwitcherBR, _serviceBigRights, treeViewBR);
                    treeViewBR.SelectedNode = treeViewBR.Nodes["Всі"];
                    
                    
                    
                     // * * * * END CASE
                }
                    break;
            }
        }

        public Customer ReturnCustomer()
        {
            return _cust;
        }
        


        Customer _cust = null;
        LicenseAgrParam curLicAgreement = null;
        public void SetData(ICustomer data)
        {
            _cust = (Customer)data;
            var licAgr = _cust.Client.LicenseAgreement.FirstOrDefault();
            curLicAgreement = licAgr?.LicenseAgrParam.Where(item => item.LicVersion == licAgr.LicVersion).SingleOrDefault();
        }

        public void GetData(ICustomer data)
        {
            throw new NotImplementedException();
        }

        private AnketaDictionaties _dic = null;
        public void SetDictionary(AnketaDictionaties dic)
        {
            _dic = dic;
        }


        public Func<IList<ConsumerMainView>> getMainViewData { get; set; }
        public Func<int, Customer> NewCustomer { get; set; }
        public Func<int, Customer> GetCustomer { get; set; }
        public Func<Customer, bool> SaveCustomer { get; set; }

        public void EndPresenterLink()
        {
            if (getMainViewData != null)
            {
                var list = getMainViewData();
                consumerMainViewBindingSource.DataSource = list;
            }
        }
    }


}
