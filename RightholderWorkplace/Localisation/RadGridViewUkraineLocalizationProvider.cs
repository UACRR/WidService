using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI.Localization;

namespace RightholderWorkplace.Localisation
{
    class RadGridViewUkraineLocalizationProvider : RadGridLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            // for more translations see: https://docs.telerik.com/devtools/winforms/gridview/localization/localization

            switch (id)
            {
                case RadGridStringId.DeleteRowMenuItem: return "Видалити рядок";
                case RadGridStringId.PasteMenuItem: return "Вставити";
                case RadGridStringId.EditMenuItem: return "Редагувати";
                case RadGridStringId.ClearValueMenuItem: return "Очистити значення";
                case RadGridStringId.CopyMenuItem: return "Копіювати";
                case RadGridStringId.CutMenuItem: return "Вирізати";
                case RadGridStringId.AddNewRowString: return "Натисніть для додавання нового рядка";
            }
            return string.Empty;
        }
    }
}
