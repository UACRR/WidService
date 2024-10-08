using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WidTestConsole
{
    public class MsMwSearch : MwSearchBase
    {
        public MsMwSearch(string connectionString) : base(connectionString)
        {
        }
        public override List<TitleAuthorsPerformersAggr> SearchTitleAuthorsPerformers()
        {
            var retVal = new List<TitleAuthorsPerformersAggr>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = "drop table if exists #ObjIds\r\n" +
                        "create table #ObjIds(ObjId int)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = GetCreateObjIdsSql();
                    FillParameters(cmd);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "select * from #ObjIds";
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var objId = r.GetInt32(0);
                        }
                    }



                    SelectTitles(cmd);
                    SelectAuthors(cmd);
                    SelectPerformers(cmd);

                    _titleAuthorsPerformers.Values.ToList().ForEach(x =>
                    {
                        retVal.Add(new TitleAuthorsPerformersAggr
                        {
                            ObjId = x.ObjId,
                            Title = x.Title,
                            Authors = string.Join(" | ", x.Authors.OrderBy(y => y)),
                            Performers = string.Join(" | ", x.Performers.OrderBy(y => y)),
                        });
                    });

                    cmd.CommandText = "drop table #ObjIds";
                    cmd.ExecuteNonQuery();
                }
            }
                return retVal.OrderBy(x => x.Title).ToList();
        }

        private void SelectTitles(SqlCommand cmd)
        {
            cmd.CommandText = "select t1.ObjId, t2.name\r\n" +
                "from #ObjIds t1\r\n" +
                "    join ObjectRight t2 on t1.ObjId = t2.ObjId";
            cmd.Parameters.Clear();
            using (var r = cmd.ExecuteReader())
            {
                _titleAuthorsPerformers = new Dictionary<int, TitleAuthorsPerformersEntry>();
                while (r.Read())
                {
                    _titleAuthorsPerformers.Add(r.GetInt32(0), new TitleAuthorsPerformersEntry
                    {
                        ObjId = r.GetInt32(0),
                        Title = r.GetString(1),
                        Authors = new List<string>(),
                        Performers = new List<string>(),
                    });
                }
            };
        }

        private void SelectAuthors(SqlCommand cmd)
        {
            cmd.CommandText = "select t1.ObjId, isnull(t2.author, '')\r\n" +
                "from #ObjIds t1\r\n" +
                "    join ObjectRight t2 on t1.ObjId = t2.ObjId\r\n";
            cmd.Parameters.Clear();
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    _titleAuthorsPerformers[r.GetInt32(0)].Authors.Add(r.GetString(1));
                }
            };
        }

        private void SelectPerformers(SqlCommand cmd)
        {
            cmd.CommandText = "select t1.ObjId, isnull(t2.Performer, '')\r\n" +
                "from #ObjIds t1\r\n" +
                "    join ObjectRight t2 on t1.ObjId = t2.ObjId\r\n";
            cmd.Parameters.Clear();
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    _titleAuthorsPerformers[r.GetInt32(0)].Performers.Add(r.GetString(1));
                }
            };
        }

        private string GetCreateObjIdsSql()
        {
            var retVal = 
                "insert #ObjIds (ObjId)\r\n" +
                "select distinct top 1000 t1.ObjId\r\n" +
                $"from {GetFromExpr()}\r\n" +
                $"where {GetSearcExpression(false)}\r\n";
            return retVal;
        }
        private string GetSearcExpression(bool forAltTtl)
        {
            var titleField = forAltTtl ? "t1.name" : "name";
            var retVal = "";
            for (int i = 0; i < _searchCondition.SearchValues.Count(); i++)
            {
                if(i > 0)
                {
                    retVal += " or ";
                }
                if (_searchCondition.SearchMethod == SearchMethod.ContainsWord)
                {
                    switch (_searchCondition.SearchField)
                    {
                        case SearchField.Title:
                            retVal += $"({titleField} = @searchValue1_{i} or {titleField} like  @searchValue2_{i} or {titleField} like  @searchValue3_{i} or {titleField} like  @searchValue4_{i})";
                            break;
                        case SearchField.Authors:
                            retVal += $"(author = @searchValue1_{i} or author like  @searchValue2_{i} or author like  @searchValue3_{i} or author like  @searchValue4_{i})";
                            break;
                        case SearchField.Performers:
                            retVal += $"(performer = @searchValue1_{i} or performer like  @searchValue2_{i} or performer like  @searchValue3_{i} or performer like  @searchValue4_{i})";
                            break;
                        default:
                            throw new Exception("Unknown search field");
                    }
                }
                else
                {
                    var searchOperator = GetSearchOperator();
                    switch (_searchCondition.SearchField)
                    {
                        case SearchField.Title:
                            retVal += $"{titleField} {searchOperator} @searchValue{i}";
                            break;
                        case SearchField.Authors:
                            retVal += $"author {searchOperator} @searchValue{i}";
                            break;
                        case SearchField.Performers:
                            retVal += $"t1.name {searchOperator} @searchValue{i}";
                            break;
                        default:
                            throw new Exception("Unknown search field");
                    }
                }
            }
            return retVal;
        }
        private string GetSearchOperator()
        {
            if(_searchCondition.SearchMethod == SearchMethod.Exact)
            {
                return "=";
            }
            else
            {
                return "like";
            }
        }
        private string GetSearchValue(int idx)
        {
            switch (_searchCondition.SearchMethod)
            {
                case SearchMethod.Exact:
                    return _searchCondition.SearchValues[idx];
                case SearchMethod.StartsWith:
                    return $"{_searchCondition.SearchValues[idx]}%";
                case SearchMethod.Contains:
                    return $"%{_searchCondition.SearchValues[idx]}%";
                case SearchMethod.ContainsWord:
                    return $"%{_searchCondition.SearchValues[idx]}%";
                case SearchMethod.Pattern:
                    return _searchCondition.SearchValues[idx];
            }
            throw new Exception("Unknown search field");
        }
        private string GetFromExpr()
        {
            switch (_searchCondition.SearchField)
            {
                case SearchField.Title:
                    if (_searchCondition.UseAltTtl)
                    {
                        return "SeekObject t1 join ObjectRight t2 on t1.ObjId = t2.ObjId";
                    }
                    else
                    {
                        return "ObjectRight t1";
                    }
                case SearchField.Authors:
                    return "ObjectRight t1";
                case SearchField.Performers:
                    return "SeekObject t1 join ObjectRight t2 on t1.ObjId = t2.ObjId";
            }
            throw new Exception("Unknown search field");
        }
    
        private void FillParameters(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            for (int i = 0; i < _searchCondition.SearchValues.Count(); i++)
            {
                var searchValue = _searchCondition.SearchValues[i];
                if (_searchCondition.SearchMethod == SearchMethod.ContainsWord)
                {
                    cmd.Parameters.AddWithValue($"@searchValue1_{i}", $"{searchValue}");
                    cmd.Parameters.AddWithValue($"@searchValue2_{i}", $"{searchValue} %");
                    cmd.Parameters.AddWithValue($"@searchValue3_{i}", $"% {searchValue}");
                    cmd.Parameters.AddWithValue($"@searchValue4_{i}", $"% {searchValue} %");
                }
                else
                {
                    cmd.Parameters.AddWithValue($"@searchValue{i}", GetSearchValue(i));
                }
            }
        }
    }
}
