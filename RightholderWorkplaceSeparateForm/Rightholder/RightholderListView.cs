using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RightholderWorkplaceSeparateForm.Models;
using Telerik.WinControls;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public partial class RightholderListView : Telerik.WinControls.UI.RadForm
    {
        public RightholderListView()
        {
            InitializeComponent();

            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private RightholderListViewPresenter _presenter;
        public RightholderListViewPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        public IEnumerable<RightholderModel> RighholdersList
        {
            get => rightholderModelBindingSource.List.Cast<RightholderModel>();
            set => rightholderModelBindingSource.DataSource = value.ToList();
        }

        public int SelectedRightholderId
        {
            get
            {
                return (gvRightholdersList.CurrentRow.DataBoundItem is RightholderModel rightholder) ? rightholder.Id : 0;
            }
            set
            {
                var row = gvRightholdersList.Rows.FirstOrDefault(r => (int)r.Cells["Id"].Value == value);
                if (row != null)
                {
                    gvRightholdersList.CurrentRow = row;
                }
            }
        }

        public void Run()
        {
            Show();
        }

        private void miAddRightholderPerson_Click(object sender, EventArgs e)
        {
            _presenter.AddRightholder();
        }

        private void gvRightholdersList_DoubleClick(object sender, EventArgs e)
        {
            _presenter.EditRightholder();
        }
    }
}
