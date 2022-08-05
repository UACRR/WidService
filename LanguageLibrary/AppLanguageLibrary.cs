using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using LanguageLibrary.Kernel;
using LanguageLibrary.Model;

namespace LanguageLibrary
{
    public static class AppLanguageLibrary
    {
        private static readonly LanguageLibraryHelper _LanguageLibraryHelper = new LanguageLibraryHelper();

        private static bool LanguageLoadNeed { get; set; }

        static AppLanguageLibrary()
        {
            try
            {
                string languageLoadNeed = ConfigurationManager.AppSettings["LanguageLoadNeed"];
                bool.TryParse(languageLoadNeed, out bool result);
                LanguageLoadNeed = result;
            }
            catch
            {
                LanguageLoadNeed = false;
            }
        }

        public static Dictionary<object, string> LanguagesMap { get; } = new Dictionary<object, string>();

        private static LanguageObjectModel _language;
        /// <summary>
        /// Поточний об'єкт мовної локалізації
        /// </summary>
        public static LanguageObjectModel CurrentLanguage
        {
            get
            {
                _language = _LanguageLibraryHelper.CurrentLanguageObjectModel;
                return _language;
            }
        }

        /// <summary>
        /// Поточні культурні налаштування
        /// </summary>
        public static CultureInfo ApplicationCultureInfo => _LanguageLibraryHelper.ApplicationCultureInfo;

        /// <summary>
        /// Змінити мовну локалізацію
        /// </summary>
        /// <param name="cultureInfo"></param>
        public static void ChangeCurrentCulture(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
                return;

            _LanguageLibraryHelper.ApplicationCultureInfo = cultureInfo;
        }

        /// <summary>
        /// Отримати список наявних мовних локалізацій
        /// </summary>
        /// <returns></returns>
        public static List<LanguageInfo> GetLanguagesList()
        {
            var list = _LanguageLibraryHelper.GetLanguagesInfoList();
            return list;
        }

        /// <summary>
        /// Синхронізація на клієнті
        /// </summary>
        /// <returns></returns>
        public static async Task SyncOnClient()
        {
            await _LanguageLibraryHelper.SyncOnClient();
        }

        public static void UpdateLanguageLocalizations()
        {
            foreach (var item in LanguagesMap)
            {
                UpdateLanguageLocalization(item.Key, item.Value);
            }
        }

        public static void UpdateLanguageLocalization<TTarget>(TTarget target, string sourceName)
        {
            if (!LanguageLoadNeed)
                return;

            var source = CurrentLanguage.GetType().GetProperty(sourceName)?.GetValue(CurrentLanguage);
            if (source == null)
                return;

            foreach (var prop in source.GetType().GetProperties())
            {
                LanguageItem li = (LanguageItem)prop.GetValue(source);

                var sourceProperty = target.GetType().GetProperty(prop.Name);
                if (sourceProperty != null)
                {
                    sourceProperty.SetValue(target, string.IsNullOrEmpty(li.Content) ? li.DefaultContent : li.Content);
                }
            }
        }
    }
}
