using System;
using System.Runtime.InteropServices;
using System.Security;
using Telerik.Windows.Controls;

namespace Launcher.Controls.LoginWindow
{
    public class LoginModel : ViewModelBase
    {
        private string ConvertPassword(SecureString pw)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(pw);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public int CodeI { get; set; }

        private string _userName = "";
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(() => _userName);
            }
        }

        /*
        private void OnPropertyChanged(Func<string> p)
        {
            throw new NotImplementedException();
        }
        */

        public SecureString Password { get; set; }
        public SecureString NewPassword { get; set; }
        public SecureString ConfirmPassword { get; set; }
        public string PlainPassword => ConvertPassword(Password);
        public string PlainNewPassword => ConvertPassword(NewPassword);
        public string PlainConfirmPassword => ConvertPassword(ConfirmPassword);
        public string AuthString => $"{UserName}:{PlainPassword}";
    }
}
