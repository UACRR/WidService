using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMVCStack
{
    public partial class MainViewSwitcher : UserControl
    {
        private Dictionary<Type, Control> views = new Dictionary<Type, Control>();
        private Stack<Control> _stack = new Stack<Control>();
        private Control _currentView = null;
        public PresenterMain presenter { get; set; }

        public MainViewSwitcher()
        {
            InitializeComponent();
        }

        public void AddSwitchView(Control view)
        {
            if (views.Keys.Contains(view.GetType()))
                throw new ApplicationException("Add existing control for switching");
            views.Add(view.GetType(), view);
            if (_currentView == null)
                _currentView = view;
        }

        public void StartView(Type viewType)
        {
            if (views.Keys.Contains(viewType) == false)
                throw new ArgumentException("Set startup unknown view");

            _stack.Clear();
            _currentView = views[viewType];
            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(_currentView);
        }

        public void SwitchView(Type viewType, bool needReturn)
        {
            if (views.Keys.Contains(viewType) == false)
                throw new ArgumentException("switch to unknown view");

            if (needReturn)
            {
                if (_currentView != null) _stack.Push(_currentView);
            }

            _currentView = views[viewType];
            radPanel1.SuspendUpdate();
            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(_currentView);
            radPanel1.ResumeUpdate();
        }

        public void CloseView()
        {
            if (_stack.Count == 0)
            {
                if(presenter == null
                    || presenter.parent == null )
                {
                    Application.Exit();
                    return;

                }

                presenter.parent.Done();
                return;
            }
            _currentView = _stack.Pop();
            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(_currentView);

        }

    }
}
