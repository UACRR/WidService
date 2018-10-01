using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.Utilities;
using System.ComponentModel;
using System.Linq;

namespace IpsViewComponentLibrary.FixationControls
{
    public class FixationPresenter
    {
        private readonly FixationView _view;
        private readonly FixationService _fixationService;
        private readonly UserService _userService;
        private readonly DialogService _dialogService;
        private Fixation _fixation;
        private bool _canClose;

        public FixationPresenter(FixationView view)
        {
            _view = view;
            _view.Presenter = this;

            _fixationService = new FixationService();
            _userService = new UserService();
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

            if (_fixation.UserId != null)
            {
                var responsible = _userService.GetById(_fixation.UserId);
                _view.Responsible = responsible;
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
            if (_fixation.Lic == null && _view.RegisterItemList.Any())
            {
                // create structure for storing Register, RegisterItems and RegisterCount

                _fixation.Lic = new LicenseAgreement();
            }









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
    }
}
