using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class MainViewSwitcher : UserControl
    {
        /// <summary>
        /// Стек контролів які додані в панель
        /// </summary>
        private Stack<Control> _stack = new Stack<Control>();
        /// <summary>
        /// Поточний контрол
        /// </summary>
        private Control _currentView = null;
        /// <summary>
        /// Кількість об'єктів в стекі
        /// </summary>
        public int Count { get { return _stack.Count; } }


        public MainViewSwitcher()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Переключити на новий контрол
        /// </summary>
        /// <param name="view">контрол</param>
        /// <param name="needReturn">true - Додати поточний контрол в стек перед переключенням на новий</param>
        public void SwitchView(Control view, bool needReturn = true)
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
        /// Закрити поточний контрол
        /// </summary>
        public Control CloseView()
        {
            if (_stack.Count == 0)
            {
                return null;
            }
            _currentView = _stack.Pop();
            radPanel1.SuspendLayout();
            radPanel1.Controls.Clear();
            radPanel1.Controls.Add(_currentView);
            radPanel1.ResumeLayout();
            return _currentView;
        }
    }
}
