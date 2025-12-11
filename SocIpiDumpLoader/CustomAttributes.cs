using System;
using System.Collections.Generic;
using System.Text;

namespace SocIpiDumpLoader
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomPosInFileAttribute : Attribute
    {
        private int _start;
        public int Start { get { return _start; } }

        private int _size;
        public int Size { get { return _size; } }

        public CustomPosInFileAttribute(int start, int size)
        {
            _start = start;
            _size = size;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CustomTargetWidEntityAttribute : Attribute
    {
        private string _name;
        public string Name { get { return _name; } }

        public CustomTargetWidEntityAttribute(string name)
        {
            _name = name;
        }
    }

    /*
     * UpdateMethod = "I" - match by all fields is applied, if not found record is inserted
     * UpdateMethod = "IU" - match by fields with ForMatch attributes applied, if not found record is inserted, if found record is updated
     * UpdateMethod = "U" - match by fields with ForMatch attributes applied, if found record is updated
     * UpdateMethod = "R" - complete replacement, applied for all records of this type, all records for Wic in target table are deleted, and new are inserted per record from update
     * UpdateMethod = "C" - custom implementation
     * */
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomUpdateMethodAttribute : Attribute
    {
        private string _updateMethod;
        public string UpdateMethod { get { return _updateMethod; } }

        public CustomUpdateMethodAttribute(string updateMethod)
        {
            _updateMethod = updateMethod;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CustomFileTimeColAttribute : Attribute
    {
        private string _fileTimeCol;
        public string FileTimeCol { get { return _fileTimeCol; } }

        public CustomFileTimeColAttribute(string fileTimeCol)
        {
            _fileTimeCol = fileTimeCol;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CustomIsTranAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CustomVrExrpIndVAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CustomVrExrpIndEAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CustomForMatchAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CustomForUpdateAttribute : Attribute
    {
    }
}
