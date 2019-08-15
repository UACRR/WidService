using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Utilities
{
    public static class DBQueryHelper
    {
        public static string ApplySqlWhereCondition(string queryText, Dictionary<string, string> conditionDictionary)
        {
            if (!conditionDictionary.Any())
                return queryText;

            var conditions = new Collection<string>();

            foreach (var condition in conditionDictionary)
                conditions.Add($"{condition.Key} like \'%{condition.Value}%\'");
            
            if (conditions.Any())
                queryText = $"{queryText} where {string.Join(" and ", conditions)}";
            
            return queryText;
        }

        public static string ApplySqlWhereInCondition<T>(string queryText, string parameterName, ICollection<T> valueCollection)
        {
            if (valueCollection.Count == 0)
                return queryText;

            queryText = $"{queryText} where {parameterName} in ({string.Join(", ", valueCollection.ToArray())})";
            
            return queryText;
        }

        /// <summary>
        /// Apply ORDER BY sort and paging to SQL query by arguments
        /// </summary>
        /// <param name="queryText">query string</param>
        /// <param name="orderByField">ORDER BY field</param>
        /// <param name="page">customer current page (query will show all records if null)</param>
        /// <param name="pageSize">customer count record on page (query will show all records if null)</param>
        /// <returns>complete query string</returns>
        public static string ApplySqlOrderByAndPaging(string queryText, string orderByField, int? page, int? pageSize)
        {
            if (string.IsNullOrWhiteSpace(orderByField))
                return queryText;

            if (page == null || pageSize == null)
            {
                queryText += $" ORDER BY {orderByField}";
                return queryText;
            }

            if (page <= 0)
                page = 1;

            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException($"Argument {nameof(pageSize)} must be more than 0!");

            queryText += $" ORDER BY {orderByField} OFFSET {(page - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return queryText;
        }
    }
}
