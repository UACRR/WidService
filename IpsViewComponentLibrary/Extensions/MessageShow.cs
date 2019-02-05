using System.Windows.Forms;

namespace IpsViewComponentLibrary.Extensions
{
    public static class MessageShow
    {
        private const string DefaultTitleMsg = "Повідомлення";
        private const string SuccessTitle = "Успішно";
        private const string ErrorTitle = "Помилка";

        public static void ShowInfo(string msg)
        {
            MessageBox.Show(msg, DefaultTitleMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
