using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestMVCStack
{
    public partial class MainViewSwitcher : UserControl
    {
        private Stack<Control> _stack = new Stack<Control>();
        private Control _currentView = null;
        /// <summary>
        /// Кількість об'єктів в стекі
        /// </summary>
        public int Count { get { return _stack.Count; } }
        // public PresenterMain presenter { get; set; }

        public MainViewSwitcher()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <param name="needReturn"></param>
        public void SwitchView(Control view, bool needReturn)
        {
            if (needReturn)
            {
                if (_currentView != null) _stack.Push(_currentView);
            }
            _currentView = view;
            radPanel1.SuspendLayout();
            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(_currentView);
            radPanel1.ResumeLayout();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseView()
        {
            if (_stack.Count == 0)
            {
                //if(presenter == null
                //    || presenter.parent == null )
                //{
                //    Application.Exit();
                //    return;
                //}

                //presenter.parent.Done();
                return;
            }
            _currentView = _stack.Pop();
            radPanel1.SuspendLayout();
            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(_currentView);
            radPanel1.ResumeLayout();
        }
    }
}
