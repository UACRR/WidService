using ipsFormsDesign.Services;
using ipsFormsDesign.Services.ObjectUploading;
using System.Linq;
using System.Text;

namespace IpsViewComponentLibrary.Utilities
{
    public class ObjectRightLoaderFacade
    {
        private readonly ExcelEngine _excelEngine;
        private readonly ObjectRightDataParser _parser;
        private readonly ObjectRightDataClientSideValidator _clientValidator;
        private readonly DialogService _dialogService;

        public ObjectRightLoaderFacade()
        {
            _excelEngine = new ExcelEngine();
            _parser = new ObjectRightDataParser();
            _clientValidator = new ObjectRightDataClientSideValidator();
            _dialogService = new DialogService();
        }

        public void UploadFromExcel(string fileName)
        {
            var data = _excelEngine.ReadData(fileName);

            var objectList = _parser.Parse(data);

            _clientValidator.Validate(objectList);


            if (_clientValidator.Errors.Any())
            {
                _dialogService.ShowErrorView("Під час аналізу файлу виникли помилки. Завантаження не виконано.", _clientValidator.GetWarningsErrorsSescription());
            }

            if (_clientValidator.Warnings.Any())
            {
                if (_dialogService.ShowConfirmationView("Аналіз файлу виконано з попередженнями. Продовжити?", _clientValidator.GetWarningsErrorsSescription()))
                {
                    // server side validation
                }
            }
        }
    }
}
