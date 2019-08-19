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
    /// <param name="accuracy">відсоток співпадання</param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean Ft_tsk_3_Compare(string sors, string dest, float accuracy)
    {
        return Ft_tsk_3_Accurace(sors, dest, accuracy) >= accuracy;
    }

    /// <summary>
    /// Порівняння сток для пошуку 
    /// </summary>
    /// <param name="sors">Строка пошуку</param>
    /// <param name="dest">Строка в якій шукають</param>
    /// <param name="accuracy">відсоток співпадання</param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble Ft_tsk_3_Accurace(string sors, string dest, float accuracy)
    {
        if(string.IsNullOrWhiteSpace(sors) == true || string.IsNullOrWhiteSpace(dest) )
        return 0F;
        // Введите здесь код

        string sorsStr = sors.Trim();
        string destStr = dest.Trim();

        float result = 1F;
        if (sorsStr.CompareTo(destStr) == 0)
            return result;
        // перевіряемо на повне співпадання
        float cntHit = 0F;
        // перевіряемо з права на ліво кількість символів співпадуть 
        char[] sorsChars = sorsStr.Trim().ToUpper().ToCharArray();
        char[] destChars = destStr.Trim().ToUpper().ToCharArray();

        // перевіряємо з ліва на право кількість символів співпадуть
        int i = 0, lengSors = sorsChars.Length, j = 0, lengDest = destChars.Length;
        int diffLeng = Math.Abs( lengSors - lengDest );

        float delta = 0F;
        float precision = accuracy;
        // по кожному символу
        for (; i < lengSors && j < lengDest; i++)
        {
            // виконуємо пошук в цілйовому масиві
            for (; j < lengDest; j++)
            {
                // Співпало
                if (sorsChars[i] == destChars[j])
                {
                    cntHit+=1F;
                    // Повертаемо коефіціент 
                    precision = accuracy;
                    j++;
                    break;
                }
                // символ не на тому місці
                delta += precision;
                // Збільшуемо коефіціент при неспівпадання позицій символу
                precision *= 10;
            }
        }

        result = (float)cntHit / lengSors - delta - (0.001F* diffLeng);
        if (result >= accuracy)
            return result;

        i = lengSors - 1;
        j = destStr.Length - 1;
        cntHit = 0;
        delta = 0F;
        precision = accuracy;
        // по кожному символу
        for (; i >= 0 && j >= 0; i--)
        {
            // виконуємо пошук в цілйовому масиві
            for (; j >= 0; j--)
            {
                if (sorsChars[i] == destChars[j])
                {
                    cntHit+=1F;
                    precision = accuracy;
                    j--;
                    break;
                }
                delta += precision;
                precision *= 10;
            }
        }

        var lastResult = Math.Max( (float)cntHit / lengSors - delta - (0.001F * diffLeng), 0 );
        if (lastResult >= accuracy)
            return lastResult;

        return Math.Max(lastResult, result);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean FT_Like()
    {

    }
}
