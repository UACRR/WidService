using System;

namespace IPSViewComponentLibraryWPF.Extensions
{
    public static class DataTableConverter
    {
        public static T Cast<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(T);
            
            return (T)obj;
        }

        public static int CastInt(object obj)
        {
            if (obj == null)
                return default(int);

            return (int)(long)obj;
        }

        public static int? CastIntNull(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(int?);

            return (int?)(long?)obj;
        }

        public static Single CastFloat(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(Single);

            return (float) (double) obj;
        }

        public static Single CastAsFloat(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(Single);

            var dObj = (double?) obj;
            
            return (float) dObj.Value;
        }

        public static Single? CastFloatNull(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(Single?);

            return (float?)(double?)obj;
        }

        public static Byte CastByte(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(Byte);

            return (Byte) (long) obj;
        }

        public static Byte CastAsByte(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(Byte);

            var lObj = (long?) obj;

            return (Byte)lObj.Value;
        }

        public static short CastShort(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(short);
            
            return (short) (long) obj;
        }

        public static short? CastShortNull(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(short?);

            return (short?)(long?)obj;
        }
    }
}