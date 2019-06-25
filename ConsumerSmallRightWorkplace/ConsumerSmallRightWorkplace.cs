using System.Windows.Forms;
using ConsumerSmallRightWorkplace.Presenters;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IpsCommonTypes.Enums;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace ConsumerSmallRightWorkplace
{
    public partial class ConsumerSmallRightWorkplace : RadForm
    {
        public ConsumerSmallRightWorkplace()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new IpsUARadGridLocalizationProvider();
            ctrlImportDBF.TypeRights = TypeRights.SmallRights;
            SetupTreeViewData();
        }

        private void SetupTreeViewData()
        {
            RadTreeNode[] list =
            {
                new RadTreeNode {Text = "Договори:", Enabled = false,},
                new RadTreeNode {Text = "  Всі", Value = ConsumersSmallRightFilter.All, Name = "All"},
                new RadTreeNode {Text = "  Діючі", Value = ConsumersSmallRightFilter.Working},
                new RadTreeNode {Text = "  Не підтверджені", Value = ConsumersSmallRightFilter.ForAccept},
                new RadTreeNode {Text = "  На акцепті", Value = ConsumersSmallRightFilter.NotAccepted},
                new RadTreeNode {Text = "  Для пролонгації", Value = ConsumersSmallRightFilter.ForProlongation},
                new RadTreeNode {Text = "Кошти:", Enabled = false},
                new RadTreeNode {Text = "  Не розподіленні", Value = ConsumersSmallRightFilter.ForDistribution},
                new RadTreeNode {Text = "  Борг", Value = ConsumersSmallRightFilter.Debt},
                new RadTreeNode {Text = "Періоди:", Enabled = false},
                new RadTreeNode {Text = "  Прийом коштів", Value = ConsumersSmallRightFilter.ReceivingMoney},
                new RadTreeNode {Text = "  Прийом звітів", Value = ConsumersSmallRightFilter.ReceivingRegister},
                new RadTreeNode {Text = "Звіти:", Enabled = false},
                new RadTreeNode {Text = "  Погоджені звіти", Value = ConsumersSmallRightFilter.RegisterStatusOk},
                new RadTreeNode {Text = "  Відхилені звіти", Value = ConsumersSmallRightFilter.RegisterStatusRefuse},
            };
            foreach (var item in list)
            {
                treeViewSmallRight.Nodes.Add(item);
            }

            ConsumerSmallRightService.GetInstance();
            var smallRightPresenter = new SmallRightPresenter(treeViewSmallRight, ctrlConsumersViewSmallRight);
            IpsGlobal.addInstance(typeof(IUpdateProviderSmallRight), smallRightPresenter);

            treeViewSmallRight.SelectedNode = treeViewSmallRight.Nodes["All"];
        }
    }
}
