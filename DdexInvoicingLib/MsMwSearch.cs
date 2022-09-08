using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DdexInvoicingLib
{
    public class MsMwSearch : MwSearchBase
    {
        public MsMwSearch(string connectionString) : base(connectionString)
        {
        }
        public override List<TitleAuthorsPerformersAggr> SearchTitleAuthorsPerformers()
        {
            if (_searchConditions.Count() == 0)
            {
                return null;
            }
            if (_searchConditions.Any(x => x.SearchField == SearchField.Iswc))
            {
                return null;
            }
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

                    var seqNr = 1;
                    _titleAuthorsPerformers.Values.ToList().ForEach(x =>
                    {
                        retVal.Add(new TitleAuthorsPerformersAggr
                        {
                            SeqNr = seqNr++,
                            ObjId = x.ObjId,
                            Title = x.Title,
                            Authors = string.Join(" | ", x.Authors.OrderBy(y => y)),
                            Performers = string.Join(" | ", x.Performers.OrderBy(y => y)),
                            Action = "Вибрати",
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
            var with = "";
            _searchConditions.ForEach(searchCondition =>
            {
                var prefix = GetPrefix(searchCondition);
                var query = "select distinct top 1000 ObjId\r\n" +
                $"from {GetFromExpr(searchCondition)}\r\n" +
                $"where {GetSearcExpression(searchCondition)}\r\n";
                if (searchCondition.SearchField == SearchField.Title && searchCondition.UseAltTtl)
                {
                    query += "union\r\n" +
                    "select distinct top 1000 ObjId\r\n" +
                    $"from SeekObject\r\n" +
                    $"where {GetSearcExpression(searchCondition)}\r\n";
                }

                if (string.IsNullOrEmpty(with))
                {
                    with += ";with ";
                }
                else
                {
                    with += $", ";
                }
                with += $"v_{prefix} as ({query})\r\n";
            });

            var retVal = $"{with}insert #ObjIds\r\n";

            for (int i = 0; i < _searchConditions.Count(); i++)
            {
                var searchCondition = _searchConditions[i];
                var prefix = GetPrefix(searchCondition);
                if (i == 0)
                {
                    retVal += $"select top 1000 t_{prefix}.ObjId\r\n" +
                        $"from v_{prefix} t_{prefix} \r\n";
                }
                else
                {
                    var prevPrefix = GetPrefix(_searchConditions[i - 1]);
                    retVal += $"    join v_{prefix} t_{prefix} on t_{prefix}.ObjId = t_{prevPrefix}.ObjId\r\n";
                }
            }

            return retVal;
        }
        private string GetSearcExpression(SearchCondition searchCondition)
        {
            var retVal = "";
            var prefix = GetPrefix(searchCondition);
            for (int i = 0; i < searchCondition.SearchValues.Count(); i++)
            {
                if(i > 0)
                {
                    retVal += " or ";
                }
                if (searchCondition.SearchMethod == SearchMethod.ContainsWord)
                {
                    switch (searchCondition.SearchField)
                    {
                        case SearchField.Title:
                            retVal += $"(name = @searchValue_{prefix}_1_{i} or " +
                                $"name like  @searchValue_{prefix}_2_{i} or " +
                                $"name like  @searchValue_{prefix}_3_{i} or " +
                                $"name like  @searchValue_{prefix}_4_{i})";
                            break;
                        case SearchField.Authors:
                            retVal += $"(author = @searchValue_{prefix}_1_{i} or " +
                                $"author like  @searchValue_{prefix}_2_{i} or " +
                                $"author like  @searchValue_{prefix}_3_{i} or " +
                                $"author like  @searchValue_{prefix}_4_{i})";
                            break;
                        case SearchField.Performers:
                            retVal += $"(performer = @searchValue_{prefix}_1_{i} or " +
                                $"performer like  @searchValue_{prefix}_2_{i} or " +
                                $"performer like  @searchValue_{prefix}_3_{i} or " +
                                $"performer like  @searchValue_{prefix}_4_{i})";
                            break;
                        default:
                            throw new Exception("Unknown search field");
                    }
                }
                else
                {
                    var searchOperator = GetSearchOperator(searchCondition);
                    switch (searchCondition.SearchField)
                    {
                        case SearchField.Title:
                            retVal += $"name {searchOperator} @searchValue_{prefix}_{i}";
                            break;
                        case SearchField.Authors:
                            retVal += $"author {searchOperator} @searchValue_{prefix}_{i}";
                            break;
                        case SearchField.Performers:
                            retVal += $"performer {searchOperator} @searchValue_{prefix}_{i}";
                            break;
                        default:
                            throw new Exception("Unknown search field");
                    }
                }
            }
            return retVal;
        }
        private string GetSearchOperator(SearchCondition searchCondition)
        {
            if (searchCondition.SearchMethod == SearchMethod.Exact)
            {
                return "=";
            }
            else
            {
                return "like";
            }
        }
        private string GetSearchValue(SearchCondition searchCondition, int idx)
        {
            switch (searchCondition.SearchMethod)
            {
                case SearchMethod.Exact:
                    return searchCondition.SearchValues[idx];
                case SearchMethod.StartsWith:
                    return $"{searchCondition.SearchValues[idx]}%";
                case SearchMethod.Contains:
                    return $"%{searchCondition.SearchValues[idx]}%";
                case SearchMethod.ContainsWord:
                    return $"%{searchCondition.SearchValues[idx]}%";
                case SearchMethod.Pattern:
                    return searchCondition.SearchValues[idx];
            }
            throw new Exception("Unknown search field");
        }
        private string GetFromExpr(SearchCondition searchCondition)
        {
            return "ObjectRight";
        }
    
        private void FillParameters(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            _searchConditions.ForEach(searchCondition =>
            {
                var prefix = GetPrefix(searchCondition);
                for (int i = 0; i < searchCondition.SearchValues.Count(); i++)
               {
                   var searchValue = searchCondition.SearchValues[i];
                   if (searchCondition.SearchMethod == SearchMethod.ContainsWord)
                   {
                       cmd.Parameters.AddWithValue($"@searchValue_{prefix}_1_{i}", $"{searchValue}");
                       cmd.Parameters.AddWithValue($"@searchValue_{prefix}_2_{i}", $"{searchValue} %");
                       cmd.Parameters.AddWithValue($"@searchValue_{prefix}_3_{i}", $"% {searchValue}");
                       cmd.Parameters.AddWithValue($"@searchValue_{prefix}_4_{i}", $"% {searchValue} %");
                   }
                   else
                   {
                       cmd.Parameters.AddWithValue($"@searchValue_{prefix}_{i}", GetSearchValue(searchCondition, i));
                   }
               }
           });
        }
    }
}
