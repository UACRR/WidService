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
using ConsumerWorkplace_v_1._0.Presenters;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Presenters;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace ConsumerWorkplace_v_1._0
{
    public partial class ConsumerWorkplace : Telerik.WinControls.UI.RadForm, IConsumerForm
    {
        private SmallRightPresenter _smallRightPresenter;// main presenter for small right
        private BigRightPresenter _bigRightPresenter;    // main presenter for big right
        private PartnerPresenter _partnerPresenter;      // main presenter for partner
        private CommunityPresenter _communityPresenter;  // main presenter for community
        private DBFPresenter _dbfPresenter;              // main presenter for importDBF
        private readonly ConsumerService _consumerMainService = new ConsumerService(); // main service
        private readonly CommunityService _communityService = new CommunityService();
        private readonly PartnerService _partnerService = new PartnerService();

        public event Func<bool> Save;

        public ConsumerWorkplace(TypeRights rights)
        {
            IpsGlobal.SetAnketaDictionaties((new ConsumerService()).GetDictionary());
            _dbfPresenter = new DBFPresenter();
            IpsGlobal.addInstance(typeof(IUniqueChecker), new UniqueCheckerPresenter());
            IpsGlobal.addInstance(typeof(IDBFPresenter), _dbfPresenter);
            InitializeComponent();
            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new IpsUARadGridLocalizationProvider();


            switch (rights)
            {
                case TypeRights.BigRights:
                {
                    RadTreeNode[] list = new[]
                    {
                        new RadTreeNode
                        {
                            Text = "Генеральні договори", Value = TypeBRDocument.GenAgreement, Selected = true,
                            Nodes  =
                            {
                                new RadTreeNode { Text = "Всі", Value = ConsumerFilterEnum.All },
                                new RadTreeNode { Text = "Активні", Value = ConsumerFilterEnum.Working },
                                new RadTreeNode { Text = "На акцепті", Value = ConsumerFilterEnum.NotAccepted},
                                new RadTreeNode { Text = "Не підтверджені", Value = ConsumerFilterEnum.NotConfirmed },
                                new RadTreeNode { Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation },
                                new RadTreeNode { Text = "Закриті", Value = ConsumerFilterEnum.Closed },
                            }
                        },
                        new RadTreeNode
                        {
                            Text = "Ліцензійні договори", Value = TypeBRDocument.LicAgreement,
                            Nodes  =
                            {
                                new RadTreeNode { Text = "Всі", Value = ConsumerFilterEnum.All },
                                new RadTreeNode { Text = "Активні", Value = ConsumerFilterEnum.Working },
                                new RadTreeNode { Text = "Не активні", Value = ConsumerFilterEnum.NotActive },
                                new RadTreeNode { Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation }
                            }
                        },
                        new RadTreeNode
                        {
                            Text = "Заявки", Value = TypeBRDocument.Request,
                            Nodes  =
                            {
                                new RadTreeNode { Text = "Всі", Value = ConsumerFilterEnum.All },
                                new RadTreeNode { Text = "Активні", Value = ConsumerFilterEnum.Working },
                                new RadTreeNode { Text = "Не підтверджені", Value = ConsumerFilterEnum.NotActive },
                                new RadTreeNode { Text = "На акцепті", Value = ConsumerFilterEnum.None },
                                new RadTreeNode { Text = "На погодженні", Value = ConsumerFilterEnum.None},
                                new RadTreeNode { Text = "Відхилені", Value = ConsumerFilterEnum.None },
                            }

                        },
                        new RadTreeNode
                        {
                            Text = "Довідки", Value = TypeBRDocument.Reference,
                            Nodes  =
                            {
                                new RadTreeNode { Text = "Всі", Value = ConsumerFilterEnum.All },
                                new RadTreeNode { Text = "Активні", Value = ConsumerFilterEnum.Working },
                                new RadTreeNode { Text = "Не підтверджені", Value = ConsumerFilterEnum.NotActive },
                                new RadTreeNode { Text = "На акцепті", Value = ConsumerFilterEnum.None },
                                new RadTreeNode { Text = "На погодженні", Value = ConsumerFilterEnum.None},
                                new RadTreeNode { Text = "Відхилені", Value = ConsumerFilterEnum.None },
                            }

                        },
                        new RadTreeNode {Text = "Не розподіленні", Value = ConsumerFilterEnum.ForDistribution},
                        new RadTreeNode {Text = "Борг", Value = ConsumerFilterEnum.Debt},
                        new RadTreeNode {Text = "Відсутні Роз.Листи", Value = ConsumerFilterEnum.UnattachData}
                    };

                    foreach (var item in list)
                        treeViewBR.Nodes.Add(item);
                    
                    _bigRightPresenter = new BigRightPresenter(_consumerMainService, _partnerService, treeViewBR, mainGridBigRight);
                    IpsGlobal.addInstance(typeof(IUpdateProviderBigRight), _bigRightPresenter);
                        // treeViewBR.SelectedNode = treeViewBR.Nodes["Всі"];


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

                    _consumerMainService = new ConsumerService();
                    _smallRightPresenter = new SmallRightPresenter(_consumerMainService, _partnerService, treeViewSR, mainGridSmallRight);
                    IpsGlobal.addInstance(typeof(IUpdateProviderSmallRight), _smallRightPresenter);

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
                    foreach (var item in list)
                    {
                        treeViewSR.Nodes.Add(item);
                    }

                    _smallRightPresenter = new SmallRightPresenter(_consumerMainService, _partnerService, treeViewSR, mainGridSmallRight);
                    IpsGlobal.addInstance(typeof(IUpdateProviderSmallRight), _smallRightPresenter);

                    treeViewSR.SelectedNode = treeViewSR.Nodes["Всі"];

                    RadTreeNode[] list2 = new[]{
                        new RadTreeNode
                        {
                            Text = "Генеральні договори", Value = TypeBRDocument.GenAgreement, Selected = true,
                            Nodes  =
                            {
                                new RadTreeNode { Text = "Всі", Value = ConsumerFilterEnum.All },
                                new RadTreeNode { Text = "Активні", Value = ConsumerFilterEnum.Working },
                                new RadTreeNode { Text = "На акцепті", Value = ConsumerFilterEnum.NotAccepted},
                                new RadTreeNode { Text = "Не підтверджені", Value = ConsumerFilterEnum.NotConfirmed },
                                new RadTreeNode { Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation },
                                new RadTreeNode { Text = "Закриті", Value = ConsumerFilterEnum.Closed},
                            }
                        },
                        new RadTreeNode
                        {
                            Text = "Ліцензійні договори", Value = TypeBRDocument.LicAgreement,
                            Nodes  =
                            {
                                new RadTreeNode { Text = "Всі", Value = ConsumerFilterEnum.All },
                                new RadTreeNode { Text = "Активні", Value = ConsumerFilterEnum.Working },
                                new RadTreeNode { Text = "Не активні", Value = ConsumerFilterEnum.NotActive },
                                new RadTreeNode { Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation }
                            }
                        },
                        new RadTreeNode
                        {
                            Text = "Заявки", Value = TypeBRDocument.Request,
                            Nodes  =
                            {
                                new RadTreeNode { Text = "Всі", Value = ConsumerFilterEnum.All },
                                new RadTreeNode { Text = "Активні", Value = ConsumerFilterEnum.Working },
                                new RadTreeNode { Text = "Не підтверджені", Value = ConsumerFilterEnum.NotActive },
                                new RadTreeNode { Text = "На акцепті", Value = ConsumerFilterEnum.None },
                                new RadTreeNode { Text = "На погодженні", Value = ConsumerFilterEnum.None},
                                new RadTreeNode { Text = "Відхилені", Value = ConsumerFilterEnum.None },
                            }

                        },
                        new RadTreeNode
                        {
                            Text = "Довідки", Value = TypeBRDocument.Reference,
                            Nodes  =
                            {
                                new RadTreeNode { Text = "Всі", Value = ConsumerFilterEnum.All },
                                new RadTreeNode { Text = "Активні", Value = ConsumerFilterEnum.Working },
                                new RadTreeNode { Text = "Не підтверджені", Value = ConsumerFilterEnum.NotActive },
                                new RadTreeNode { Text = "На акцепті", Value = ConsumerFilterEnum.None },
                                new RadTreeNode { Text = "На погодженні", Value = ConsumerFilterEnum.None},
                                new RadTreeNode { Text = "Відхилені", Value = ConsumerFilterEnum.None },
                            }

                        },
                    new RadTreeNode {Text = "Не розподіленні", Value = ConsumerFilterEnum.ForDistribution},
                    new RadTreeNode {Text = "Борг", Value = ConsumerFilterEnum.Debt},
                    new RadTreeNode {Text = "Відсутні Роз.Листи", Value = ConsumerFilterEnum.UnattachData}
                    };

                    foreach (var item in list2)
                        treeViewBR.Nodes.Add(item);
                    
                    _bigRightPresenter = new BigRightPresenter(_consumerMainService, _partnerService, treeViewBR, mainGridBigRight);
                    IpsGlobal.addInstance(typeof(IUpdateProviderBigRight), _bigRightPresenter);

                    treeViewBR.SelectedNode = treeViewBR.Nodes[0];

                    }
                    break;
            }

            _partnerPresenter = new PartnerPresenter(_partnerService, ctrlPartner);
            _communityPresenter = new CommunityPresenter(_communityService, ctrlCommunity);
        }
        
        Customer _cust = null;
        LicenseAgrParam _curLicAgreement;
        public void SetData(ICustomer data)
        {
            _cust = (Customer)data;
            var licAgr = _cust.Client.LicenseAgreement.FirstOrDefault();
            _curLicAgreement = licAgr?.LicenseAgrParam?.SingleOrDefault(item => item.LicVersion == licAgr.LicVersion);
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


        public Func<IList<ConsumerSmallRightView>> getMainViewData { get; set; }
        public Func<int, Customer> NewCustomer { get; set; }
        public Func<int, Customer> GetCustomer { get; set; }
        public Func<Customer, bool> SaveCustomer { get; set; }
        public Func<string, IList<AutoCompleteData>> GetAutoCompList { get; set; }

        public void EndPresenterLink()
        {
            if (getMainViewData != null)
            {
                var list = getMainViewData();
                consumerMainViewBindingSource.DataSource = list;
            }
        }

        private void pageViewOwner_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageViewOwner.SelectedPage == pvPartners)
            {
                // TODO: maybe need update -> ctrlPartner.LoadData();
            }
        }
    }


}
