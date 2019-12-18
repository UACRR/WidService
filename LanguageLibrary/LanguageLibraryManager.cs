using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using LanguageLibrary.Kernel;
using LanguageLibrary.Model;

namespace LanguageLibrary
{
    public static class LanguageLibraryManager
    {
        private static readonly List<LanguageInfo> _languagesList = new List<LanguageInfo>
        {
            new LanguageInfo
            {
                LanguageName = "Українська",
                UkrainianName = "Українська",
                SpecificationCode = "uk-UA",
            },

            new LanguageInfo
            {
                LanguageName = "English",
                UkrainianName = "Англійська",
                SpecificationCode = "en-US"
            },

            new LanguageInfo
            {
                LanguageName = "Русский",
                UkrainianName = "Російська",
                SpecificationCode = "ru-RU"
            },

            new LanguageInfo
            {
                LanguageName = "Français",
                UkrainianName = "Французька",
                SpecificationCode = "fr-FR",
            },

            new LanguageInfo
            {
                LanguageName = "Español",
                UkrainianName = "Іспанська",
                SpecificationCode = "es-ES",
            },

            new LanguageInfo
            {
                LanguageName = "Deutsch",
                UkrainianName = "Німецька",
                SpecificationCode = "de-DE",
            },

            new LanguageInfo
            {
                LanguageName = "Български",
                UkrainianName = "Болгарська",
                SpecificationCode = "bg-BG",
            },

            new LanguageInfo
            {
                LanguageName = "Қазақ",
                UkrainianName = "Казахська",
                SpecificationCode = "kk-KZ",
            },
        };

        private static readonly LanguageLibraryHelper _LanguageLibraryHelper = new LanguageLibraryHelper();

        /// <summary>
        /// Отримати дані для редагування мови
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static List<LanguageDataModel> GetLanguageData(LanguageInfo cultureInfo)
        {
            var item = _LanguageLibraryHelper.GetLanguageData(cultureInfo);
            return item;
        }

        /// <summary>
        /// Оновити дані мови
        /// </summary>
        /// <param name="languageInfo"></param>
        /// <param name="dataModel"></param>
        public static void UpdateLanguageData(LanguageInfo languageInfo, LanguageDataModel dataModel)
        {
            _LanguageLibraryHelper.UpdateLanguageData(languageInfo, dataModel);
        }

        /// <summary>
        /// Отримати список мов
        /// </summary>
        /// <returns></returns>
        public static List<LanguageInfo> GetLanguagesList()
        {
            List<LanguageInfo> list = _LanguageLibraryHelper.GetLanguagesInfoList();
            
            foreach (var item in list)
            {
                var removeItem = _languagesList.SingleOrDefault(rec => rec.SpecificationCode == item.SpecificationCode);
                
                if (removeItem != null)
                    _languagesList.Remove(removeItem);
            }

            return list;
        }

        /// <summary>
        /// Отримати список мов які можна створити
        /// </summary>
        /// <returns></returns>
        public static List<LanguageInfo> GetPossibleLanguageList()
        {
            return _languagesList;
        }

        /// <summary>
        /// Створити нову мову
        /// </summary>
        /// <param name="languageInfo"></param>
        public static void CreateLanguage(LanguageInfo languageInfo)
        {
            _LanguageLibraryHelper.CreateNewLanguage(languageInfo);
        }

        /// <summary>
        /// Синхронізація об'єктів
        /// </summary>
        public static void Sync()
        {
            _LanguageLibraryHelper.SyncLanguageDataObjectModel();
            _LanguageLibraryHelper.SyncDefaultContent();
        }

        /// <summary>
        /// Синхронізувати на сервері
        /// </summary>
        /// <returns></returns>
        public static async Task<ResponseOfRequest> SyncOnServer()
        {
            var result = await _LanguageLibraryHelper.SyncOnServer();
            return result;
        }
    }
}
