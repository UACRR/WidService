using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Services;
using System.Collections.Generic;

namespace IpsViewComponentLibrary
{
    public class SearchObjectPresenter
    {
        private readonly SearchObjectView _view;
        private readonly RegisterService _registerService;
        private readonly List<RegisterItemViewModel> _registerItemList;

        public SearchObjectPresenter(SearchObjectView view, RegisterService registerService)
        {
            _view = view;
            _view.Presenter = this;

            _registerService = registerService;

            _registerItemList = new List<RegisterItemViewModel>();
        }

        public void Show(RegisterItemViewModel registerItem)
        {
            _registerItemList.Add(registerItem);

            _view.RegisterItemListDataSource = _registerItemList;
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
    }
}
