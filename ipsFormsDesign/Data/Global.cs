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
        public static AnketaDictionaties AnketaDictionaties { get; private set; }
        public static ObjectRightDictionaries ObjectRightDictionaries { get; private set; }
        public static List<FrameTask> FrameTaskDictionary { get; private set; }

        public static CurrentClient CurrentClient { get; } = new CurrentClient();

        public static Dictionary<Type, object> Instances { get; private set; } = new Dictionary<Type, object>();

        public static Dictionary<string, object> Properties { get; private set; } = new Dictionary<string, object>();

        public static object GetProperty(string name)
        {
            if (Properties.Keys.Contains(name))
                return Properties[name];

            return null;
        }

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


        /// <summary>
        /// Змінити довідники
        /// </summary>
        /// <param name="dictionaties"></param>
        public static void SetAnketaDictionaties(AnketaDictionaties dictionaties)
        {
            AnketaDictionaties = dictionaties;
        }

        public static void SetObjectRightDictionaries(ObjectRightDictionaries dictionaries)
        {
            ObjectRightDictionaries = dictionaries;
        }

        public static void SetFrameTaskDictionary(List<FrameTask> frameTaskDictionary)
        {
            FrameTaskDictionary = frameTaskDictionary;
        }
    }
}