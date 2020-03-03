using System.Collections.Generic;
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

        private static LanguageObjectModel _language;
        /// <summary>
        /// Поточний об'єкт мовної локалізації
        /// </summary>
        public static LanguageObjectModel CurrentLanguage
        {
            get
            {
                _language = _LanguageLibraryHelper.CurrentLanguageObjectModel;
                //_language = _LanguageLibraryHelper.GetLanguage();
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
    }
}
