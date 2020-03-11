using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using IpsCommonTypes.Enums;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Model;

namespace ipsmedserviceapp.Extensions
{
    public static class SearchQueryHelper
    {
        private const string union = " UNION ";

        private const string CreateTable = "CREATE TABLE #tmpResult (id integer null)";
        private const string DeclareTableParameter = "DECLARE @tParam SeekParamType";
        private const string InsertIntoParamTable = "INSERT INTO @tParam (FrameCode, seekCode, seekValue, isLike, isEqual, isContains)";
        private const string ReInsertTmpTable0 = "DELETE #tmpResult " +
                                                "insert into #tmpResult (id) " +
                                                "exec p_Tsk3_SeekParam @tParam, 0";
        private const string ReInsertTmpTable1 = "DELETE #tmpResult " +
                                                 "insert into #tmpResult (id) " +
                                                 "exec p_Tsk3_SeekParam @tParam, 1";

        public static string CreateSearchQuery(string entryQuery, List<FrameParam> frameParam, SearchData searchData, out SqlParameter parameters)
        {
            int frameCode = frameParam.First().FrameCode ?? throw new ArgumentOutOfRangeException();
            string seekOut = frameParam.First().SeekOut;

            int[] searchType = {
                searchData.MatchTextOfSearch == MatchTextOfSearch.Like ? 1 : 0,
                searchData.MatchTextOfSearch == MatchTextOfSearch.Equal ? 1 : 0,
                searchData.MatchTextOfSearch == MatchTextOfSearch.Contains ? 1 : 0
            };

            var selectList = new List<string>();
            foreach (var param in searchData.SearchParametersValue)
            {
                int seekCode = frameParam.Single(rec => rec.SeekCodeName == param).SeekCode;
                string select = $"select {frameCode}, {seekCode}, @seekValue, {searchType[0]}, {searchType[1]}, {searchType[2]}";
                selectList.Add(select);
            }

            parameters = new SqlParameter("@seekValue", ValidateSearchText(searchData.SearchText));

            string insertQuery = string.Join(union, selectList);

            string query = $"{CreateTable} {DeclareTableParameter} {InsertIntoParamTable} {insertQuery} {ReInsertTmpTable0} ";
            entryQuery = query + entryQuery + $" JOIN #tmpResult t2 on t2.id = t0.{seekOut}";
            return entryQuery;
        }

        public static string CreateSearchQuery(string entryQuery, List<FrameParam> frameParam, List<SearchDataExtended> searchDataExtended, out List<SqlParameter> parameters)
        {
            parameters = new List<SqlParameter>();
            
            int frameCode = frameParam.First().FrameCode ?? throw new ArgumentOutOfRangeException();
            string seekOut = frameParam.First().SeekOut;

            var selectList = new List<string>();

            foreach (var searchData in searchDataExtended)
            {
                int[] searchType = {
                    searchData.MatchTextOfSearch == MatchTextOfSearch.Like ? 1 : 0,
                    searchData.MatchTextOfSearch == MatchTextOfSearch.Equal ? 1 : 0,
                    searchData.MatchTextOfSearch == MatchTextOfSearch.Contains ? 1 : 0
                };

                int indx = searchDataExtended.IndexOf(searchData);
                string variableName = $"@seekValue{indx}";

                int seekCode = frameParam.Single(rec => rec.SeekCodeName == searchData.SearchParameterValue).SeekCode;
                string select = $"select {frameCode}, {seekCode}, {variableName}, {searchType[0]}, {searchType[1]}, {searchType[2]}";
                selectList.Add(select);

                parameters.Add(new SqlParameter(variableName, ValidateSearchText(searchData.SearchText)));
            }

            string insertQuery = string.Join(union, selectList);

            string query = $"{CreateTable} {DeclareTableParameter} {InsertIntoParamTable} {insertQuery} {ReInsertTmpTable1} ";
            entryQuery = query + entryQuery + $" JOIN #tmpResult t2 on t2.id = t0.{seekOut}";
            return entryQuery;
        }

        private static string ValidateSearchText(string searchText)
        {
            searchText = searchText.Replace("'", "''");
            searchText = searchText.Replace("ь", "Ь");

            return searchText;
        }
    }
}
