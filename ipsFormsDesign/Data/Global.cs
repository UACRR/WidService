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
    public class BindingField
    {
        public string SorsField { get; set; }
        public string DestField { get; set; }
    }
    public static class IpsGlobal
    {
        public static event EventHandler AnketaDictionatiesChanged;
        private static Dictionary<Type, IList<object>> AnketaDictionatiesProperties = new Dictionary<Type, IList<object>>();
        private static Dictionary<Type, BindingField[]> AnketaDictionatiesField = new Dictionary<Type, BindingField[]>();
        public static AnketaDictionaties AnketaDictionaties { get; private set; }
        public static ObjectRightDictionaries ObjectRightDictionaries { get; private set; }
        public static Dictionary<Type, object> Instances { get; private set; } = new Dictionary<Type, object>();

        // Додати екземпляр до довідника типів
        public static void addInstance( Type id, object instance )
        {
            if(Instances.Keys.Contains( id ))
            {
                Instances[id] = instance;
            }
            else
            {
                Instances.Add(id, instance);
            }
        }

        //  екземпляр до довідника типів
        public static void removeInstance( Type id )
        {
            if( Instances.Keys.Contains( id ))
            {
                Instances.Remove(id);
            }
        }


        static IpsGlobal()
        {
            AnketaDictionaties = null;
        }

        /// <summary>
        /// Ініціалізація даних для методу LinkToAnketaDictionaties: -- Звязуємо поля довідника з полями контрола --
        /// </summary>
        /// <returns></returns>
        private static async Task setAnketaDicFieldsAsync()
        {
            await Task.Run(() =>
            {
                // По замовчуваню
                AnketaDictionatiesField.Add(typeof(object), new[] { new BindingField { SorsField = "CodeI", DestField = "ValueMember" }, new BindingField { SorsField = "Name", DestField = "DisplayMember" } });
                // Country t = new Country();
                AnketaDictionatiesField.Add(typeof(Country), new[] { new BindingField { SorsField = "CountryCode" , DestField = "ValueMember" }, new BindingField { SorsField = "CountryNameShort", DestField = "DisplayMember" } });
            });
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
                if (piType.IsGenericType && piType.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    Type ProperyType = piType.GetGenericArguments()[0];
                    var Value = item.GetValue(AnketaDictionaties) as IList<object>;
                    AnketaDictionatiesProperties.Add(ProperyType, Value);
                }
            }
        }

        /// <summary>
        /// Змінити довідники
        /// </summary>
        /// <param name="_dic"></param>
        public static void SetAnketaDictionaties(AnketaDictionaties _dic)
        {
            AnketaDictionaties = _dic;
            setAnketaDictProperties();
            AnketaDictionatiesChanged?.Invoke(null, EventArgs.Empty);
        }

        public static void SetObjectRightDictionaries(ObjectRightDictionaries dictionaries)
        {
            ObjectRightDictionaries = dictionaries;
            //setAnketaDictProperties();
            //AnketaDictionatiesChanged(null, EventArgs.Empty);
        }


        /// <summary>
        /// -- Звязуємо поля довідника з полями контрола --
        /// </summary>
        /// <param name="typeDic">Тип довідника</param>
        /// <param name="control">Об'єкт, який треба прив'язати</param>
        public static void LinkToAnketaDictionaties(Type typeDic, Control control)
        {

            if (AnketaDictionaties == null)
                return;

            if (!AnketaDictionatiesProperties.Keys.Contains(typeDic)) return;
            var controlProperties = control.GetType().GetProperties().ToDictionary(rec => rec.Name);


            if (AnketaDictionatiesField.Keys.Count() == 0)
            {
                var tsk = Task.Run(() => setAnketaDicFieldsAsync());
                tsk.Wait();
            }

            var fields = AnketaDictionatiesField.Keys.Contains(typeDic) ? AnketaDictionatiesField[typeDic] : AnketaDictionatiesField[typeof(object)];
            Action[] setter = new Action[fields.Count()];

            // Формуємо метод рив'зки 
            for (int i = 0, cnt = setter.Count(); i < cnt; i++)
            {
                if (!controlProperties.Keys.Contains(fields[i].DestField ))
                    return;

                var curI = i;
                setter[i] = () => { var index = curI; controlProperties[fields[index].DestField].SetValue(control, fields[index].SorsField ); };
            }
            // Прив'язно
            for (int i = 0, cnt = setter.Count(); i < cnt; i++)
                setter[i]();

        }

    }
}