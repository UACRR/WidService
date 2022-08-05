using System;
using System.Runtime.InteropServices;
using System.Security;
using Telerik.Windows.Controls;

namespace Launcher.Controls.LoginWindow
{
    public class UserModel : ViewModelBase
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

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                if (string.IsNullOrWhiteSpace(value))
                    IconChar = string.Empty;

                IconChar = $"{UserName[0]}".ToUpper();

                OnPropertyChanged(() => UserName);
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(() => Name);
            }
        }

        private string _userRole;
        public string UserRole
        {
            get => _userRole;
            set
            {
                _userRole = value;
                OnPropertyChanged(() => UserRole);
            }
        }

        private string _iconChar;
        public string IconChar
        {
            get => _iconChar;
            set
            {
                _iconChar = value;
                OnPropertyChanged(() => IconChar);
            }
        }

        
        public SecureString Password { get; set; }
        public SecureString NewPassword { get; set; }
        public SecureString ConfirmPassword { get; set; }
        public string PlainPassword => ConvertPassword(Password);
        public string PlainNewPassword => ConvertPassword(NewPassword);
        public string PlainConfirmPassword => ConvertPassword(ConfirmPassword);
        public string AuthString => $"{UserName}:{PlainPassword}";
    }
}
