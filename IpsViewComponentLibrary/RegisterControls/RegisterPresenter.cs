using System;
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
using IpsCommonTypes.Views;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.RegisterControls
{
    public enum RegisterFormType
    {
        OrdinaryDistribution = 1,
        CompositionAndMusicalDesignDistribution = 2,
    }

    public class RegisterPresenter
    {
        //private const string WIDSource = "WIDSource";
        private readonly RegisterView _view;
        private readonly RegisterService _registerService;
        private readonly RegisterWIDService _registerWidService;
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
            _registerWidService = RegisterWIDService.GetInstance();
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

        /// <summary>
        /// Процес автоматичного пошуку об'єктів
        /// </summary>
        public void SearchObjectsAuto()
        {
            var list = _registerWidService.GetAutoLinkedObjects(_register.RegId);

            if (!list.Any())
            {
                MessageShow.ShowInfo("Співпадінь не знайдено!");
                return;
            }

            // по паписам звіту знайти елементи з найбільшим співпадінням
            foreach (var item in _view.RegisterItemList)
            {
                RegisterItemViewModel itemForUpdate = null;
                var itemsForUpdate = list.Where(i => i.RegIitemId == item.RegIitemId).ToList();

                if (itemsForUpdate.Count == 1)
                {
                    itemForUpdate = itemsForUpdate.FirstOrDefault();
                }
                else if (itemsForUpdate.Count > 1)
                {
                    var maxSumAllTogether = itemsForUpdate.Max(rec => rec.SumAllTogether);
                    itemForUpdate = itemsForUpdate.FirstOrDefault(i => Math.Abs((i.SumAllTogether - maxSumAllTogether) ?? 0) < 0.00001);
                }

                if (itemForUpdate != null)
                {       
                    item.SetObjectData(itemForUpdate);
                    item.IsAuto = true;
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

            registerItemList.AddRange(_view.RegisterItemListStage.Where(r => r.ObjId == null && r.Wic == null));
            registerItemList.AddRange(_view.RegisterItemList.Where(r => r.ObjId == null && r.Wic == null));

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
            if (status == RegisterStatusType.OnDistribution && _view.RegisterItemList.Any(item => item.ObjId == null && item.Wic == null))
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
                    foundedRegisterItem.Wic = rvm.Wic;
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
                    foundedRegisterItem.Wic = rvm.Wic;
                };
            }

            var result = _registerService.Save(_register);

            ApplicationController.Instance.EventAggregator.PublishEvent(new RegisterUpdatedEvent());

            if (!result)
                _dialogService.ShowError(_view, "Не вдалося зберегти зміни.");
        }

        /// <summary>
        /// Синхронізувати дані
        /// </summary>
        private void UpdateDataBindings()
        {
            _view.Register = _register;
            _view.ConsumerInfo = _consumer;

            _view.RegisterItemList.Clear();
            _view.RegisterExtraList.Clear();
            _view.RegisterItemListStage.Clear();
            _view.RegisterExtraListStage.Clear();

            List<ObjectRightWithWID> listObjectRightWithWID = new List<ObjectRightWithWID>();
            var objectsInWidList = _register.RegisterItem.Where(rec => rec.Wic.HasValue).ToList();

            if (objectsInWidList.Any())
                listObjectRightWithWID = _registerWidService.GetObjectRightListByWIC(objectsInWidList.Select(rec => (int)rec.Wic).ToArray());

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
                    Wic = r.Wic,

                    Genre = genre?.Name,
                    Rate = rate?.Rate,
                    GenreType = r.GenreType,
                };

                // об'єкт існує локально
                if (r.Obj != null)
                    rvm.SetObjectData(r.ObjId, r.Obj.Name, r.Obj.Author, r.Obj.Performer, r.Obj.MediaTrack?.Duration, resetIsAuto: false);

                // об'єкт існує в зовнішній бд
                if (r.Wic.HasValue && listObjectRightWithWID.SingleOrDefault(rec => rec.Wic == r.Wic) is ObjectRightWithWID obj)
                   rvm.SetObjectData(obj.Name, obj.Author, obj.Performer, resetIsAuto: false);

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