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

namespace TestMVCStack.Main
{
    public partial class MainView : UserControl, IViewMain
    {
        public MainView()
        {
            InitializeComponent();
        }

        public IPresenterLevel presenter { get { return _view?.presenter; } }

        public void SetBindingSource(object Source)
        {
        }

        private IView _view;
        public void SetView( Control view )
        {
            _view = view as IView;
            view.Dock = DockStyle.Fill;
            radPanel1.SuspendUpdate();
            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(view);
            radPanel1.ResumeUpdate();
        }
    }
}
