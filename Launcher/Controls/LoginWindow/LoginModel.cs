using System;
using System.Security;

namespace Launcher.Controls.LoginWindow
{
    public class LoginModel
    {
        //public Func<object, bool> IsValid { get; set; }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
            }
        }

        private SecureString _password;
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }
    }
}
