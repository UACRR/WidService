using ipsFormsDesign.Events;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public class ConsumerExternalPresenter
    {
        private readonly ConsumerExternalView _view;
        private readonly ConsumerService _consumerService;
        private readonly DialogService _dialogService;
        private Customer _customer;

        public ConsumerExternalPresenter(ConsumerExternalView view)
        {
            _view = view;
            _view.Presenter = this;

            _consumerService = new ConsumerService();
            _dialogService = new DialogService();
        }

        public void ShowNew()
        {
            _customer = new Customer { AnkVersion = 1, CustType = 6, Status = 2 };
            _customer.AnketaExternal = new AnketaExternal();
            _customer.Client = new Client();

            _view.Anketa = _customer.AnketaExternal;
            _view.Run();
        }

        public void Show(int custId)
        {
            _customer = _consumerService.GetExternalById(custId);
            _view.Anketa = _customer.AnketaExternal;

            _view.Run();
        }

        public void Save()
        {
            var result = _consumerService.SaveExternal(_customer);

            if (result)
            {
                _view.Close();

                ApplicationController.Instance.EventAggregator.PublishEvent(new ConsumerExternalUpdatedEvent());
            }
            else
            {
                _dialogService.ShowError(_view, "Не вдалося зберегти зміни.");
            }
        }

        public void Close()
        {
            _view.Close();
        }
    }
}
