using ipsFormsDesign.Dictionary;
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
        private readonly ConsumerService _consumerService;
        private readonly DialogService _dialogService;
        private readonly FixationService _fixationService;
        private readonly ObjectRightService _objectRightService;
        private readonly UserService _userService;
        private readonly AmountDistributor _percentDistributor;
        private Fixation _fixation;
        private bool _canClose;
        private int _lastId = 0;

        public FixationPresenter(FixationView view)
        {
            _view = view;
            _view.Presenter = this;

            _consumerService = new ConsumerService();
            _dialogService = new DialogService();
            _fixationService = new FixationService();
            _objectRightService = new ObjectRightService();
            _userService = new UserService();
            _percentDistributor = new AmountDistributor();
            _percentDistributor.Amount = 100;
        }

        public void ShowNew()
        {
            _fixation = _fixationService.New();
            _view.Fixation = _fixation;
            _view.Run();
        }

        public void Show(int fixId)
        {
            var fixationModel = _fixationService.GetById(fixId);
            _fixation = fixationModel.Fixation;
            _view.Fixation = _fixation;

            foreach (var rvm in _fixation.GetRegister().GetRegisterItemsList())
            {
                _view.RegisterItemList.Add(rvm);
            }

            foreach (var rcvm in fixationModel.RegisterCounts)
            {
                _view.RegisterCountList.Add(rcvm);
            }

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
            var register = _fixation.GetRegister();
            var registerCountList = _view.RegisterCountList.ToList();

            register.RegisterItem.Clear();

            foreach (var rvm in _view.RegisterItemList)
            {
                var foundedRegisterItem = register.RegisterItem.FirstOrDefault(r => r.RegId == rvm.RegId && r.RegIitemId == rvm.RegIitemId);

                if (foundedRegisterItem == null)
                {
                    foundedRegisterItem = new RegisterItem();
                    register.RegisterItem.Add(foundedRegisterItem);
                }

                foundedRegisterItem.RegIitemId = rvm.RegIitemId;
                foundedRegisterItem.ItemName = rvm.ItemName;
                foundedRegisterItem.AuthorMusic = rvm.AuthorMusic;
                foundedRegisterItem.AuthorText = rvm.AuthorText;
                foundedRegisterItem.CategoryCode = rvm.CategoryCode;
                foundedRegisterItem.CountUse = rvm.CountUse;
                foundedRegisterItem.DurationItem = rvm.DurationItem;
                foundedRegisterItem.DurationUse = rvm.DurationUse;
                foundedRegisterItem.Performer = rvm.Performer;
                foundedRegisterItem.RegId = rvm.RegId;
                foundedRegisterItem.ObjId = rvm.ObjId;
                foundedRegisterItem.IsAuto = rvm.IsAuto;
                foundedRegisterItem.CodeItem = 1;

                var registerCountForItem = _view.RegisterCountList.Where(rc => rc.RegId == rvm.RegId && rc.RegIitemId == rvm.RegIitemId);
                foreach (var rcvm in registerCountForItem)
                {
                    foundedRegisterItem.RegisterCount.Add(new RegisterCount
                    {
                        RegCntId = rcvm.RegCntId,
                        RegId = rcvm.RegId,
                        RegIitemId = rcvm.RegIitemId,
                        CustId = rcvm.CustId,
                        ObjId = rcvm.ObjId,
                        Rate = rcvm.Rate,
                    });
                }
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

        public void NewRegisterItemAdded(RegisterItemViewModel newRegisterItem)
        {
            newRegisterItem.RegIitemId = GetNextRegisterItemId();
        }

        public void RegisterCountDeleted(RegisterCountViewModel registerCount)
        {
            DistributePercentForRegisterItem(registerCount.RegId, registerCount.RegIitemId);
        }

        public void LinkObject(RegisterItemViewModel registerItem, ObjectRightMainView objectRight)
        {
            var rightholders = _objectRightService.GetObjectRightholders(objectRight.ObjId);

            RemoveRegisterCountForRegisterItem(registerItem);

            foreach (var rightholder in rightholders)
            {
                _view.RegisterCountList.Add(new RegisterCountViewModel
                {
                    RegId = registerItem.RegId,
                    RegIitemId = registerItem.RegIitemId,
                    ObjId = rightholder.ObjId,
                    CustId = rightholder.CustId,
                    Name = rightholder.Name,
                    CreativeRoles = rightholder.CreativeRoles,
                    OwnershipRate = rightholder.TotalRate,
                });
            }

            DistributePercentForRegisterItem(registerItem);
        }

        public void UnlinkObject(RegisterItemViewModel registerItem)
        {
            RemoveRegisterCountForRegisterItem(registerItem);
        }

        private int GetNextRegisterItemId()
        {
            if (_lastId == 0)
            {
                _lastId = _fixation.GetRegister().RegisterItem.Any() ? _fixation.GetRegister().RegisterItem.Max(rvm => rvm.RegIitemId) : 0;
            }

            return ++_lastId;
        }

        private void DistributePercentForRegisterItem(RegisterItemViewModel registerItem)
        {
            DistributePercentForRegisterItem(registerItem.RegId, registerItem.RegIitemId);
        }

        private void DistributePercentForRegisterItem(int regId, int regItemId)
        {
            var list = _view.RegisterCountList.Where(rc => rc.RegId == regId && rc.RegIitemId == regItemId).ToList();

            _percentDistributor.DistributeByEqualAmount(list, rc => rc.Rate);
        }

        private void RemoveRegisterCountForRegisterItem(RegisterItemViewModel registerItem)
        {
            var regCountToDelete = _view.RegisterCountList.Where(rc => rc.RegId == registerItem.RegId && rc.RegIitemId == registerItem.RegIitemId).ToList();
            regCountToDelete.ForEach(rc => _view.RegisterCountList.Remove(rc));
        }
    }
}
