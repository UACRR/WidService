using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestMVCStack.Interface;
using TestMVCStack.Main;

namespace TestMVCStack
{
    public partial class GridControl1 : UserControl, IViewWithCurrent
    {
        public IPresenterLevel presenter { get; }

        public GridControl1(IPresenterLevel parent)
        {
            presenter = parent;
            InitializeComponent();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            //if (radGridView1.SelectedRows.Count > 0)
            //    presenter.parent.editData(radGridView1.SelectedRows[0].DataBoundItem as IData);
            presenter.Cancel();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            presenter.parent.editData(null);
        }

        public void SetBindingSource(object Source)
        {
            // bindingSourceData.DataSource = Source;
            this.radGridView1.DataSource = Source;
        }

        public void SetCurrentRow(object id)
        {
            foreach (var row in radGridView1.Rows)
            {
                if ((row.DataBoundItem as IData)?.id == (id as IData)?.id) 
                {
                    row.IsCurrent = true;
                    row.IsVisible = true;
                    row.IsSelected = true;
                    break;
                }
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            presenter.parent.NewMainPresenter();
        }

        private void radGridView1_DataBindingComplete(object sender, Telerik.WinControls.UI.GridViewBindingCompleteEventArgs e)
        {
            int i = 0;
        }
    }
}
