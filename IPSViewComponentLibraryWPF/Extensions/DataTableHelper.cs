using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSViewComponentLibraryWPF.Extensions
{
    public class DataTableHelper
    {
        private Dictionary<string, int> Dictionary { get; set; }

        public DataTableHelper() { }

        public DataTableHelper(DataColumnCollection columns)
        {
            CreateColumnDictionary(columns);
        }

        public void CreateColumnDictionary(DataColumnCollection columns)
        {
            var temp = new Dictionary<string, int>();

            for (int i = 0; i < columns.Count; i++)
            {
                temp.Add(columns[i].ColumnName.ToLower(), i);
            }

            Dictionary = temp;

        }

        public object GetObject(object[] obj, string fieldName)
        {
            if (!Dictionary.ContainsKey(fieldName.ToLower()))
                return null;

            return obj[Dictionary[fieldName.ToLower()]];
        }
    }
}
