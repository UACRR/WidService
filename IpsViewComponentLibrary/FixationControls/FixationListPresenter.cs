using System;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.FixationControls
{
    public class FixationListPresenter
    {
        private readonly FixationListControl _view;
        private readonly FixationService _fixationService;
        
        public FixationListPresenter(FixationListControl view)
        {
            _view = view;
            _fixationService = new FixationService();
        }

        public async void UpdateList()
        {
            var query = _view.FixationQuery;
            var list = await _fixationService.GetFixationsAsync(query);
            _view.FixationDataSource = list;
        }

        public void Add()
        {
            using (var fixationView = new FixationView())
            {
                var fixationPresenter = new FixationPresenter(fixationView);
                fixationPresenter.ShowNew();
            }
        }

        public void Edit()
        {
            using (var fixationView = new FixationView())
            {
                var fixationPresenter = new FixationPresenter(fixationView);
                fixationPresenter.Show(_view.SelectedFixation.FixId);
            }
        }
    }
}
