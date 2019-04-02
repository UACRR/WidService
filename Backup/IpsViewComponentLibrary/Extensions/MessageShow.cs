using System.Windows.Forms;

namespace IpsViewComponentLibrary.Extensions
{
    public static class MessageShow
    {
        private const string SuccessChangesMsg = "Внесені зміни збережено!";
        private const string ErrorChangesMsg = "Неможливо зберегти внесені зміни!";
        private const string DefaultTitleMsg = "Повідомлення";
        private const string ConfirmTitle = "Підтвердження";
        private const string SuccessTitle = "Успішно";
        private const string ErrorTitle = "Помилка";

        /// <summary>
        /// Показати [інформаційне] повідомлення
        /// </summary>
        /// <param name="message">Текст повідомлення</param>
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, DefaultTitleMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Показати повідомлення [попередження]
        /// </summary>
        /// <param name="message"></param>
        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, DefaultTitleMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Показати повідомлення [помилки]
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(SuccessChangesMsg, SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(ErrorChangesMsg, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Показати повідомлення залежно від результату обробки
        /// </summary>
        /// <param name="successMsg">Текст після успішо виконаних дій</param>
        /// <param name="errorMsg">Текст невдало виконаних дій</param>
        /// <param name="result">Результат обробки</param>
        public static void ShowInfoByResult(string successMsg, string errorMsg, bool result)
        {
            if (result)
                MessageBox.Show(successMsg, SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(errorMsg, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Показує повідомлення підтвердження дії та вертає DialogResult.Yes або DialogResult.No
        /// </summary>
        /// <param name="message">Текст запитання. Example: "Підтвердити дію?"</param>
        /// <returns>DialogResult.Yes || DialogResult.No</returns>
        public static DialogResult ConfirmAction(string message)
        {
            return MessageBox.Show(message, ConfirmTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
