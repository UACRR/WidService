using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ipsFormsDesign.Services.ObjectUploading
{
    public class ObjectRightDataValidator
    {
        public List<string> Errors { get; } = new List<string>();
        public List<string> Warnings { get; } = new List<string>();

        public void ValidateClientSide(List<ObjectRightData> objectList)
        {
            Errors.Clear();
            Warnings.Clear();

            foreach (var obj in objectList)
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

        public void ValidateServerSide(List<ObjectRightData> objectList)
        {
            Errors.Clear();
            Warnings.Clear();

            foreach (var obj in objectList)
            {
                if (obj.ObjId.HasValue)
                {
                    AddWarning(obj.RowNum, $"Об'єкт з назвою '{obj.Name}' вже є в базі даних. Завантажуватися не буде");
                }

                if (!obj.GenreId.HasValue)
                {
                    AddError(obj.RowNum, $"Жанр з назвою '{obj.Genre}' не знайдений");
                }

                foreach (var rightholder in obj.Rightholders)
                {
                    if (rightholder.CreativeRole == "виконавець")
                        continue;

                    if (!rightholder.RoleId.HasValue)
                    {
                        AddError(rightholder.RowNum, $"Творча роль з назвою '{rightholder.CreativeRole}' не знайдена");
                    }

                    if (!rightholder.CustId.HasValue)
                    {
                        AddError(rightholder.RowNum, $"Правовласник '{rightholder.Name}' не знайдений");
                    }
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
