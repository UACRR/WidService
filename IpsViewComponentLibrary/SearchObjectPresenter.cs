using ipsFormsDesign;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace IpsViewComponentLibrary
{
    public class SearchObjectPresenter
    {
        private readonly SearchObjectView _view;
        private readonly RegisterService _registerService;
        private readonly List<RegisterItemViewModel> _sourceRegisterItemList;

        public SearchObjectPresenter(SearchObjectView view, RegisterService registerService)
        {
            _view = view;
            _view.Presenter = this;

            _registerService = registerService;

            _sourceRegisterItemList = new List<RegisterItemViewModel>();
        }

        public void Show(RegisterItemViewModel registerItem)
        {
            _sourceRegisterItemList.Add(registerItem);
            CopyRegisterItemListToView();
            _view.Run();
        }


        public void Show(IEnumerable<RegisterItemViewModel> registerItemList)
        {
            _sourceRegisterItemList.AddRange(registerItemList);
            CopyRegisterItemListToView();
            _view.Run();
        }

        public void Search(RegisterItemViewModel registerItem)
        {
            _view.FoundedObjectList.Clear();

            var foundedObject = _registerService.SearchObjects(
                registerItem.ItemName,
                registerItem.AuthorMusic + ", " + registerItem.AuthorText,
                registerItem.Performer
            );

            foreach (var obj in foundedObject)
            {
                _view.FoundedObjectList.Add(obj);
            }
        }

        public void LinkObjectToRegisterItem(RegisterItemViewModel registerItem, RegisterSearchObject registerSearchObject)
        {
            registerItem.ObjId = registerSearchObject.ObjId;
            registerItem.ObjectName = registerSearchObject.Name;
            registerItem.ObjectAuthors = registerSearchObject.Author;
            registerItem.ObjectPerformers = registerSearchObject.Performer;
            registerItem.ObjectDuration = registerSearchObject.Duration;
        }

        public void Save()
        {
            // TODO: save to db, if success update list

            foreach (var registerItem in _view.RegisterItemList)
            {
                var foundedRegisterItem = _sourceRegisterItemList.FirstOrDefault(r => r.RegId == registerItem.RegId && r.RegIitemId == registerItem.RegIitemId);

                if (foundedRegisterItem != null)
                {
                    foundedRegisterItem.ObjId = registerItem.ObjId;
                    foundedRegisterItem.ObjectName = registerItem.ObjectName;
                    foundedRegisterItem.ObjectAuthors = registerItem.ObjectAuthors;
                    foundedRegisterItem.ObjectPerformers = registerItem.ObjectPerformers;
                    foundedRegisterItem.ObjectDuration = registerItem.ObjectDuration;
                }
            }
        }

        private void CopyRegisterItemListToView()
        {
            foreach (var r in _sourceRegisterItemList)
            {
                var clonedRegisterItem = new RegisterItemViewModel();

                Utils.SetFields(clonedRegisterItem, r);
                clonedRegisterItem.DurationItem = r.DurationItem;
                clonedRegisterItem.DurationUse = r.DurationUse;
                clonedRegisterItem.ObjectDuration = r.ObjectDuration;

                _view.RegisterItemList.Add(clonedRegisterItem);
            }
        }
    }
}
