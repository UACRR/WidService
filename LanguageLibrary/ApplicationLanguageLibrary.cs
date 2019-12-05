using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageLibrary.Kernel;
using LanguageLibrary.Model;

namespace LanguageLibrary
{
    public static class ApplicationLanguageLibrary
    {
        private static readonly Dictionary<string, CultureInfo> _languageDictionary = new Dictionary<string, CultureInfo>
        {
            ["en-US"] = new CultureInfo("en-US"),
            ["uk-UA"] = new CultureInfo("uk-UA"),
            ["ru-RU"] = new CultureInfo("ru-RU"),
        };

        private static readonly LanguageLibraryHelper _LanguageLibraryHelper = new LanguageLibraryHelper();

        private static LanguageObjectModel _language;

        /// <summary>
        /// Отримати кофігурацію мови
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static LanguageObjectModel GetLanguage(CultureInfo cultureInfo)
        {
            if (_language == null)
                _language = _LanguageLibraryHelper.GetLanguageData(cultureInfo);

            return _language;
        }

        public static List<LanguageInfo> GetLanguagesList()
        {
            var list = _LanguageLibraryHelper.GetLanguagesInfoList();
            return list;
        }

        public static void ChangeLanguage(LanguageName languageName)
        {
            switch (languageName)
            {
                case LanguageName.English:
                    break;
                case LanguageName.Ukrainian:
                    break;
                case LanguageName.Russian:
                    break;
                default:
                    //Resources.ApplicationLanguage["ApplicationLanguage"] = "";
                    break;
            }
        }

        public static List<LanguageInfo> GetLanguageListForCreate()
        {
            var list = new List<LanguageInfo>
            {
                new LanguageInfo
                {
                    LanguageName = "Français",
                    UkrainianName = "Французька",
                    SpecificationCode = "fr-FR",
                    IncompletenessItemCount = 2000,
                },

                new LanguageInfo
                {
                    LanguageName = "Español",
                    UkrainianName = "Іспанська",
                    SpecificationCode = "es-ES",
                    IncompletenessItemCount = 2000,
                },

                new LanguageInfo
                {
                    LanguageName = "Deutsch",
                    UkrainianName = "Німецька",
                    SpecificationCode = "de-DE",
                    IncompletenessItemCount = 2000,
                },

                new LanguageInfo
                {
                    LanguageName = "Български",
                    UkrainianName = "Болгарська",
                    SpecificationCode = "bg-BG",
                    IncompletenessItemCount = 2000,
                },

                new LanguageInfo
                {
                    LanguageName = "Қазақ",
                    UkrainianName = "Казахська",
                    SpecificationCode = "kk-KZ",
                    IncompletenessItemCount = 2000,
                },
            };

            return list;
        }

        public static void CreateLanguage(LanguageInfo languageInfo)
        {
            _LanguageLibraryHelper.CreateNewLanguage(languageInfo);
        }

        public static void UpdateLanguage(object o)
        {

        }
    }
}
