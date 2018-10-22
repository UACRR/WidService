using System;
using ipsFormsDesign.Services;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.FixationControls
{
    public class FixationListPresenter
    {
        private readonly FixationListControl _view;
        private readonly FixationService _fixationService;
        private readonly DialogService _dialogService;
        
        public FixationListPresenter(FixationListControl view)
        {
            _view = view;
            _fixationService = new FixationService();
            _dialogService = new DialogService();
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

        public void SetStatus(FixationStageStatuses newStatus)
        {
            if (newStatus == FixationStageStatuses.FixationNotScheduled
                || newStatus == FixationStageStatuses.FixationScheduled
                || newStatus == FixationStageStatuses.FixationFixationCompleted
                || newStatus == FixationStageStatuses.RightholderIdentificationOnIdentification
                || newStatus == FixationStageStatuses.NegotiationAfterFixationOnNegotioation
                || newStatus == FixationStageStatuses.JudicalWorkWinned)
            {
                using (var fixationView = new FixationView())
                {
                    var fixationPresenter = new FixationPresenter(fixationView);
                    fixationPresenter.ShowForSpecifyRequiredValues(_view.SelectedFixation.FixId, newStatus);
                }
            }
            else
            {
                var result = _fixationService.SetStatus(_view.SelectedFixation.FixId, newStatus);

                if (result)
                    UpdateList();
                else
                    _dialogService.ShowError(_view, "Не вдалося змінити статус.");
            }
        }
    }
}
