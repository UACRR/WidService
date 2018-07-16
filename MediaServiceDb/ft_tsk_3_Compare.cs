using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    /// <summary>
    /// Порівняння сток для пошуку 
    /// </summary>
    /// <param name="sors">Строка пошуку</param>
    /// <param name="dest">Строка в якій шукають</param>
    /// <param name="errorLevel">відсоток співпадання</param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean Ft_tsk_3_Compare(string sors, string dest, double errorLevel)
    {
        // Введите здесь код
        if (sors.CompareTo(dest) == 0)
            return true;
        // перевіряемо на повне співпадання
        int cntHit = 0;
        // перевіряемо з права на ліво кількість символів співпадуть 
        char[] sorsChars = sors.ToUpper().ToCharArray();
        char[] destChars = dest.ToUpper().ToCharArray();

        // перевіряємо з ліва на право кількість символів співпадуть
        int i = 0, lengSors = sorsChars.Length, j = 0, lengDest = destChars.Length;
        // по кожному символу
        for (; i < lengSors && j < lengDest; i++)
        {
            // виконуємо пошук в цілйовому масиві
            for (; j < lengDest; j++)
            {
                if (sorsChars[i] == destChars[j])
                {
                    cntHit++;
                    j++;
                    break;
                }
            }

        }

        if ((float)cntHit / lengSors >= errorLevel)
            return true;

        i = lengSors - 1;
        j = dest.Length - 1;
        cntHit = 0;
        // по кожному символу
        for (; i >= 0 && j >= 0; i--)
        {
            // виконуємо пошук в цілйовому масиві
            for (; j >= 0; j--)
            {
                if (sorsChars[i] == destChars[j])
                {
                    cntHit++;
                    j--;
                    break;
                }
            }
        }

        if ((float)cntHit / lengSors >= errorLevel)
            return true;

        return false;

    }



}
