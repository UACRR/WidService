using SmRoPermitCommonLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmRoPermitClientLib
{
    public static class PermitClient
    {
        public static string Login(string baseUri, string[] loginParams)
        {
            int codeI;
            string login;
            string password;

            if (loginParams.Length > 0)
            {
                codeI = int.Parse(Crypt.DecryptString(loginParams[0]));
                login = loginParams[1];
                password = loginParams[2];
            }
            else
            {
                PermitApiProxy.BaseUri = baseUri;
                FormLogin formLogin = new FormLogin();
                if (formLogin.ShowDialog() != DialogResult.OK)
                    throw new Exception("LOGIN_CANCELLED");
                codeI = formLogin.CodeI;
                login = formLogin.Login;
                password = formLogin.Password;
            }

            UserPermissions.Load(baseUri, codeI);

            return $"{login}:{password}";
        }
    }
}
