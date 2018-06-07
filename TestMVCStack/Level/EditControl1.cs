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

namespace TestMVCStack
{
    public partial class EditControl1 : UserControl, IView
    {
        public EditControl1(IPresenterLevel presenter )
        {
            this.presenter = presenter;
            InitializeComponent();
        }

        public IPresenterLevel presenter { get; }

        public void SetBindingSource(object Source)
        {
            bindingSourceData.DataSource = Source;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            presenter.Done(bindingSourceData.DataSource);
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            presenter.parent.presenterCancel();
        }
    }
}
