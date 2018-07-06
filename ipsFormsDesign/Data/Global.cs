using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ipsFormsDesign.Data
{
    public static class IpsGlobal
    {
        public static event EventHandler AnketaDictionatiesChanged;
        private static Dictionary<Type, IList<object>> AnketaDictionatiesProperties = new Dictionary<Type, IList<object>>();
        private static Dictionary<Type, string[]> AnketaDictionatiesField = new Dictionary<Type, string[]>();
        public static AnketaDictionaties AnketaDictionaties { get; private set; }


        static IpsGlobal()
        {
            AnketaDictionaties = null;
            AnketaDictionatiesField.Add(null, new[] { "CodeI", "Name" });
//            Country t = new Country();
            AnketaDictionatiesField.Add(typeof(Country), new[] { "CountryCode", "CountryNameShort" });


        }

        /// <summary>
        /// 
        /// </summary>
        private static void setAnketaDictProperties()
        {
            AnketaDictionatiesProperties.Clear();
            foreach (var item in AnketaDictionaties.GetType().GetProperties())
            {
                Type piType = item.PropertyType;
                if(piType.IsGenericType && piType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type ProperyType = piType.GetGenericArguments()[0];
                    var Value = item.GetValue(AnketaDictionaties) as IList<object>;
                    AnketaDictionatiesProperties.Add(ProperyType, Value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_dic"></param>
        public static void SetAnketaDictionaties(AnketaDictionaties _dic)
        {
            AnketaDictionaties = _dic;
            setAnketaDictProperties();
            AnketaDictionatiesChanged(null, EventArgs.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeDic"></param>
        /// <param name="control"></param>
        public static void LinkToAnketaDictionaties(Type typeDic, Control control)
        {
            if (AnketaDictionaties == null)
                return;
            if (!AnketaDictionatiesProperties.Keys.Contains(typeDic)) return;
            var controlProperties = control.GetType().GetProperties().ToDictionary(rec => rec.Name);
            var fields = AnketaDictionatiesField.Keys.Contains(typeDic) ? AnketaDictionatiesField[typeDic] : AnketaDictionatiesField[null];
            Action[] setter = new Action[fields.Count()];

            for( int i = 0, cnt = setter.Count(); i < cnt; i++ )
            {
                if (!controlProperties.Keys.Contains(fields[i]))
                    return;
                setter[i] = () => { var index = i; controlProperties[fields[index]].SetValue(control, fields[index]); };
            }

            for (int i = 0, cnt = setter.Count(); i < cnt; i++)
                setter[i]();

        }

    }
}