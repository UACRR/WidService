using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ipsmedserviceapp.Utilities
{
    public static class DBQueryHelper
    {
        private const string And = " and ";
        private const string Or = " or ";

        private static string StrongNormalizeString(string s)
        {
            return s.Replace("'", "''");
        }

        public static string ApplySqlWhereCondition(string queryText, Dictionary<string, string> conditionDictionary)
        {
            if (!conditionDictionary.Any())
                return queryText;

            var conditions = new Collection<string>();

            foreach (var condition in conditionDictionary)
                conditions.Add($"{condition.Key} like \'%{StrongNormalizeString(condition.Value)}%\'");
            
            if (conditions.Any())
                queryText += $" where {string.Join(" and ", conditions)}";
            
            return queryText;
        }

        public static string ApplySqlWhereEqualCondition(string queryText, Dictionary<string, string> conditionDictionary)
        {
            if (!conditionDictionary.Any())
                return queryText;

            var conditions = new Collection<string>();

            foreach (var condition in conditionDictionary)
                conditions.Add($"{condition.Key} = \'{StrongNormalizeString(condition.Value)}\'");

            queryText += $" where {string.Join(" and ", conditions)}";

            return queryText;
        }

        public static string ApplySqlWhereInCondition<T>(string queryText, string parameterName, ICollection<T> valueCollection)
        {
            if (valueCollection.Count == 0)
                return queryText;

            var paramStrings = valueCollection.ToArray().Select(item => $"'{item}'").ToArray();

            queryText += $" where {parameterName} in ({string.Join(", ", paramStrings)})";
            
            return queryText;
        }

        public static string ApplySqlWhereInCondition(string queryText, string parameterName, string stringValues)
        {
            if (string.IsNullOrWhiteSpace(stringValues))
                return queryText;

            queryText += $" where {parameterName} in ({stringValues})";

            return queryText;
        }

        public static string ApplySqlWhereContainsCondition(string queryText, Dictionary<string[], string> conditionDictionary)
        {
            if (!conditionDictionary.Any())
                return queryText;

            var containsList = new List<string>();
            foreach (var item in conditionDictionary)
            {
                containsList.Add($"contains(({string.Join(", ", item.Key)}), '\"{StrongNormalizeString(item.Value)}\"')");    
            }

            queryText += $" where {string.Join(" and ", containsList)}";

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

        /// <summary>
        /// Apply ORDER BY sort and paging to SQL query by skip/take
        /// </summary>
        /// <param name="queryText"></param>
        /// <param name="orderByField"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static string ApplySqlOrderByAndPaging(string queryText, string orderByField, int skip, int take)
        {
            if (string.IsNullOrWhiteSpace(orderByField))
                return queryText;

            queryText += $" ORDER BY {orderByField} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY";
            return queryText;
        }
    }
}
