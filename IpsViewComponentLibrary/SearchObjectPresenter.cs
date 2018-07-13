using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary
{
    public class SearchObjectPresenter
    {
        private readonly SearchObjectView _view;

        public SearchObjectPresenter(SearchObjectView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public void Show(RegisterItem registerItem)
        {
            _view.RegisterItemList.Add(registerItem);
            _view.Run();
        }
    }
}
