using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Data
{
    public static class IpsGlobal
    {
        public static event EventHandler DicChanged;
        static IpsGlobal()
        {
            Dic = null;
        }
        public static AnketaDictionaties Dic { get; private set; }
        public static void SetDic(AnketaDictionaties _dic)
        {
            Dic = _dic;
            DicChanged(null, EventArgs.Empty);
        }
    }
}
