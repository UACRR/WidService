using ipsFormsDesign.Data;
using ipsFormsDesign.Events;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.FixationControls
{
    public class FixationPresenter
    {
        private readonly FixationView _view;
        private readonly FixationService _fixationService;
        private readonly DialogService _dialogService;
        private Fixation _fixation;
        private bool _canClose;

        public FixationPresenter(FixationView view)
        {
            _view = view;
            _view.Presenter = this;

            _fixationService = new FixationService();
            _dialogService = new DialogService();
        }

        public void ShowNew()
        {
            _fixation = new Fixation { StageStatus = 1, UsesType = 1 };
            _view.Fixation = _fixation;
            _view.Run();
        }

        public void Show(int fixId)
        {
            _fixation = _fixationService.GetById(fixId);
            _view.Fixation = _fixation;

            if (_fixation.GetStage() == FixationStages.NegotiationBeforeFixation)
                _view.ShowNegotiationStatusGroupBox = true;

            _view.Run();
        }

        public void Save()
        {
            var result = _fixationService.Save(_fixation);

            if (result)
            {
                _view.Close();

                ApplicationController.Instance.EventAggregator.PublishEvent(new FixationUpdatedEvent());
            }
            else
            {
                _dialogService.ShowError(_view, "Не вдалося зберегти зміни.");
            }
        }

        public void SetStatus(FixationStageStatuses newStatus)
        {
            // TODO: check for correct status

            _fixation.StageStatus = (int)newStatus;
        }
    }
}
