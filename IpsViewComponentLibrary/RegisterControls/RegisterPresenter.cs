using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.ViewModels.Consumer;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System.Collections.Generic;
using System.Linq;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary.RegisterControls
{
    public enum RegisterFormType
    {
        OrdinaryDistribution = 1,
        CompositionAndMusicalDesignDistribution = 2,
    }

    public class RegisterPresenter
    {
        private readonly RegisterView _view;
        private readonly RegisterService _registerService;
        private readonly ConsumerService _consumerService;
        private readonly DialogService _dialogService;
        private Register _register;
        private ConsumerSmallRightView _consumer;
        private bool _saved;

        public RegisterPresenter(RegisterView view, RegisterService registerService)
        {
            _view = view;
            _view.Presenter = this;

            _view.FormClosing += View_FormClosing;

            _registerService = registerService;
            _consumerService = new ConsumerService();
            _dialogService = new DialogService();
        }

        public void Show(int regId)
        {
            _register = _registerService.GetById(regId);
            _consumer = _consumerService.GetShortInfoById(_register.CustId);

            UpdateDataBindings();

            if (_register.SchemaId == 1)
            {
                _view.FormType = RegisterFormType.OrdinaryDistribution;
            }
            else if (_register.SchemaId == 2)
            {
                _view.FormType = RegisterFormType.CompositionAndMusicalDesignDistribution;
            }

            _view.Run();
        }

        public void SearchObjectsAuto()
        {
            var list = _registerService.GetAutoLinkedObjects(_register.RegId);

            foreach (var item in list)
            {
                var itemToUpdate = _view.RegisterItemList.FirstOrDefault(i => i.RegId == item.RegId && i.RegIitemId == item.RegIitemId);

                if (itemToUpdate != null)
                {
                    itemToUpdate.SetObjectData(item.ObjId, item.ObjectName, item.ObjectAuthors, item.ObjectPerformers, item.ObjectDuration);
                    itemToUpdate.IsAuto = true;
                }
            }
        }

        public void SearchObjectsForAll()
        {
            var registerItemList = new List<RegisterItemViewModel>();

            registerItemList.AddRange(_view.RegisterItemListStage);
            registerItemList.AddRange(_view.RegisterItemList);

            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, _registerService);
                presenter.Show(registerItemList);
            }
        }

        public void SearchObjectsForNotLinked()
        {
            var registerItemList = new List<RegisterItemViewModel>();

            registerItemList.AddRange(_view.RegisterItemListStage.Where(r => r.ObjId == null));
            registerItemList.AddRange(_view.RegisterItemList.Where(r => r.ObjId == null));

            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, _registerService);
                presenter.Show(registerItemList);
            }
        }

        public void SearchObjectsForSelected()
        {
            var registerItemList = new List<RegisterItemViewModel>();

            registerItemList.AddRange(_view.SelectedRegisterItemsStage);
            registerItemList.AddRange(_view.SelectedRegisterItems);

            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, _registerService);
                presenter.Show(registerItemList);
            }
        }

        public void CreateObjectsForSelected()
        {
            var objectRightService = new ObjectRightService();

            var registerItemList = new List<RegisterItemViewModel>();

            registerItemList.AddRange(_view.SelectedRegisterItemsStage);
            registerItemList.AddRange(_view.SelectedRegisterItems);

            var createdObjectCount = 0;

            foreach (var registerItem in registerItemList)
            {
                var newObject = objectRightService.New(5);
                newObject.SetDataFromRegisterItem(registerItem);

                var result = objectRightService.Save(newObject);

                if (result)
                {
                    registerItem.SetObjectData(
                        newObject.ObjId,
                        newObject.Name,
                        newObject.Author,
                        newObject.Performer,
                        newObject.MediaTrack.Duration
                    );

                    createdObjectCount++;
                }
                else
                {
                    _dialogService.ShowError(_view, "Не вдалося створити об'єкт з назвою " + registerItem.ItemName);
                }
            }

            ApplicationController.Instance.EventAggregator.PublishEvent(new ObjectRightUpdatedEvent());

            _dialogService.ShowMessage(_view, $"Створено {createdObjectCount} об'єктів.");
        }

        public bool SetStatus(RegisterStatusType status)
        {
            if (status == RegisterStatusType.OnDistribution && _view.RegisterItemList.Any(item => item.ObjId == null))
            {
                _dialogService.ShowError(_view, "Не всі об'єкти прив'язані. Закінчіть роботу зі звітом.");
                return false;
            }

            _register.RgStatus = (int)status;
            return true;
        }

        public void Save()
        {
            if (!_view.IsValid)
            {
                _dialogService.ShowError(_view, "Не вірно введені дані. Звіт не записаний.");
                return;
            }

            _saved = true;

            foreach (var rvm in _view.RegisterItemList)
            {
                var foundedRegisterItem = _register.RegisterItem.FirstOrDefault(r => r.RegId == rvm.RegId && r.RegIitemId == rvm.RegIitemId);

                if (foundedRegisterItem != null)
                {
                    foundedRegisterItem.ItemName = rvm.ItemName;
                    foundedRegisterItem.AuthorMusic = rvm.AuthorMusic;
                    foundedRegisterItem.AuthorText = rvm.AuthorText;
                    foundedRegisterItem.CategoryCode = rvm.CategoryCode;
                    foundedRegisterItem.CountUse = rvm.CountUse;
                    foundedRegisterItem.DurationItem = rvm.DurationItem;
                    foundedRegisterItem.DurationUse = rvm.DurationUse;
                    foundedRegisterItem.Performer = rvm.Performer;
                    foundedRegisterItem.RegId = rvm.RegId;
                    foundedRegisterItem.RegIitemId = rvm.RegIitemId;
                    foundedRegisterItem.ObjId = rvm.ObjId;
                    foundedRegisterItem.IsAuto = rvm.IsAuto;
                    foundedRegisterItem.CodeItem = rvm.CodeItem;
                };
            }

            foreach (var rvm in _view.RegisterItemListStage)
            {
                var foundedRegisterItem = _register.RegisterItem.FirstOrDefault(r => r.RegId == rvm.RegId && r.RegIitemId == rvm.RegIitemId);

                if (foundedRegisterItem != null)
                {
                    foundedRegisterItem.ItemName = rvm.ItemName;
                    foundedRegisterItem.AuthorMusic = rvm.AuthorMusic;
                    foundedRegisterItem.AuthorText = rvm.AuthorText;
                    foundedRegisterItem.CategoryCode = rvm.CategoryCode;
                    foundedRegisterItem.CountUse = rvm.CountUse;
                    foundedRegisterItem.DurationItem = rvm.DurationItem;
                    foundedRegisterItem.DurationUse = rvm.DurationUse;
                    foundedRegisterItem.Performer = rvm.Performer;
                    foundedRegisterItem.RegId = rvm.RegId;
                    foundedRegisterItem.RegIitemId = rvm.RegIitemId;
                    foundedRegisterItem.ObjId = rvm.ObjId;
                    foundedRegisterItem.IsAuto = rvm.IsAuto;
                    foundedRegisterItem.CodeItem = rvm.CodeItem;
                };
            }

            var result = _registerService.Save(_register);

            ApplicationController.Instance.EventAggregator.PublishEvent(new RegisterUpdatedEvent());

            if (!result)
                _dialogService.ShowError(_view, "Не вдалося зберегти зміни.");
        }

        private void UpdateDataBindings()
        {
            _view.Register = _register;
            _view.ConsumerInfo = _consumer;

            _view.RegisterItemList.Clear();
            _view.RegisterExtraList.Clear();
            _view.RegisterItemListStage.Clear();
            _view.RegisterExtraListStage.Clear();

            foreach (var r in _register.RegisterItem)
            {
                var genre = IpsGlobal.AnketaDictionaties.genreType.SingleOrDefault(rec => rec.CodeI == r.GenreType);
                var rate = IpsGlobal.AnketaDictionaties.relGenrePercent.SingleOrDefault(rec =>rec.GenreType == genre?.CodeI);

                var rvm = new RegisterItemViewModel
                {
                    ItemName = r.ItemName,
                    AuthorMusic = r.AuthorMusic,
                    AuthorText = r.AuthorText,
                    CategoryCode = r.CategoryCode,
                    CountUse = r.CountUse,
                    DurationItem = r.DurationItem,
                    DurationUse = r.DurationUse,
                    Performer = r.Performer,
                    RegId = r.RegId,
                    RegIitemId = r.RegIitemId,
                    IsAuto = r.IsAuto,
                    CodeItem = r.CodeItem,

                    Genre = genre?.Name,
                    Rate = rate?.Rate,
                    GenreType = r.GenreType,
                };

                if (r.Obj != null)
                    rvm.SetObjectData(r.ObjId, r.Obj.Name, r.Obj.Author, r.Obj.Performer, r.Obj.MediaTrack?.Duration, resetIsAuto: false);

                rvm.RegisterExtraList.AddRange(r.RegisterExtra);

                if (r.CodeItem == 1 || r.CodeItem == 3)
                {
                    _view.RegisterItemList.Add(rvm);

                    foreach (var re in r.RegisterExtra)
                        _view.RegisterExtraList.Add(re);
                }
                else if (r.CodeItem == 2)
                {
                    _view.RegisterItemListStage.Add(rvm);

                    foreach (var re in r.RegisterExtra)
                        _view.RegisterExtraListStage.Add(re);
                }
            }
        }

        private void View_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (!_saved && !_dialogService.ClosingIsConfirmed(_view))
            {
                e.Cancel = true;
            }
        }
    }
}
