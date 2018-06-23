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
    public partial class EditControl1 : UserControl
    {
        public EditControl1(IPresenterNested presenter )
        {
            this.presenter = presenter;
            InitializeComponent();
        }

        public IPresenterNested presenter { get; }

        public void SetBindingSource(object Source)
        {
            bindingSourceData.DataSource = Source;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            presenter.Save(bindingSourceData.DataSource);
            presenter.Done();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            presenter.Cancel();
        }
    }
}
