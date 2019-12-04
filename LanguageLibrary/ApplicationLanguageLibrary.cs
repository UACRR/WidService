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

        public static void LoadLanguage()
        {
            //if (_languageDictionary.ContainsKey(languageName))
            //    Languages.Language.Culture = _languageDictionary[languageName];
            //else
            //    Languages.Language.Culture = null;
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

        public static List<object> GetExistLanguages()
        {
            var random = new Random();
            //_LanguageLibraryHelper.LoadLanguageInfo();
            //_LanguageLibraryHelper.UpdateLanguageInfo(new LanguageInfo
            //{
            //    IncompletenessItemCount = random.Next(1, 2000),
            //    SpecificationCode = "ru-RU",
            //});
            _LanguageLibraryHelper.CreateNewLanguage(new LanguageInfo
            {
                LanguageName = "Русский",
                UkrainianName = "Російська",
                IncompletenessItemCount = 1654,
                SpecificationCode = "ru-RU",
            });
            return null;
        }

        public static List<object> GetLanguagesForCreate()
        {
            return null;
        }

        public static void CreateLanguage()
        {

        }

        public static void GetLanguageData()
        {

        }

        public static void UpdateLanguageData()
        {

        }
    }
}
