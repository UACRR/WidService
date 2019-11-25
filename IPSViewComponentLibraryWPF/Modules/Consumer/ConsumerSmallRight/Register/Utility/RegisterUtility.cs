using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Model;
using IPSViewComponentLibraryWPF.IPSExtensions;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Utility
{
    public class RegisterUtility
    {
        private const string WarningMsg = "Неможливо обробити звіт! В звіті наявні дублі (поля: назва твору, виконавець, автор музики, автор тексту)!";
        private const string EmptyRecordFoundMsg = "Знайдені записи з пустими полями \"назва твору\", \"виконавець\", \"автор музики\" та \"автор тексту\"! Такі записи будуть видалені автомаично!";

        /// <summary>
        /// Перевірити звичайний звіт з файлу або ручного введення на наявність дублів
        /// </summary>
        /// <param name="items"></param>
        /// <returns>true - дублі наявні, false - дублі відсутні</returns>
        public static bool CheckRepeatableRecords(ICollection<RegisterItem> items)
        {
            var arrayItems = items.ToArray();
            for (int i = 0; i < arrayItems.Length; i++)
            {
                var remainsList = arrayItems.Skip(i + 1).ToArray();
                foreach (var registerItem in remainsList)
                {
                    var eqItemName = string.Equals(registerItem.ItemName, arrayItems[i].ItemName, StringComparison.CurrentCultureIgnoreCase);
                    var eqPerformer = string.Equals(registerItem.Performer, arrayItems[i].Performer, StringComparison.CurrentCultureIgnoreCase);
                    var eqAuthorMusic = string.Equals(registerItem.AuthorMusic, arrayItems[i].AuthorMusic, StringComparison.CurrentCultureIgnoreCase);
                    var eqAuthorText = string.Equals(registerItem.AuthorText, arrayItems[i].AuthorText, StringComparison.CurrentCultureIgnoreCase);
                    if (eqItemName && eqPerformer && eqAuthorMusic && eqAuthorText)
                    {
                        ShowMessage.ShowWarning(WarningMsg);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Пошук та видалення пустих записів в звіті
        /// </summary>
        /// <param name="items"></param>
        public static void RemoveEmptyRecord(ICollection<RegisterItem> items)
        {
            ICollection<RegisterItem> removeListCollection = items.Where(rec =>
            {
                return string.IsNullOrWhiteSpace(rec.ItemName) &&
                       string.IsNullOrWhiteSpace(rec.Performer) &&
                       string.IsNullOrWhiteSpace(rec.AuthorMusic) &&
                       string.IsNullOrWhiteSpace(rec.AuthorText);
            }).ToList();

            if (removeListCollection.Any())
                ShowMessage.ShowInfo(EmptyRecordFoundMsg);

            foreach (var registerItem in removeListCollection)
                items.Remove(registerItem);
        }
    }
}
