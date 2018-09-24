using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.FixationControls
{
    public partial class FixationListControl : UserControl
    {
        private FixationListPresenter _presenter;

        public FixationListControl()
        {
            InitializeComponent();

            _presenter = new FixationListPresenter(this);
        }

        private void FixationListControl_Load(object sender, EventArgs e)
        {
            PopulateFiltersValues();

            _presenter.Load();
        }

        private void PopulateFiltersValues()
        {
            var filters = new List<RadTreeNode> {
                new RadTreeNode { Value = -1,                            Text = "Всі" },
                new RadTreeNode { Value = AgreementStatuses.NotAccepted, Text = "Не підтверджені" },
                new RadTreeNode { Value = AgreementStatuses.OnAcception, Text = "На акцепті" },
                new RadTreeNode { Value = AgreementStatuses.Active,      Text = "Активний" },
                new RadTreeNode { Value = AgreementStatuses.Closed,      Text = "Закритий" },
                new RadTreeNode { Value = AgreementStatuses.Inheritance, Text = "Оформлення спадщини" },
                new RadTreeNode { Value = AgreementStatuses.Blocked,     Text = "Заблокований" },
            };

            if (_allowedStatuses != null)
            {
                filters = filters.Where(node => _allowedStatuses.Contains((AgreementStatuses)node.Value)).ToList();
            }

            tvFilters.Nodes[0].Nodes.Clear();
            tvFilters.Nodes[0].Nodes.AddRange(filters);
        }
    }
}
