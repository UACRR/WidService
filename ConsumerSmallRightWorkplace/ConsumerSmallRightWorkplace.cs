using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConsumerSmallRightWorkplace.Presenters;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
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
                new RadTreeNode {Text = "Всі", Value = ConsumerFilterEnum.All},
                new RadTreeNode {Text = "Діючі", Value = ConsumerFilterEnum.Working},
                new RadTreeNode {Text = "На акцепті", Value = ConsumerFilterEnum.NotAccepted},
                new RadTreeNode {Text = "Для пролонгації", Value = ConsumerFilterEnum.ForProlongation},
                new RadTreeNode {Text = "Не розподіленні", Value = ConsumerFilterEnum.ForDistribution}
            };
            foreach (var item in list)
            {
                treeViewSmallRight.Nodes.Add(item);
            }

            ConsumerSmallRightService.GetInstance();
            var smallRightPresenter = new SmallRightPresenter(treeViewSmallRight, ctrlConsumersViewSmallRight);
            IpsGlobal.addInstance(typeof(IUpdateProviderSmallRight), smallRightPresenter);

            treeViewSmallRight.SelectedNode = treeViewSmallRight.Nodes["Всі"];
        }
    }
}
