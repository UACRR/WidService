using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestMVCStack.Interface;
using TestMVCStack.Main;

namespace TestMVCStack
{
    public class PresenterMain : IPresenterNested
    {
        MainViewSwitcher _switcher = null;
        Control _curentView = null;
        private EditControl1 editControl;
        private GridControl1 gridControl;
        private Nested nestedControl;
        public PresenterMain parent { get; }


        ServiceMain service { get; }
        public PresenterMain(ServiceMain _service, MainViewSwitcher switcher)
        {
            service = _service;
            _switcher = switcher;
            Initialize();
        }

        /// <summary>
        /// Конструктор для включення 
        /// </summary>
        /// <param name="_service"></param>
        /// <param name="switcher"></param>
        /// <param name="_parent"></param>
        /// <param name="level"></param>
        public PresenterMain(ServiceMain _service, MainViewSwitcher switcher, PresenterMain _parent, int level)
            : this(_service, switcher)
        {
            parent = _parent;
            gridControl.radButton2.Text = "Закрити";
            switch (level)
            {
                case 0:
                    break;
                case 4:
                    gridControl.radButton3.Visible = false;
                    break;

                default:
                    break;
            }
        }

        public void AddNew()
        {
            IData newItem = service.newItem();
            editControl.SetBindingSource(newItem);

            _switcher.SwitchView(editControl, true);
        }

        public void Cancel()
        {
            if (_switcher.Count == 0)
            {
                if (parent == null)
                    Application.Exit();
                else
                    parent.Cancel();

                return;
            }
            else
                _switcher.CloseView();
        }

        public void Done()
        {
            if(_switcher.Count == 0  )
            {
                if (parent == null)
                    Application.Exit();
                else
                    parent.Done();

                return;
            }
            else
            _switcher.CloseView();

        }

        public void EditItem(object item)
        {

            editControl.SetBindingSource(item);
            _switcher.SwitchView(editControl, true);
        }

        public void Save(object item)
        {
            service.Save(item);
        }

        void Initialize()
        {
            gridControl = new GridControl1(this);
            editControl = new EditControl1(this);

            gridControl.Dock = DockStyle.Fill;
            editControl.Dock = DockStyle.Fill;

            gridControl.SetBindingSource(service.GetList());

            _curentView = gridControl;
            _switcher.SwitchView(gridControl, true);

        }

        public void NestPanel()
        {
            if(nestedControl == null )
            {
                nestedControl = new Nested(this);
                nestedControl.Dock = DockStyle.Fill;
            }
            _switcher.SwitchView(nestedControl, true);
        }
    }
}
