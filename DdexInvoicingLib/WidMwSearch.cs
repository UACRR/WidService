using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DdexInvoicingLib
{
    public class WidMwSearch : MwSearchBase
    {
        public WidMwSearch(string connectionString) : base(connectionString)
        {
        }
        public override List<TitleAuthorsPerformersAggr> SearchTitleAuthorsPerformers()
        {
            if(_searchConditions.Count() == 0)
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
                    cmd.CommandText = "drop table if exists #Wics\r\n" +
                        "create table #Wics(Wic int)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = GetCreateWicsSql();
                    FillParameters(cmd);
                    cmd.ExecuteNonQuery();

                    SelectTitles(cmd);
                    SelectAuthors(cmd);
                    SelectPerformers(cmd);

                    var seqNr = 1;
                    _titleAuthorsPerformers.Values.OrderBy(x => x.Title).ToList().ForEach(x =>
                    {
                        retVal.Add(new TitleAuthorsPerformersAggr
                        {
                            SeqNr = seqNr++,
                            Wic = x.Wic,
                            Title = x.Title,
                            Authors = string.Join(" | ", x.Authors.OrderBy(y => y)),
                            Performers = string.Join(" | ", x.Performers.OrderBy(y => y)),
                            Action = "Вибрати",
                        });
                    });

                    cmd.CommandText = "drop table if exists #Wics";
                    cmd.ExecuteNonQuery();
                }
            }
            return retVal;
        }

        private void SelectTitles(SqlCommand cmd)
        {
            cmd.CommandText = "select t1.Wic, t2.WrkTtl\r\n" +
                "from #Wics t1\r\n" +
                "    join SocWid..widTitle t2 on t1.Wic = t2.Wic";
            cmd.Parameters.Clear();
            using (var r = cmd.ExecuteReader())
            {
                _titleAuthorsPerformers = new Dictionary<int, TitleAuthorsPerformersEntry>();
                while (r.Read())
                {
                    if (_titleAuthorsPerformers.ContainsKey(r.GetInt32(0)))
                        continue;

                    _titleAuthorsPerformers.Add(r.GetInt32(0), new TitleAuthorsPerformersEntry
                    {
                        Wic = r.GetInt32(0),
                        Title = r.GetString(1),
                        Authors = new List<string>(),
                        Performers = new List<string>(),
                    });
                }
            };
        }

        private void SelectAuthors(SqlCommand cmd)
        {
            cmd.CommandText = "select t1.Wic, t3.FstName, t3.Name, t2.IpRole\r\n" +
                "from #Wics t1\r\n" +
                "    join SocWid..widIntrPty t2 on t1.Wic = t2.Wic\r\n" +
                "    join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr\r\n";
            cmd.Parameters.Clear();
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    var fstName = r.IsDBNull(1) ? "" : r.GetString(1);
                    var Name = r.IsDBNull(2) ? "" : r.GetString(2);
                    _titleAuthorsPerformers[r.GetInt32(0)].Authors.Add($"{fstName} {Name} ({r.GetString(3)})".Trim());
                }
            };
        }

        private void SelectPerformers(SqlCommand cmd)
        {
            cmd.CommandText = "select t1.Wic, t2.PerfArtistFstName, t2.PerfArtistLstName\r\n" +
                "from #Wics t1\r\n" +
                "    join SocWid..widArtist t2 on t1.Wic = t2.Wic\r\n";
            cmd.Parameters.Clear();
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    var fstName = r.IsDBNull(1) ? "" : r.GetString(1);
                    var lstName = r.IsDBNull(2) ? "" : r.GetString(2);
                    _titleAuthorsPerformers[r.GetInt32(0)].Performers.Add($"{fstName} {lstName}".Trim());
                }
            };
        }

        private string GetCreateWicsSql()
        {
            var with = "";
            _searchConditions.ForEach(searchCondition =>
            {
                var prefix = GetPrefix(searchCondition);
                var query = "select distinct top 1000 Wic\r\n" +
                $"from {GetFromExpr(searchCondition)}\r\n" +
                $"where {GetSearcExpression(searchCondition, false)}\r\n";
                if (searchCondition.SearchField == SearchField.Title && searchCondition.UseAltTtl)
                {
                    query += "union\r\n" +
                    "select distinct top 1000 Wic\r\n" +
                    $"from SocWid..widAltTtl\r\n" +
                    $"where {GetSearcExpression(searchCondition, true)}\r\n";
                }

                if(string.IsNullOrEmpty(with))
                {
                    with += ";with ";
                }
                else
                {
                    with += $", ";
                }
                with += $"v_{prefix} as ({query})\r\n";
            });

            var retVal = $"{with}insert #Wics\r\n";

            for (int i = 0; i < _searchConditions.Count(); i++)
            {
                var searchCondition = _searchConditions[i];
                var prefix = GetPrefix(searchCondition);
                if (i == 0)
                {
                    retVal += $"select top 1000 t_{prefix}.Wic\r\n" +
                        $"from v_{prefix} t_{prefix} \r\n";
                }
                else
                {
                    var prevPrefix = GetPrefix(_searchConditions[i - 1]);
                    retVal += $"    join v_{prefix} t_{prefix} on t_{prefix}.Wic = t_{prevPrefix}.Wic\r\n";
                }
            }

            return retVal;
        }
        private string GetSearcExpression(SearchCondition searchCondition, bool forAltTtl)
        {
            var titleField = forAltTtl ? "AltTtl" : "WrkTtl";
            var retVal = "";
            var prefix = GetPrefix(searchCondition);
            for (int i = 0; i < searchCondition.SearchValues.Count(); i++)
            {
                var searchValue = searchCondition.SearchValues[i];
                if(i > 0)
                {
                    retVal += " or ";
                }
                if (searchCondition.SearchMethod == SearchMethod.ContainsWord)
                {
                    switch (searchCondition.SearchField)
                    {
                        case SearchField.Title:
                            retVal += $"({titleField} = @searchValue_{prefix}_1_{i} or " +
                                $"{titleField} like  @searchValue_{prefix}_2_{i} or " +
                                $"{titleField} like  @searchValue_{prefix}_3_{i} or " +
                                $"{titleField} like  @searchValue_{prefix}_4_{i})";
                            break;
                        case SearchField.Authors:
                            retVal += $"(FstName = @searchValue_{prefix}_{i} or LstName = @searchValue_{prefix}_{i})";
                            break;
                        case SearchField.Performers:
                            retVal += $"(PerfArtistFstName = @searchValue_{prefix}_{i} or PerfArtistLstName = @searchValue_{prefix}_{i})";
                            break;
                        case SearchField.Iswc:
                            retVal += $"Iswc = @searchValue_{prefix}_{i}";
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
                            retVal += $"{titleField} {searchOperator} @searchValue_{prefix}_{i}";
                            break;
                        case SearchField.Authors:
                            retVal += $"(FstName {searchOperator} @searchValue_{prefix}_{i} or Name {searchOperator} @searchValue_{prefix}_{i})";
                            break;
                        case SearchField.Performers:
                            retVal += $"(PerfArtistFstName {searchOperator} @searchValue_{prefix}_{i} or PerfArtistLstName {searchOperator} @searchValue_{prefix}_{i})";
                            break;
                        case SearchField.Iswc:
                            retVal += $"Iswc = @searchValue_{prefix}_{i}";
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
            if(searchCondition.SearchMethod == SearchMethod.Exact)
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
            switch (searchCondition.SearchField)
            {
                case SearchField.Title:
                    return "SocWid..widTitle";
                case SearchField.Authors:
                    return "SocIpi..IpiName t1	join SocWid..widIntrPty t2 on t1.IpNameNr = t2.IpNameNr";
                case SearchField.Performers:
                    return "SocWid..widArtist";
                case SearchField.Iswc:
                    return "SocWid..widIswc";
            }
            throw new Exception("Unknown search field");
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
                        if (searchCondition.SearchField == SearchField.Title)
                        {
                            cmd.Parameters.AddWithValue($"@searchValue_{prefix}_1_{i}", $"{searchValue}");
                            cmd.Parameters.AddWithValue($"@searchValue_{prefix}_2_{i}", $"{searchValue} %");
                            cmd.Parameters.AddWithValue($"@searchValue_{prefix}_3_{i}", $"% {searchValue}");
                            cmd.Parameters.AddWithValue($"@searchValue_{prefix}_4_{i}", $"% {searchValue} %");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue($"@searchValue_{prefix}_{i}", $"{searchValue}");
                        }
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
