using ipsFormsDesign.Model;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary
{
    public class SearchObjectPresenter
    {
        private readonly SearchObjectView _view;
        private readonly RegisterService _registerService;

        public SearchObjectPresenter(SearchObjectView view, RegisterService registerService)
        {
            _view = view;
            _view.Presenter = this;

            _registerService = registerService;
        }

        public void Show(RegisterItem registerItem)
        {
            _view.RegisterItemList.Add(registerItem);
            _view.Run();
        }

        public void Search(RegisterItem registerItem)
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
