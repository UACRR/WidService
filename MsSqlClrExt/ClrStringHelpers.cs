using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlClrExt
{
    public static class ClrStringHelpers
    {
        [SqlFunction(DataAccess = DataAccessKind.None)]
        public static int ClrCompareNormalized(string text1, string text2)
        {
            try
            {
                if(text1 == "" || text2 == "")
                {
                    return -1;
                }
                var curCharIdx1 = -1;
                var curCharIdx2 = -1;
                while (true)
                {
                    curCharIdx1 = GetNextAlphaNumeric(text1, curCharIdx1);
                    curCharIdx2 = GetNextAlphaNumeric(text2, curCharIdx2);
                    if (curCharIdx1 != -1 && curCharIdx2 != -1)
                    {
                        if (char.ToLower(text1[curCharIdx1]) != char.ToLower(text2[curCharIdx2]))
                        {
                            return -1; // виникла відмінність
                        }
                    }
                    else if (curCharIdx1 != -1 && curCharIdx2 == -1)
                    {
                        // порівнюється не просто входження на початку а повне речення на початку
                        if (curCharIdx1 > 0 && text1[curCharIdx1 - 1] == ' ')
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else if (curCharIdx1 == -1 && curCharIdx2 != -1)
                    {
                        if (curCharIdx2 > 0 && text2[curCharIdx2 - 1] == ' ')
                        {
                            return 2;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else if (curCharIdx1 == -1 && curCharIdx2 == -1)
                    {
                        return 0; // повне співпадіння
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error comparing [{text1}] and [{text2}] - {ex.Message} ");
            }  

            
        }
        private static int GetNextAlphaNumeric(string text, int curCharIdx)
        {
            for (int charIdx = curCharIdx + 1; charIdx < text.Length; charIdx++)
            {
                var curChar = text[charIdx];
                if (char.IsLetterOrDigit(curChar))
                {
                    return charIdx;
                }
            }
            return -1;
        }
    
        [SqlFunction(DataAccess = DataAccessKind.None)]
        public static string ClrGetName(string text)
        {
            var parts = text.Trim().Split(' ');
            if (parts.Length > 0)
                return parts[0].Trim();
            return "";
        }

        [SqlFunction(DataAccess = DataAccessKind.None)]
        public static string ClrGetFirstName(string text)
        {
            var parts = text.Trim().Split(' ');
            if (parts.Length > 1)
                return parts[1].Trim();
            return "";
        }

        [SqlFunction(DataAccess = DataAccessKind.None)]
        public static string ClrGetSurName(string text)
        {
            var parts = text.Trim().Split(' ');
            if (parts.Length > 2)
                return parts[2].Trim();
            return "";
        }
    }
}
