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
    /// Порівняння текстових рядків для пошуку (оригінал)
    /// </summary>
    /// <param name="sors">Строка пошуку</param>
    /// <param name="dest">Строка в якій шукають</param>
    /// <param name="accuracy">точність</param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble Ft_tsk_3_Accurace(string sors, string dest, float accuracy)
    {
        if (string.IsNullOrWhiteSpace(sors) || string.IsNullOrWhiteSpace(dest))
            return 0F;
        // Введите здесь код

        string sorsStr = sors.Trim().ToUpper();
        string destStr = dest.Trim().ToUpper();

        float result = 1F;
        if (string.Compare(sorsStr, destStr, StringComparison.OrdinalIgnoreCase) == 0)
            return result;

        // перевіряемо на повне співпадання
        float cntHit = 0F;
        // перевіряемо з права на ліво кількість символів співпадуть 
        char[] sorsChars = sorsStr.ToCharArray();
        char[] destChars = destStr.ToCharArray();

        // перевіряємо з ліва на право кількість символів співпадуть
        int i = 0, lengSors = sorsChars.Length, j = 0, lengDest = destChars.Length;
        int diffLeng = Math.Abs(lengSors - lengDest);

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
                    cntHit += 1F;
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

        result = cntHit / lengSors - delta - (0.001F * diffLeng);
        if (result >= accuracy)
            return result;

        i = sorsStr.Length - 1;
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
                    cntHit += 1F;
                    precision = accuracy;
                    j--;
                    break;
                }
                delta += precision;
                precision *= 10;
            }
        }

        var lastResult = Math.Max(cntHit / lengSors - delta - (0.001F * diffLeng), 0);
        if (lastResult >= accuracy)
            return lastResult;

        return Math.Max(lastResult, result);
    }

    /// <summary>
    /// Порівняння текстових рядків для пошуку 
    /// </summary>
    /// <param name="sors">Строка пошуку</param>
    /// <param name="dest">Строка в якій шукають</param>
    /// <param name="accuracy">точність</param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble Ft_tsk_3_Accurace_strong(string sors, string dest, float accuracy)
    {
        if (string.IsNullOrWhiteSpace(sors) || string.IsNullOrWhiteSpace(dest))
            return 0F;
        // Введите здесь код

        string sorsStr = sors.Trim().ToUpper();
        string destStr = dest.Trim().ToUpper();

        float result = 1F;
        if (string.Compare(sorsStr, destStr, StringComparison.OrdinalIgnoreCase) == 0)
            return result;

        // перевіряемо на повне співпадання
        float cntHit = 0F;
        // перевіряемо з права на ліво кількість символів співпадуть 
        char[] sorsChars = sorsStr.ToCharArray();
        char[] destChars = destStr.ToCharArray();

        // перевіряємо з ліва на право кількість символів співпадуть
        int i = 0;
        float lengthSors = sorsChars.Length;
        int j = 0;
        float lengthDest = destChars.Length;
        float diffLeng = Math.Abs(lengthSors - lengthDest);

        float lengthSorsWithoutWS = sorsStr.Replace(" ", "").Length;
        float lengthDestWithoutWS = destStr.Replace(" ", "").Length;

        // коефіцієнт співпадіння кількості символів
        float k = 1F;
        if (lengthSors < lengthDest)
        {
            k = ((lengthSors / lengthDest) + (lengthSorsWithoutWS / lengthDestWithoutWS)) / 2;
        }
        else if (lengthSors > lengthDest)
        {
            k = ((lengthDest / lengthSors) + (lengthDestWithoutWS / lengthSorsWithoutWS)) / 2;
        }

        float delta = 0F;
        float precision = accuracy;
        // по кожному символу
        for (; i < lengthSors && j < lengthDest; i++)
        {
            // виконуємо пошук в цілйовому масиві
            for (; j < lengthDest; j++)
            {
                // Співпало
                if (sorsChars[i] == destChars[j])
                {
                    cntHit += 1F;
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
        
        result = (cntHit / lengthSors- delta - (0.001F * diffLeng)) * k;
        if (result >= accuracy)
            return result;

        i = sorsStr.Length - 1;
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
                    cntHit += 1F;
                    precision = accuracy;
                    j--;
                    break;
                }
                delta += precision;
                precision *= 10;
            }
        }

        var lastResult = Math.Max((cntHit / lengthSors - delta - (0.001F * diffLeng)) * k, 0);
        if (lastResult >= accuracy)
            return lastResult;

        return Math.Max(lastResult, result);
    }

    /// <summary>
    /// Порівняння рядків для пошуку 
    /// </summary>
    /// <param name="sors">Рядок пошуку</param>
    /// <param name="dest">Рядок в якому шукають</param>
    /// <param name="accuracy">точність</param>
    /// <returns></returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble Ft_tsk_3_Accurace_p(string sors, string dest, float accuracy)
    {
        if (string.IsNullOrWhiteSpace(sors) || string.IsNullOrWhiteSpace(dest))
            return 0F;
        // Введите здесь код

        string sorsStr = sors.Trim().ToUpper();
        string destStr = dest.Trim().ToUpper();

        float result = 1F;
        if (string.Compare(sorsStr, destStr, StringComparison.OrdinalIgnoreCase) == 0)
            return result;

        // перевіряемо на повне співпадання
        float cntHit = 0F;
        // перевіряемо з права на ліво кількість символів співпадуть 
        char[] sorsChars = sorsStr.ToCharArray();
        char[] destChars = destStr.ToCharArray();

        // перевіряємо з ліва на право кількість символів співпадуть
        int i = 0;
        float lengthSors = sorsChars.Length;
        float lengthSorsWithoutWS = sorsStr.Replace(" ", "").Length;
        int j = 0;
        float lengthDest = destChars.Length;
        float lengthDestWithoutWS = destStr.Replace(" ", "").Length;

        float delta = 0F;
        float precision = accuracy;
        // по кожному символу
        for (; i < lengthSors && j < lengthDest; i++)
        {
            // виконуємо пошук в цілйовому масиві
            for (; j < lengthDest; j++)
            {
                // Співпало
                if (sorsChars[i] == destChars[j])
                {
                    cntHit += 1F;
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

        // коефіцієнт урізання точності співпадіння при різній довжині sors, dest
        float differenceFactorStrings = (float)Math.Pow((Math.Abs(lengthSors - lengthDest)) / (lengthSors + lengthDest), 2);

        // коефіцієнт співпадіння кількості символів
        float k = 1F;
        if (lengthSors < lengthDest)
        {
            k = ((lengthSors / lengthDest) + (lengthSorsWithoutWS / lengthDestWithoutWS)) / 2;
        }
        else if (lengthSors > lengthDest)
        {
            k = ((lengthDest / lengthSors) + (lengthDestWithoutWS / lengthSorsWithoutWS)) / 2;
        }
        
        result = (cntHit / lengthSors - delta - differenceFactorStrings) * k;
        if (result >= accuracy)
            return result;
        
        i = sorsStr.Length - 1;
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
                    cntHit += 1F;
                    precision = accuracy;
                    j--;
                    break;
                }
                delta += precision;
                precision *= 10;
            }
        }

        var lastResult = Math.Max((cntHit / lengthSors - delta - differenceFactorStrings) * k, 0);
        if (lastResult >= accuracy)
            return lastResult;

        return Math.Max(lastResult, result);
    }
}
