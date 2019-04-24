using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.CatalogControls.Presenters
{
    public class CatalogPresenter
    {
        private CatalogService _service;

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
