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
                if (_language == null)
                {
                    _LanguageLibraryHelper.LoadApplicationCultureInfo();
                    _language = _LanguageLibraryHelper.GetLanguage(Thread.CurrentThread.CurrentCulture);
                }

                return _language;
            }
        }

        /// <summary>
        /// Змінити мовну локалізацію
        /// </summary>
        /// <param name="cultureInfo"></param>
        public static void ChangeCurrentCulture(CultureInfo cultureInfo)
        {
            _LanguageLibraryHelper.SetApplicationCultureInfo(cultureInfo);
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
