using System.Collections.Generic;
using System.Linq;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.Reports
{
    /// <summary>
    /// Керування станом кнопок 
    /// </summary>
    class ButtonEnableControl
    {
        private readonly RadButton _addReport;
        private readonly RadButton _create;
        private readonly RadButton _toAcception;
        private readonly RadButton _acceptedType1;
        private readonly RadButton _acceptedType2;

        public ButtonEnableControl(RadButton addReport, RadButton toAcception, RadButton acceptedType1, RadButton acceptedType2, RadButton create)
        {
            _addReport = addReport;
            _toAcception = toAcception;
            _acceptedType1 = acceptedType1;
            _acceptedType2 = acceptedType2;
            _create = create;
        }

        public void SetPeriodState(int? state, List<Register> list)
        {
            if (state == null)
            {
                _addReport.Enabled = false;
                _toAcception.Enabled = false;
                _acceptedType1.Enabled = false;
                _acceptedType2.Enabled = false;
                _create.Enabled = false;
                return;
            }

            int[] regStates = new[] {0, 0, 0, 0, 0, 0, 0, 0};
            int countInList = list.Count;
            // Накоплюємо кіль
            foreach (var item in list)
                regStates[item.RgStatus ?? 0]++;

            switch (state)
            {
                case 0: // Новий
                case 1: // Прийом звітів
                case 3: // Борг
                case 4: // Судова робота
                    _addReport.Enabled = true;
                    _create.Enabled = true;
                    _toAcception.Enabled = regStates[0] > 0; // Нових > 0;
                    _acceptedType1.Enabled = countInList > 0 && regStates[7] + regStates[3] + regStates[2] == countInList; // Всі погоджені
                    _acceptedType2.Enabled = countInList > 0 && regStates[7] + regStates[3] + regStates[2] == countInList; // Всі погоджені

                    break;
                case 2: // Прийом поштів
                case 5: // 
                case 6: // Кошти отримані
                    _addReport.Enabled = false;
                    _toAcception.Enabled = regStates[0] > 0; // Нових > 0;
                    _acceptedType1.Enabled = false;
                    _acceptedType2.Enabled = false;
                    _create.Enabled = false;
                    break;
                default: // Зактритий
                    _addReport.Enabled = false;
                    _toAcception.Enabled = false;
                    _acceptedType1.Enabled = false;
                    _acceptedType2.Enabled = false;
                    _create.Enabled = false;
                    break;
            }
        }
    }
}
