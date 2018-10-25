using ipsFormsDesign.Services.ObjectUploading;
using System.Linq;

namespace ipsFormsDesign.Services
{
    public class ObjectRightLoaderFacade
    {
        private readonly ExcelEngine _excelEngine;
        private readonly ObjectRightDataParser _parser;
        private readonly ObjectRightDataClientSideValidator _clientValidator;

        public ObjectRightLoaderFacade()
        {
            _excelEngine = new ExcelEngine();
            _parser = new ObjectRightDataParser();
            _clientValidator = new ObjectRightDataClientSideValidator();
        }

        public void UploadFromExcel(string fileName)
        {
            var data = _excelEngine.ReadData(fileName);

            var objectList = _parser.Parse(data);

            _clientValidator.Validate(objectList);

            if (_clientValidator.Errors.Any())
            {
                // show errors end return
            }

            if (_clientValidator.Warnings.Any())
            {
                // request for upload to user
            }
        }
    }
}
