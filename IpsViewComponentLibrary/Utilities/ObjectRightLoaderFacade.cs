using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Services.ObjectUploading;
using ipsFormsDesign.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IpsViewComponentLibrary.Utilities
{
    public class ObjectRightLoaderFacade
    {
        private readonly ExcelEngine _excelEngine;
        private readonly ObjectRightDataParser _parser;
        private readonly ObjectRightDataValidator _validator;
        private readonly ObjectRightService _objectRightService;
        private readonly DialogService _dialogService;

        public ObjectRightLoaderFacade()
        {
            _excelEngine = new ExcelEngine();
            _parser = new ObjectRightDataParser();
            _validator = new ObjectRightDataValidator();
            _objectRightService = new ObjectRightService();
            _dialogService = new DialogService();
        }

        public void UploadFromExcel(string fileName)
        {
            var data = _excelEngine.ReadData(fileName);

            var objectList = _parser.Parse(data);

            _validator.ValidateClientSide(objectList);
            if (_validator.Errors.Any())
            {
                _dialogService.ShowErrorView("Під час аналізу файлу виникли помилки. Завантаження не виконано.", _validator.GetWarningsErrorsSescription());
                return;
            }

            if (_validator.Warnings.Any())
            {
                if (!_dialogService.ShowConfirmationView("Аналіз файлу виконано з попередженнями. Продовжити?", _validator.GetWarningsErrorsSescription()))
                    return;
            }

            objectList = _objectRightService.ValidateObjectsRight(objectList);
            _validator.ValidateServerSide(objectList);
            if (_validator.Errors.Any())
            {
                _dialogService.ShowErrorView("Під час аналізу файлу виникли помилки. Завантаження не виконано.", _validator.GetWarningsErrorsSescription());
                return;
            }

            if (_validator.Warnings.Any())
            {
                if (!_dialogService.ShowConfirmationView("Аналіз файлу виконано з попередженнями. Продовжити?", _validator.GetWarningsErrorsSescription()))
                    return;
            }

            var list = new List<ObjectRight>();

            foreach (var obj in objectList)
            {
                if (obj.ObjId.HasValue)
                    continue;

                var newObj = _objectRightService.New(5);
                newObj.SetDataFromObjectRightData(obj);

                list.Add(newObj);
            }

            //_objectRightService.Save();
        }
    }
}
