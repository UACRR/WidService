using System;
using ipsFormsDesign.Services;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.FixationControls
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
            // to fix
            //using (var fixationView = new FixationView())
            //{
            //    var fixationPresenter = new FixationPresenter(fixationView);
            //    fixationPresenter.ShowNew();
            //}
        }

        public void Edit()
        { 
            // to fix
            //using (var fixationView = new FixationView())
            //{
            //    var fixationPresenter = new FixationPresenter(fixationView);
            //    fixationPresenter.Show(_view.SelectedFixation.CustId);
            //}
        }
    }
}
