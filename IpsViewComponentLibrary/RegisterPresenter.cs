using System;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary
{
    public class RegisterPresenter
    {
        private readonly RegisterView _view;
        private readonly RegisterService _registerService;

        public RegisterPresenter(RegisterView view, RegisterService registerService)
        {
            _view = view;
            _view.Presenter = this;

            _registerService = registerService;
        }

        public void Show(int regId)
        {
            var register = _registerService.GetById(regId);
            _view.Register = register;
            _view.Run();
        }

        internal void SearchObjects(RegisterItem selectedRegisterItem)
        {
            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, _registerService);
                presenter.Show(selectedRegisterItem);
            }
        }
    }
}
