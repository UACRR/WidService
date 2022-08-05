using System;
using System.Windows;
using System.Windows.Forms;
using Telerik.WinControls;
using MessageBox = System.Windows.MessageBox;

namespace IPSViewComponentLibraryWPF.IPSExtensions
{
    public static class ShowMessage
    {
        private const string SuccessChangesMsg = "Внесені зміни збережено!";
        private const string ErrorChangesMsg = "Неможливо зберегти внесені зміни!";
        private const string DefaultTitleMsg = "Повідомлення";
        private const string ConfirmTitle = "Підтвердження";
        private const string SuccessTitle = "Успішно";
        private const string ErrorTitle = "Помилка";

        /// <summary>
        /// Show MessageBox Information type
        /// </summary>
        /// <param name="message">Текст повідомлення</param>
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, DefaultTitleMsg, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Show MessageBox Warning type
        /// </summary>
        /// <param name="message"></param>
        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, DefaultTitleMsg, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Show MessageBox Error type
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, ErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowError(Exception e)
        {
            RadMessageBox.Show(null, e.Message, "Server Exception", MessageBoxButtons.OK, RadMessageIcon.Error, MessageBoxDefaultButton.Button1, RightToLeft.Inherit, e.ToString());
        }

        /// <summary>
        /// Показати повідомлення після спроби зробити зміни.
        /// Успішно: "Внесені зміни збережено!"
        /// Не успішно: "Неможливо зберегти внесені зміни!"
        /// </summary>
        /// <param name="result">Результат обробки змін: true - зміни збережено, false - зміни не збережено</param>
        public static void ShowInfoAfterChanges(bool result)
        {
            if (result)
                MessageBox.Show(SuccessChangesMsg, SuccessTitle, MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(ErrorChangesMsg, ErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Show MessageBox Information type or Error type by result
        /// </summary>
        /// <param name="successMsg">Текст після успішо виконаних дій</param>
        /// <param name="errorMsg">Текст невдало виконаних дій</param>
        /// <param name="result">Результат обробки</param>
        public static void ShowInfoByResult(string successMsg, string errorMsg, bool result)
        {
            if (result)
                MessageBox.Show(successMsg, SuccessTitle, MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(errorMsg, ErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Показати повідомлення залежно від результату обробки
        /// </summary>
        /// <param name="message"></param>
        /// <param name="result">Результат обробки</param>
        public static void ShowInfoByResult(string message, bool result)
        {
            string caption = result ? SuccessTitle : ErrorTitle;
            MessageBoxImage icon = result ? MessageBoxImage.Information : MessageBoxImage.Error;

            MessageBox.Show(message, caption, MessageBoxButton.OK, icon);
        }

        /// <summary>
        /// Show Confirmation MessageBox and return choosed result as MessageBoxResult.Yes or MessageBoxResult.No
        /// </summary>
        /// <param name="message">Confirmation question"</param>
        /// <returns>MessageBoxResult.Yes | MessageBoxResult.No</returns>
        public static MessageBoxResult ConfirmAction(string message)
        {
            return MessageBox.Show(message, ConfirmTitle, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
        }

        /// <summary>
        /// Show Confirmation MessageBox and return choosed result as MessageBoxResult.Yes or MessageBoxResult.No
        /// </summary>
        /// <param name="message">Confirmation question"</param>
        /// <returns>MessageBoxResult.Yes | MessageBoxResult.No</returns>
        public static MessageBoxResult ConfirmWarningAction(string message)
        {
            return MessageBox.Show(message, ConfirmTitle, MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
        }
    }
}
