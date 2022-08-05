using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PkAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class FkAttribute : Attribute
    {
        public string TableName { get; set; }
        public FkAttribute(string tableName)
        {
            TableName = tableName;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ImportValueAttribute : Attribute
    {
        public object Value { get; set; }
        public ImportValueAttribute(object value)
        {
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ImportCurrentAttribute : Attribute
    {
    }
}
