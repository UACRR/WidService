using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ipsFormsDesign.Services.ObjectUploading
{
    public class ObjectRightDataClientSideValidator
    {
        private List<ObjectRightData> _objectList;

        public List<string> Errors { get; } = new List<string>();
        public List<string> Warnings { get; } = new List<string>();

        public void Validate(List<ObjectRightData> objectList)
        {
            _objectList = objectList;

            foreach (var obj in _objectList)
            {
                ValidateStringIsNotEmpty("Назва твору", obj.Name, obj.RowNum);
                ValidateStringIsNotEmpty("Жанр", obj.Genre, obj.RowNum);

                ValidateTotalPersent(obj.Rightholders);

                foreach (var rightholder in obj.Rightholders)
                {
                    ValidateStringIsNotEmpty("Творча роль", rightholder.CreativeRole, rightholder.RowNum);
                    ValidateStringIsNotEmpty("ПІБ автора", rightholder.Name, rightholder.RowNum);
                }
            }
        }

        public string GetWarningsErrorsSescription()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Помилки:");
            sb.AppendLine();
            foreach (var err in Errors)
            {
                sb.AppendLine(err);
            }
            sb.AppendLine();
            sb.AppendLine("Попередження:");
            sb.AppendLine();
            foreach (var warn in Warnings)
            {
                sb.AppendLine(warn);
            }

            return sb.ToString();
        }

        private void ValidateStringIsNotEmpty(string fieldName, string value, int row)
        {
            if (string.IsNullOrEmpty(value))
            {
                AddError(row, $"Поле '{fieldName}' є обов'язковим");
            }
        }

        private void ValidateTotalPersent(List<RightholderData> rightholders)
        {
            var totalPersent = rightholders.Sum(r => r.Rate);

            if (totalPersent > 100)
            {
                AddError(rightholders.First().RowNum, "Загальний відсоток володіння по об'єкту перевищує 100%");
            }
            else if (totalPersent == 0)
            {
                AddWarning(rightholders.First().RowNum, "Загальний відсоток володіння по об'єкту дорівнює 0%");
            }
        }

        private void AddError(int row, string text)
        {
            Errors.Add($"Рядок {row}. {text}.");
        }

        private void AddWarning(int row, string text)
        {
            Warnings.Add($"Рядок {row}. {text}.");
        }
    }
}
