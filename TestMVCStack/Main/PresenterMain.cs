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
    public class PresenterMain : IPresenter
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

        public PresenterMain(ServiceMain _service, MainViewSwitcher switcher, PresenterMain _parent)
            : this(_service, switcher)
        {
            parent = _parent;
        }

        public void AddNew()
        {
            IData newItem = service.newItem();
            editControl.SetBindingSource(newItem);

            _switcher.SwitchView(editControl.GetType(), true);
        }

        public void Cancel()
        {
            _switcher.CloseView();
        }

        public void Done()
        {
            _switcher.CloseView();

        }

        public void EditItem(object item)
        {

            editControl.SetBindingSource(item);
            _switcher.SwitchView(editControl.GetType(), true);
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
            _switcher.AddSwitchView(gridControl);
            _switcher.AddSwitchView(editControl);
            _switcher.StartView(gridControl.GetType());

        }

        public void NestPanel()
        {
            if(nestedControl == null )
            {
                nestedControl = new Nested(this);
                nestedControl.Dock = DockStyle.Fill;
                _switcher.AddSwitchView(nestedControl);
            }
            _switcher.SwitchView(nestedControl.GetType(), true);
        }
    }
}
