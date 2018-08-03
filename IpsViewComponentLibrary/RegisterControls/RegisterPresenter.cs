using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Events;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.AppController;
using System;
using System.Linq;

namespace IpsViewComponentLibrary.RegisterControls
{
    public class RegisterPresenter
    {
        private readonly RegisterView _view;
        private readonly RegisterService _registerService;
        private Register _register;

        public RegisterPresenter(RegisterView view, RegisterService registerService)
        {
            _view = view;
            _view.Presenter = this;

            _registerService = registerService;
        }

        public void Show(int regId)
        {
            _register = _registerService.GetById(regId);
            UpdateDataBindings();
            _view.Run();
        }

        public void SearchObjectsAuto()
        {
            var result =_registerService.AutoSearch(_register.RegId);

            if (!result)
            {
                _view.ShowError("Не вдалося виконати автоматичну прив'язку об'єктів права.");
                return;
            }

            _register = _registerService.GetById(_register.RegId);
            UpdateDataBindings();
        }

        public void SearchObjects(RegisterItemViewModel selectedRegisterItem)
        {
            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, _registerService);
                presenter.Show(selectedRegisterItem);
            }
        }

        public void SearchObjectsForAll()
        {
            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, _registerService);
                presenter.Show(_view.RegisterItemList);
            }
        }

        public void SearchObjectsForNotLinked()
        {
            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, _registerService);
                presenter.Show(_view.RegisterItemList.Where(r => r.ObjId == null));
            }
        }

        public void SearchObjectsForSelected()
        {
            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, _registerService);
                presenter.Show(_view.SelectedRegisterItems);
            }
        }

        public void CreateObjectsForSelected()
        {
            var objectRightService = new ObjectRightService();

            var createdObjectCount = 0;

            foreach (var registerItem in _view.SelectedRegisterItems)
            {
                var newObject = objectRightService.NewObjectRight(5);
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
                    _view.ShowError("Не вдалося створити об'єкт з назвою " + registerItem.ItemName);
                }
            }

            ApplicationController.Instance.EventAggregator.PublishEvent(new ObjectRightAddedEvent());

            _view.ShowMessage($"Створено {createdObjectCount} об'єктів.");
        }

        public void SetStatus(RegisterStatusType status)
        {
            var result = _registerService.SetStatus(_register.RegId, status);

            if (result)
            {
                _register.RgStatus = (int)status;
                
                _view.SetStatus(status);
            }
            else
                _view.ShowError("Не вдалося змінити статус.");
        }

        public void Save()
        {
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
                };
            }

            var result = _registerService.Save(_register);
        }

        private void UpdateDataBindings()
        {
            _view.Register = _register;
            _view.RegisterItemList.Clear();

            foreach (var r in _register.RegisterItem)
            {
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
                };

                if (r.Obj != null)
                    rvm.SetObjectData(r.ObjId, r.Obj.Name, r.Obj.Author, r.Obj.Performer, r.Obj.MediaTrack?.Duration, resetIsAuto: false);

                _view.RegisterItemList.Add(rvm);
            }
        }
    }
}
