using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WidTestConsole
{
    public class WidMwSearch : MwSearchBase
    {
        public WidMwSearch(string connectionString) : base(connectionString)
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
                    cmd.CommandText = "drop table if exists #Wics\r\n" +
                        "create table #Wics(Wic int)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = GetCreateWicsSql();
                    FillParameters(cmd);
                    cmd.ExecuteNonQuery();

                    SelectTitles(cmd);
                    SelectAuthors(cmd);
                    SelectPerformers(cmd);

                    _titleAuthorsPerformers.Values.ToList().ForEach(x =>
                    {
                        retVal.Add(new TitleAuthorsPerformersAggr
                        {
                            Wic = x.Wic,
                            Title = x.Title,
                            Authors = string.Join(" | ", x.Authors.OrderBy(y => y)),
                            Performers = string.Join(" | ", x.Performers.OrderBy(y => y)),
                        });
                    });

                    cmd.CommandText = "drop table if exists #Wics";
                    cmd.ExecuteNonQuery();
                }
            }
                return retVal.OrderBy(x => x.Title).ToList();
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
            cmd.CommandText = "select t1.Wic, t3.FstName, t3.LstName, t2.IpRole\r\n" +
                "from #Wics t1\r\n" +
                "    join SocWid..widIntrPty t2 on t1.Wic = t2.Wic\r\n" +
                "    join SocWid..IpiName t3 on t2.IpNameNr = t3.IpNameNr\r\n";
            cmd.Parameters.Clear();
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    var fstName = r.IsDBNull(1) ? "" : r.GetString(1);
                    var lstName = r.IsDBNull(2) ? "" : r.GetString(2);
                    _titleAuthorsPerformers[r.GetInt32(0)].Authors.Add($"{fstName} {lstName} ({r.GetString(3)})".Trim());
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
            var with = "select distinct top 1000 Wic\r\n" +
                $"from {GetFromExpr()}\r\n" +
                $"where {GetSearcExpression(false)}\r\n";
            if (_searchCondition.SearchField == SearchField.Title && _searchCondition.UseAltTtl)
            {
                with += "union\r\n" +
                "select distinct top 1000 Wic\r\n" +
                $"from SocWid..widAltTtl\r\n" +
                $"where {GetSearcExpression(true)}\r\n";
            }
            var retVal = $";with un as ({with})\r\n" +
                "insert #Wics\r\n" +
                "select top 1000 Wic\r\n" +
                "from un\r\n";
            return retVal;
        }
        private string GetSearcExpression(bool forAltTtl)
        {
            var titleField = forAltTtl ? "AltTtl" : "WrkTtl";
            var retVal = "";
            for (int i = 0; i < _searchCondition.SearchValues.Count(); i++)
            {
                var searchValue = _searchCondition.SearchValues[i];
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
                            retVal += $"(FstName = @searchValue{i} or LstName = @searchValue{i})";
                            break;
                        case SearchField.Performers:
                            retVal += $"(PerfArtistFstName = @searchValue{i} or PerfArtistLstName = @searchValue{i})";
                            break;
                        case SearchField.Iswc:
                            retVal += $"Iswc = @searchValue{i}";
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
                            retVal += $"(FstName {searchOperator} @searchValue{i} or LstName {searchOperator} @searchValue{i})";
                            break;
                        case SearchField.Performers:
                            retVal += $"(PerfArtistFstName {searchOperator} @searchValue{i} or PerfArtistLstName {searchOperator} @searchValue{i})";
                            break;
                        case SearchField.Iswc:
                            retVal += $"Iswc = @searchValue{i}";
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
                    return "SocWid..widTitle";
                case SearchField.Authors:
                    return "SocWid..IpiName t1	join SocWid..widIntrPty t2 on t1.IpNameNr = t2.IpNameNr";
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
            for (int i = 0; i < _searchCondition.SearchValues.Count(); i++)
            {
                var searchValue = _searchCondition.SearchValues[i];
                if (_searchCondition.SearchMethod == SearchMethod.ContainsWord)
                {
                    if (_searchCondition.SearchField == SearchField.Title)
                    {
                        cmd.Parameters.AddWithValue($"@searchValue1_{i}", $"{searchValue}");
                        cmd.Parameters.AddWithValue($"@searchValue2_{i}", $"{searchValue} %");
                        cmd.Parameters.AddWithValue($"@searchValue3_{i}", $"% {searchValue}");
                        cmd.Parameters.AddWithValue($"@searchValue4_{i}", $"% {searchValue} %");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue($"@searchValue{i}", $"{searchValue}");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue($"@searchValue{i}", GetSearchValue(i));
                }
            }
        }
    }
}
