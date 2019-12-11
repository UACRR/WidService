using ipsFormsDesign;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.RegisterControls
{
    public class SearchObjectPresenter
    {
        private readonly SearchObjectView _view;
        private readonly RegisterService _registerService;
        private readonly RegisterWIDService _registerWidService;
        private readonly DialogService _dialogService;
        private readonly List<RegisterItemViewModel> _sourceRegisterItemList;

        public SearchObjectPresenter(SearchObjectView view, RegisterService registerService)
        {
            _view = view;
            _view.Presenter = this;
            _registerWidService = RegisterWIDService.GetInstance();
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

        /// <summary>
        /// Пошук по локальній БД
        /// </summary>
        /// <param name="registerItem"></param>
        public async void SearchInLocal(RegisterItemViewModel registerItem)
        {
            _view.FoundedObjectList.Clear();

            string name = registerItem.ItemName;
            string authors = registerItem.AuthorMusic + ", " + registerItem.AuthorText;
            string performer = registerItem.Performer;

            List<RegisterSearchObject> foundedObject = null;
            _view.StartWaiting();
            await Task.Factory.StartNew(() => foundedObject = _registerWidService.SearchObjectsLocal(name, authors, performer));
            _view.StopWaiting();

            //var foundedObject = _registerService.SearchObjects(
            //    registerItem.ItemName,
            //    registerItem.AuthorMusic + ", " + registerItem.AuthorText,
            //    registerItem.Performer
            //);

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

        /// <summary>
        /// Пошук по WID БД
        /// </summary>
        /// <param name="registerItem"></param>
        public async void SearchInWID(RegisterItemViewModel registerItem)
        {
            _view.FoundedObjectList.Clear();

            string name = registerItem.ItemName;

            string authors = string.Empty;
            if (!string.IsNullOrWhiteSpace(registerItem.AuthorMusic) && !string.IsNullOrWhiteSpace(registerItem.AuthorText))
            {
                authors = registerItem.AuthorMusic + ", " + registerItem.AuthorText;
            }
            else
            {
                authors = registerItem.AuthorMusic + registerItem.AuthorText;
            }

            string performer = registerItem.Performer;

            List<RegisterSearchObject> foundedObject = null;
            _view.StartWaiting();
            await Task.Factory.StartNew(() => foundedObject = _registerWidService.SearchObjectsWid(name, authors, performer));
            _view.StopWaiting();

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
            registerItem.SetObjectData(registerSearchObject);
        }

        public void Apply()
        {
            foreach (var registerItem in _view.RegisterItemList)
            {
                var foundedRegisterItem = _sourceRegisterItemList.FirstOrDefault(r => r.RegId == registerItem.RegId && r.RegIitemId == registerItem.RegIitemId);

                if (foundedRegisterItem == null)
                    continue;

                foundedRegisterItem.SetObjectData(registerItem);
                foundedRegisterItem.ObjectDuration = registerItem.ObjectDuration;
            }
        }

        private void CopyRegisterItemListToView()
        {
            foreach (var r in _sourceRegisterItemList)
            {
                var clonedRegisterItem = new RegisterItemViewModel();

                clonedRegisterItem.SetFields(r);
                clonedRegisterItem.DurationItem = r.DurationItem;
                clonedRegisterItem.DurationUse = r.DurationUse;
                clonedRegisterItem.ObjectDuration = r.ObjectDuration;

                _view.RegisterItemList.Add(clonedRegisterItem);
            }
        }
    }
}
