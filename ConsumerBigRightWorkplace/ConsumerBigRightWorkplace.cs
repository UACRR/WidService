using System.Windows.Forms;
using ConsumerBigRightWorkplace.Presenters;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IpsCommonTypes.Enums;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;


namespace ConsumerBigRightWorkplace
{
    public partial class ConsumerBigRightWorkplace : RadForm
    {
        public ConsumerBigRightWorkplace()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new IpsUARadGridLocalizationProvider();
            ctrlImportDBF.TypeRights = TypeRights.BigRights;
            SetupTreeViewData();
        }

        private void SetupTreeViewData()
        {
            RadTreeNode[] list =
            {
                new RadTreeNode
                {
                    Text = "Генеральні договори", Value = ConsumersBigRightCategoryFilter.GenAgreement, Selected = true, 
                    Nodes =
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumersBigRightFilter.All},
                        new RadTreeNode {Text = "Активні", Value = ConsumersBigRightFilter.Working},
                        new RadTreeNode {Text = "На акцепті", Value = ConsumersBigRightFilter.NotAccepted},
                        new RadTreeNode {Text = "Не підтверджені", Value = ConsumersBigRightFilter.NotConfirmed},
                        new RadTreeNode {Text = "Для пролонгації", Value = ConsumersBigRightFilter.ForProlongation},
                        new RadTreeNode {Text = "Закриті", Value = ConsumersBigRightFilter.Closed},
                    }
                },
                new RadTreeNode
                {
                    Text = "Ліцензії", Value = ConsumersBigRightCategoryFilter.License,
                    Nodes =
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumersBigRightFilter.All},
                        new RadTreeNode {Text = "Активні", Value = ConsumersBigRightFilter.Working},
                        new RadTreeNode {Text = "Не активні", Value = ConsumersBigRightFilter.NotActive},
                        new RadTreeNode {Text = "Для пролонгації", Value = ConsumersBigRightFilter.ForProlongation}
                    }
                },
                new RadTreeNode
                {
                    Text = "Заявки", Value = ConsumersBigRightCategoryFilter.Request,
                    Nodes =
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumersBigRightFilter.All},
                        new RadTreeNode {Text = "Активні", Value = ConsumersBigRightFilter.Working},
                        new RadTreeNode {Text = "Не підтверджені", Value = ConsumersBigRightFilter.NotActive},
                        //new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.None},
                        //new RadTreeNode {Text = "На погодженні", Value = ConsumerFilterEnum.None},
                        //new RadTreeNode {Text = "Відхилені", Value = ConsumerFilterEnum.None},
                    }
                },
                // TODO: відсутні поля у database view, при наявності повернути тут та додати в контролері
                new RadTreeNode
                {
                    Text = "Довідки", Value = ConsumersBigRightCategoryFilter.Reference,
                    Nodes =
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumersBigRightFilter.All},
                        new RadTreeNode {Text = "Активні", Value = ConsumersBigRightFilter.Working},
                        new RadTreeNode {Text = "Не підтверджені", Value = ConsumersBigRightFilter.NotActive},
                        //new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.None},
                        //new RadTreeNode {Text = "На погодженні", Value = ConsumerFilterEnum.None},
                        //new RadTreeNode {Text = "Відхилені", Value = ConsumerFilterEnum.None},
                    }
                },
                new RadTreeNode {Text = "Нерозподіленні", Value = ConsumersBigRightFilter.ForDistribution},
                new RadTreeNode {Text = "Борг", Value = ConsumersBigRightFilter.Debt},
                new RadTreeNode {Text = "Відсутні Роз.Листи", Value = ConsumersBigRightFilter.UnattachData}
            };

            foreach (var item in list)
                treeViewBigRight.Nodes.Add(item);

            ConsumerBigRightService.GetInstance();
            var bigRightPresenter = new BigRightPresenter(treeViewBigRight, mainGridBigRight);
            IpsGlobal.addInstance(typeof(IUpdateProviderBigRight), bigRightPresenter);

            treeViewBigRight.SelectedNode = treeViewBigRight.Nodes[0];
        }
    }
}
