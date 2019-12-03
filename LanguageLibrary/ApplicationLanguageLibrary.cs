using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageLibrary.Kernel;

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
            _LanguageLibraryHelper.LoadLanguageInfo();
            return null;
        }

        public static List<object> GetLanguagesForCreate()
        {
            return null;
        }

        public static void CreateLanguage()
        {
            _LanguageLibraryHelper.CreateLanguageTemplate();
        }

        public static void GetLanguageData()
        {

        }

        public static void UpdateLanguageData()
        {

        }
    }
}
