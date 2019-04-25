using System.Collections.Generic;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.CatalogControls.Presenters
{
    public class CatalogPresenter
    {
        private readonly CatalogService _service;

        public CatalogPresenter()
        {
            _service = CatalogService.GetInstance();
        }

        public List<T> GetFileList<T>() where T: class 
        {
            return new List<T>();
        }
    }
}
