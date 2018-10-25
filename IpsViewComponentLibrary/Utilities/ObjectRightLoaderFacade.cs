using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Services.ObjectUploading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IpsViewComponentLibrary.Utilities
{
    public class ObjectRightLoaderFacade
    {
        private readonly ExcelEngine _excelEngine;
        private readonly ObjectRightDataParser _parser;
        private readonly ObjectRightDataClientSideValidator _clientValidator;
        private readonly ObjectRightService _objectRightService;
        private readonly DialogService _dialogService;

        public ObjectRightLoaderFacade()
        {
            _excelEngine = new ExcelEngine();
            _parser = new ObjectRightDataParser();
            _clientValidator = new ObjectRightDataClientSideValidator();
            _objectRightService = new ObjectRightService();
            _dialogService = new DialogService();
        }

        public void UploadFromExcel(string fileName)
        {
            var data = _excelEngine.ReadData(fileName);

            var objectList = _parser.Parse(data);

            // client side validation
            _clientValidator.Validate(objectList);
            if (_clientValidator.Errors.Any())
            {
                _dialogService.ShowErrorView("Під час аналізу файлу виникли помилки. Завантаження не виконано.", _clientValidator.GetWarningsErrorsSescription());
                return;
            }

            if (_clientValidator.Warnings.Any())
            {
                if (!_dialogService.ShowConfirmationView("Аналіз файлу виконано з попередженнями. Продовжити?", _clientValidator.GetWarningsErrorsSescription()))
                    return;
            }

            objectList = _objectRightService.ValidateObjectsRight(objectList);

            //var list = new List<ObjectRight>();

            //foreach (var obj in objectList)
            //{
            //    var newObj = 
            //}
        }
    }
}
