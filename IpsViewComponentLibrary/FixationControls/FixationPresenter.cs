using ipsFormsDesign.Events;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.ConsumerControls;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Linq;

namespace IpsViewComponentLibrary.FixationControls
{
    public class FixationPresenter
    {
        private readonly FixationView _view;
        private readonly FixationService _fixationService;
        private readonly UserService _userService;
        private readonly ConsumerService _consumerService;
        private readonly DialogService _dialogService;
        private Fixation _fixation;
        private bool _canClose;

        public FixationPresenter(FixationView view)
        {
            _view = view;
            _view.Presenter = this;

            _fixationService = new FixationService();
            _userService = new UserService();
            _consumerService = new ConsumerService();
            _dialogService = new DialogService();
        }

        public void ShowNew()
        {
            _fixation = _fixationService.New();
            _view.Fixation = _fixation;
            _view.Run();
        }

        public void Show(int fixId)
        {
            _fixation = _fixationService.GetById(fixId);
            _view.Fixation = _fixation;

            if (_fixation.UserId != null)
            {
                var responsible = _userService.GetById(_fixation.UserId);
                _view.Responsible = responsible;
            }
            if (_fixation.ClientCustId != null)
            {
                _view.Consumer = _consumerService.GetShortInfoById((int)_fixation.ClientCustId);
            }

            var currentStage = _fixation.GetStage();

            if (currentStage == FixationStages.NegotiationBeforeFixation || currentStage == FixationStages.Fixation)
            {
                _view.SetAvailableStageStatuses(_fixation.GetAvailableStageStatuses());
                _view.ShowStatusesGroupBox = true;
            }

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

        public void SelectResponsible()
        {
            using (var selectionView = new UserSelectionView())
            {
                selectionView.SelectedUser = _view.Responsible;
                selectionView.UserSelected += (s, selectedUser) =>
                {
                    _view.Responsible = selectedUser;
                    _fixation.UserId = selectedUser.UserId;
                };
                selectionView.ShowDialog();
            }
        }

        public void SelectConsumer()
        {
            using (var selectionView = new ConsumerSelectionView())
            {
                selectionView.SelectedConsumer = _view.Consumer;
                selectionView.ConsumerSelected += (s, selectedConsumer) =>
                {
                    _view.Consumer = selectedConsumer;
                    _fixation.ClientCustId = selectedConsumer.CustId;
                };
                selectionView.ShowDialog();
            }
        }
    }
}
