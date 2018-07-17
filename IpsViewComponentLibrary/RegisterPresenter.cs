using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System.Linq;

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
            UpdateDataBindings(register);
            _view.Run();
        }

        public void SearchObjects(RegisterItemViewModel selectedRegisterItem)
        {
            using (var view = new SearchObjectView())
            {
                var presenter = new SearchObjectPresenter(view, _registerService);
                presenter.Show(selectedRegisterItem);
            }
        }

        private void UpdateDataBindings(Register register)
        {
            _view.Register = register;
            _view.RegisterItemDataSource = register.RegisterItem.Select(r =>
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
                    ObjId = r.ObjId,
                };

                if (r.Obj != null)
                {
                    rvm.ObjectName = r.Obj.Name;
                    rvm.ObjectAuthors = r.Obj.Author;
                    rvm.ObjectPerformers = r.Obj.Performer;
                    rvm.ObjectDuration = r.Obj.MediaTrack.Duration;
                }

                return rvm;
            });
        }
    }
}
