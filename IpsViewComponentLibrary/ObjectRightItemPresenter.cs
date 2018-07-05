
namespace IpsViewComponentLibrary
{
    public class ObjectRightItemPresenter
    {
        private readonly ObjectRightItemView _view;

        public ObjectRightItemPresenter(ObjectRightItemView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public void Run()
        {
            _view.Run();
        }
    }
}
