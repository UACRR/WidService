using System.Windows.Forms;
using ConsumerBigRightWorkplace.Presenters;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
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
                    Text = "Генеральні договори", Value = TypeBRDocument.GenAgreement, Selected = true,
                    Nodes =
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                        new RadTreeNode {Text = "Активні", Value = ConsumerFilterEnum.Working},
                        new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.NotAccepted},
                        new RadTreeNode {Text = "Не підтверджені", Value = ConsumerFilterEnum.NotConfirmed},
                        new RadTreeNode {Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation},
                        new RadTreeNode {Text = "Закриті", Value = ConsumerFilterEnum.Closed},
                    }
                },
                new RadTreeNode
                {
                    Text = "Ліцензійні договори", Value = TypeBRDocument.LicAgreement,
                    Nodes =
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                        new RadTreeNode {Text = "Активні", Value = ConsumerFilterEnum.Working},
                        new RadTreeNode {Text = "Не активні", Value = ConsumerFilterEnum.NotActive},
                        new RadTreeNode {Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation}
                    }
                },
                new RadTreeNode
                {
                    Text = "Заявки", Value = TypeBRDocument.Request,
                    Nodes =
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                        new RadTreeNode {Text = "Активні", Value = ConsumerFilterEnum.Working},
                        new RadTreeNode {Text = "Не підтверджені", Value = ConsumerFilterEnum.NotActive},
                        new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.None},
                        new RadTreeNode {Text = "На погодженні", Value = ConsumerFilterEnum.None},
                        new RadTreeNode {Text = "Відхилені", Value = ConsumerFilterEnum.None},
                    }

                },
                new RadTreeNode
                {
                    Text = "Довідки", Value = TypeBRDocument.Reference,
                    Nodes =
                    {
                        new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                        new RadTreeNode {Text = "Активні", Value = ConsumerFilterEnum.Working},
                        new RadTreeNode {Text = "Не підтверджені", Value = ConsumerFilterEnum.NotActive},
                        new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.None},
                        new RadTreeNode {Text = "На погодженні", Value = ConsumerFilterEnum.None},
                        new RadTreeNode {Text = "Відхилені", Value = ConsumerFilterEnum.None},
                    }

                },
                new RadTreeNode {Text = "Не розподіленні", Value = ConsumerFilterEnum.ForDistribution},
                new RadTreeNode {Text = "Борг", Value = ConsumerFilterEnum.Debt},
                new RadTreeNode {Text = "Відсутні Роз.Листи", Value = ConsumerFilterEnum.UnattachData}
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
