using LanguageLibrary;
using LanguageLibrary.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SmRoPermitAdmin
{
    public class Translator
    {
        public static Dictionary<string, string> Txt;
        /*public static Dictionary<string, string> Txt = new Dictionary<string, string>()
            {
                { "ERR", "Помилка"},
                { "INFO", "Інформація"},
                { "WARN", "Попередження"},
                { "QUEST", "Питання"},
                { "CONF_SAVE", "Були внесені зміни. Збережіть або відмініть."},
                { "NEW_USER", "Новій користувач"},
                { "DEL_USER", "Відалити користувача?"},
                { "CANNOT_DELETE_SELF", "Не можна видалити себе самого"},
                { "PROVIDE_USER_LOGIN", "Потрібно вказати логін користувача"},
                { "CANNOT_CHANGE_LOGIN", "Не можна змінити свій власний логін"},
                { "CANNOT_BLOCK_LOGIN", "Не можна заблокувати свій власний логін"},
                { "DEF_PWD_CREATED", "Випадковий пароль створено і розміщено в буфері обміну."},
                { "PLEASE_PASTE", "Втавте його в наійне місце для подальшого використання. Текст паролю знаходитьсяч всередині лапок (')."},
                { "UNSAVED_CHANGES", "Були внесені зміни. Збережіть або відмініть."},
                { "CANNOT_CHANGE_PERM", "Не можна змінити власні права доступу"},
                { "CANNOT_CHANGE_PWD", "Не можна змінити свій власний пароль"},
                { "CONFIRM_PWD_RESET", "Пароль буде змінено. Півдтвердіть, будь ласка."},
                { "USER_LIST", "Користувачі"},
                { "ADMIN_CONSOLE", "Адміністрування користувачів"},
                { "ADD", "Додати"},
                { "DELETE", "Видалити"},
                { "RESET_PWD", "Оновити пароль"},
                { "LOGIN", "Логін"},
                { "FIRST_NAME", "Ім'я"},
                { "SURNAME", "По-батькові"},
                { "LAST_NAME", "Прізвище"},
                { "SAVE", "Зберегти"},
                { "CANCEL", "Відмінити"},
                { "CODE", "Код"},
                { "ROLE", "Роль"},
                { "CAN_READ", "Може читати"},
                { "CAN_WRITE", "Може редагувати"},
                { "SYS_INFO", "Системна інформація"},
                { "MODIFIED_ON", "Час зміни:"},
                { "CODE_LAB", "Код:"},
                { "CREATED_ON", "Час створення:"},
                { "USER_ACCOUNT", "Обліковий запис"},
                { "BLOCKED", "Заблоковано"},
                { "LOGIN_LAB", "Логін:"},
                { "PASSWORD_LAB", "Пароль:"},
                { "PERSONAL_DATA", "Персональні дані"},
                { "FIRST_NAME_LAB", "Ім'я:"},
                { "SURNAME_LAB", "По-батькові:"},
                { "LAST_NAME_LAB", "Прізвище:"},
                { "EMAIL_LAB", "E-Mail:"},
                { "COMMENT_LAB", "Коментар:"},
                { "PHONE_LAB", "Телефон:"},
                { "CLOSE", "Вийти"},
                { "PERMIT", "Дозволи"},
                { "WILL_TERMINATE", ", програма буде завершена"},
                { "LOGIN_CANCELLED", "Користувач відмінив спробу зайти в систему"},
                { "LOGIN_NOT_UNIQUE", "Логін вже використовується, будь ласка, введіть інший логін"},
           };
           */

        /*
    public static Dictionary<string, string> Txt = new Dictionary<string, string>()
    {
        { "ERR", "Error"},
        { "INFO", "Information"},
        { "WARN", "Warning"},
        { "QUEST", "Question"},
        { "CONF_SAVE", "There are unsaved changes. Please, save or cancel."},
        { "NEW_USER", "New User"},
        { "DEL_USER", "Delete User?"},
        { "CANNOT_DELETE_SELF", "Cannot delete yourself"},
        { "PROVIDE_USER_LOGIN", "Please, provide user login"},
        { "CANNOT_CHANGE_LOGIN", "Cannot change your own login"},
        { "CANNOT_BLOCK_LOGIN", "Cannot block your own login"},
        { "DEF_PWD_CREATED", "Default password is created and placed into clipbord."},
        { "PLEASE_PASTE", "Please, paste it into some secure place to inform the user later on. The password is enclosed into single quates."},
        { "UNSAVED_CHANGES", "There are unsaved changes. Please, save or cancel."},
        { "CANNOT_CHANGE_PERM", "Cannot change your own permissions"},
        { "CANNOT_CHANGE_PWD", "Cannot reset your own password"},
        { "CONFIRM_PWD_RESET", "User password is about to be reset. Please, confirm."},
        { "USER_LIST", "User List"},
        { "ADMIN_CONSOLE", "User Admin Console"},
        { "ADD", "Add"},
        { "DELETE", "Delete"},
        { "RESET_PWD", "Reset Password"},
        { "LOGIN", "Login"},
        { "FIRST_NAME", "First Name"},
        { "SURNAME", "Surname"},
        { "LAST_NAME", "Last Name"},
        { "SAVE", "Save"},
        { "CANCEL", "Cancel"},
        { "CODE", "Code"},
        { "ROLE", "Role"},
        { "CAN_READ", "Can Read"},
        { "CAN_WRITE", "Can Write"},
        { "SYS_INFO", "System Information"},
        { "MODIFIED_ON", "Modified On:"},
        { "CODE_LAB", "Code:"},
        { "CREATED_ON", "Created On:"},
        { "USER_ACCOUNT", "User Account"},
        { "BLOCKED", "Blocked"},
        { "LOGIN_LAB", "Login:"},
        { "PASSWORD_LAB", "Password:"},
        { "PERSONAL_DATA", "Personal Data"},
        { "FIRST_NAME_LAB", "First Name:"},
        { "SURNAME_LAB", "Surname:"},
        { "LAST_NAME_LAB", "Last Name:"},
        { "EMAIL_LAB", "E-Mail:"},
        { "COMMENT_LAB", "Comment:"},
        { "PHONE_LAB", "Phone:"},
        { "CLOSE", "Close"},
        { "PERMIT", "Permissions"},
        { "WILL_TERMINATE", ", application will be terminated"},
        { "LOGIN_CANCELLED", "Login attempt was canceled by user"},
        { "LOGIN_NOT_UNIQUE", "Login is already used, please, provide another login"},
   };*/


        public static void Load()
        {
            //AppLanguageLibrary.ChangeCurrentCulture(new CultureInfo("uk-UA"));

            Txt = new Dictionary<string, string>();

            Type type = AppLanguageLibrary.CurrentLanguage.SmRoPermitLD.GetType();
            foreach(var prop in type.GetProperties())
            {
                LanguageItem li = (LanguageItem)prop.GetValue(AppLanguageLibrary.CurrentLanguage.SmRoPermitLD);
                Txt[prop.Name] = string.IsNullOrEmpty(li.Content) ? prop.Name : li.Content;
            }
        }

        public static Dictionary<string, string> GetDict()
        {
            if (Txt == null)
                Load();
            return Txt;
        }

        public static string GetText(string code)
        {
            return Txt[code];
        }

        public static void Translate(Control control)
        {
            if (!string.IsNullOrEmpty(control.Text))
            {
                control.Text = GetText(control.Text);
            }
            Type type = control.GetType();
            if (type.Name == "RadCollapsiblePanel")
            {
                var panel = control as Telerik.WinControls.UI.RadCollapsiblePanel;
                panel.HeaderText = GetText(panel.HeaderText);
            }
            else if (type.Name == "RadGridView")
            {
                var panel = control as Telerik.WinControls.UI.RadGridView;
                foreach(var col in panel.Columns)
                    col.HeaderText = GetText(col.HeaderText);
            }
            foreach (Control ctrl in control.Controls)
            {
                Translate(ctrl);
            }
        }

        public static void Transalate(Form form)
        {
            if (!string.IsNullOrEmpty(form.Text))
            {
                form.Text = GetText(form.Text);
            }
            foreach (Control ctrl in form.Controls)
            {
                Translate(ctrl);
            }
        }
    }
}
