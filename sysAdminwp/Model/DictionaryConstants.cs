namespace sysAdminwp.Model
{
    public static class DictionaryConstants
    {
        public const string NotUniquenessCodeWarningMsg = "Введений код належить іншому запису довідника!";

        public const string SaveNewRecordSuccessMsg = "Новий запис в довідник додано!";
        public const string SaveNewRecordErrorMsg = "Неможливо додати новий запис в довідник!";

        public const string DeleteRecordConfirmMsg = "Видалити запис?";
        public const string DeleteRecordSuccessMsg = "Запис з довідника видалено!";
        public const string DeleteRecordErrorMsg = "Неможливо видалити запис з довідника! Запис використовується в іншій таблиці через \"FOREIGN KEY\"!";

        public const string UkLang = "Uk";
        public const string RuLang = "Ru";
        public const string EnLang = "En";
    }
}
