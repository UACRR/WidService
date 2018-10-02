using System;
using ipsFormsDesign.Services;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public class ConsumerListPresenter
    {
        private readonly ConsumerListControl _view;
        private readonly ConsumerService _consumerService;
        private readonly DialogService _dialogService;
        
        public ConsumerListPresenter(ConsumerListControl view)
        {
            _view = view;
            _consumerService = new ConsumerService();
            _dialogService = new DialogService();
        }

        public void UpdateList()
        {
            var list = _consumerService.GetListAll();
            _view.ConsumerDataSource = list;
        }

        public void Add()
        {
            using (var consumerExternalView = new ConsumerExternalView())
            {
                var consumerExternalPresenter = new ConsumerExternalPresenter(consumerExternalView);
                consumerExternalPresenter.ShowNew();
            }
        }

        public void Edit()
        {
            if (!_view.SelectedConsumer.IsAnkExtrn)
            {
                _dialogService.ShowMessage(_view, "Редагувати дозволяється тільки зовнішніх споживачів.");
                return;
            }

            using (var consumerExternalView = new ConsumerExternalView())
            {
                var consumerExternalPresenter = new ConsumerExternalPresenter(consumerExternalView);
                consumerExternalPresenter.Show(_view.SelectedConsumer.CustId);
            }
        }
    }
}
