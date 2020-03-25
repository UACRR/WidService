using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using SmRoPermitCommonLib;

namespace SmRoPermitClientLib
{
    public class UserPermissions
    {
        private static Dictionary<string, UserPermission> Permissions { get; set; }

        public static void Load(string baseUri, int userCodeI)
        {
            Permissions = new Dictionary<string, UserPermission>();
            PermitApiProxy.BaseUri = baseUri;
            foreach (var perm in PermitApiProxy.GetUserPermissions(userCodeI))
            {
                Permissions.Add(perm.FuncCode, perm);
            }
        }

        public static void ImposeRestrictions(Control control)
        {
            if (!string.IsNullOrEmpty(control.AccessibleDescription))
            {
                PropertyInfo pi = control.GetType().GetProperty("ReadOnly");
                if (pi != null)
                {
                    pi.SetValue(control, true);
                }
                else
                {
                    control.Enabled = false;
                }
            }
            foreach (Control ctrl in control.Controls)
            {
                ImposeRestrictions(ctrl);
            }
        }

        public static void ImposeRestrictions(Form form)
        {
            if(!string.IsNullOrEmpty(form.AccessibleDescription))
            {
                string accessToken = form.AccessibleDescription;
                if(!Permissions.ContainsKey(accessToken))
                {
                    form.Text = "Access is denied";
                    foreach(Control ctrl in form.Controls)
                    {
                        ctrl.Enabled = false;
                    }
                }
                else if(!Permissions[accessToken].IsWrite)
                {
                    form.Text += " (read only)";
                    foreach (Control ctrl in form.Controls)
                    {
                        ImposeRestrictions(ctrl);
                    }
                } 
            }
        }

        public static void ImposeRestrictions(System.Windows.Window window)
        {
            PropertyInfo pi = window.GetType().GetProperty("AccessToken");
            var accessToken = (string) pi?.GetValue(window);
            if (!string.IsNullOrEmpty(accessToken))
            {
                if (!Permissions.ContainsKey(accessToken))
                {
                    //window.Title = "Access is denied";
                    //foreach (Control ctrl in window.Content)
                    //{
                    //    ctrl.Enabled = false;
                    //}
                }
                else if (!Permissions[accessToken].IsWrite)
                {
                    window.Title += " (read only)";
                    //foreach (Control ctrl in window.Controls)
                    //{
                    //    ImposeRestrictions(ctrl);
                    //}
                }
            }
        }

        public static bool CanRead(string funcName)
        {
            if (!Permissions.ContainsKey(funcName))
            {
                return false;
            }
            else
            {
                return Permissions[funcName].IsRead;
            }
        }

        public static bool CanWrite(string funcName)
        {
            if (!Permissions.ContainsKey(funcName))
            {
                return false;
            }
            else
            {
                return Permissions[funcName].IsWrite;
            }
        }
    }
}
