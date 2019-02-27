using System.Windows.Forms;

namespace IpsViewComponentLibrary.Extensions
{
    public static class MessageShow
    {
        private const string SuccessChangesMsg = "Внесені зміни збережено!";
        private const string ErrorChangesMsg = "Неможливо зберегти внесені зміни!";
        private const string DefaultTitleMsg = "Повідомлення";
        private const string SuccessTitle = "Успішно";
        private const string ErrorTitle = "Помилка";

        public static void ShowInfo(string msg)
        {
            MessageBox.Show(msg, DefaultTitleMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string msg)
        {
            MessageBox.Show(msg, DefaultTitleMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

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

        public static void ShowInfoByResult(string successMsg, string errorMsg, bool result)
        {
            if (result)
                MessageBox.Show(successMsg, SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(errorMsg, ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
