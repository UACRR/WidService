using ipsFormsDesign;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace IpsViewComponentLibrary.RegisterControls
{
    public class SearchObjectPresenter
    {
        private readonly SearchObjectView _view;
        private readonly RegisterService _registerService;
        private readonly DialogService _dialogService;
        private readonly List<RegisterItemViewModel> _sourceRegisterItemList;

        public SearchObjectPresenter(SearchObjectView view, RegisterService registerService)
        {
            _view = view;
            _view.Presenter = this;

            _registerService = registerService;
            _dialogService = new DialogService();

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

            if (foundedObject.Count != 0)
            {
                foreach (var obj in foundedObject)
                {
                    _view.FoundedObjectList.Add(obj);
                }
            }
            else
            {
                _dialogService.ShowMessage(_view, "Співпадінь не знайдено.");
            }
        }

        public void LinkObjectToRegisterItem(RegisterItemViewModel registerItem, RegisterSearchObject registerSearchObject)
        {
            registerItem.SetObjectData(
                registerSearchObject.ObjId,
                registerSearchObject.Name,
                registerSearchObject.Author,
                registerSearchObject.Performer,
                registerSearchObject.Duration
            );
        }

        public void Apply()
        {
            foreach (var registerItem in _view.RegisterItemList)
            {
                var foundedRegisterItem = _sourceRegisterItemList.FirstOrDefault(r => r.RegId == registerItem.RegId && r.RegIitemId == registerItem.RegIitemId);

                if (foundedRegisterItem != null)
                {
                    foundedRegisterItem.SetObjectData(
                        registerItem.ObjId,
                        registerItem.ObjectName,
                        registerItem.ObjectAuthors,
                        registerItem.ObjectPerformers,
                        registerItem.ObjectDuration
                    );
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
