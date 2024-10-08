using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using static CopyrightObjectSearch.Server.SearchParamsDto;

namespace CopyrightObjectSearch.Server
{
    public class MwSearchWid : MwSearchBase
    {
        private List<string> _searchQueryParamValues = [];
        public MwSearchWid(CopyrightObjectSearchDbContext dbContext,
            List<SearchConditionDto> searchConditions) : base(dbContext, searchConditions)
        {
        }
        public FoundNameAuthorsPerformers[] Search()
        {
            var guid = Guid.NewGuid().ToString();
            _searchQueryParamValues = [];
            _searchQueryParamValues.Add(guid);

            var searchSql = CreateSearchWorksSql();

           _dbContext.Database.ExecuteSqlRaw(searchSql, _searchQueryParamValues.ToArray());

            var res = _dbContext
                .FoundNameAuthorsPerformers
                .FromSql($@"
                    select t1.* 
                    from vWidNameAuthorsPerformers t1 
                        join TmpSelectedIds t2 on t1.FoundCde = t2.SelectedId
                ")
                .ToArray();

            _dbContext.Database.ExecuteSql($@"
                delete from TmpSelectedIds where Guid = {guid}
            ");

            return res;
        }

        private string CreateSearchWorksSql()
        {
            var retVal = $@"
                insert TmpSelectedIds (Guid, SelectedId)
                select distinct top 1000 {{0}}, t{GetTableIdx()}.Wic
                from 
                    {GetJoinExpression()}
                where
                    {GetWhereExpression()}
            ";
            return retVal;
        }

        private int GetTableIdx()
        {
            // Індекс аліасу першої таблиці із поєднання (join) для пошуку
            if ((_searchConditions[(int)SearchFieldEnum.Name].SearchMethod != SearchMethodEnum.None))
            {
                return 1;
            }
            else if ((_searchConditions[(int)SearchFieldEnum.Authors].SearchMethod != SearchMethodEnum.None))
            {
                return 2;
            }
            else if ((_searchConditions[(int)SearchFieldEnum.Performers].SearchMethod != SearchMethodEnum.None))
            {
                return 4;
            }
            else
            {
                throw new Exception("В умовах пошуку не вказано жодної позиції для пошуку");
            }
        }

        private string GetJoinExpression()
        {
            var retVal = "";
            if ((_searchConditions[(int)SearchFieldEnum.Name].SearchMethod != SearchMethodEnum.None))
            {
                retVal += "SocWid..WidTitle t1";
            }
            if ((_searchConditions[(int)SearchFieldEnum.Authors].SearchMethod != SearchMethodEnum.None))
            {
                if(retVal != "")
                {
                    retVal += @"
                        join SocWid..WidIntrPty t2 on t1.Wic = t2.Wic
                        join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
                    ";
                }
                else
                {
                    retVal += @"
                        SocWid..WidIntrPty t2
                        join SocIpi..IpiName t3 on t2.IpNameNr = t3.IpNameNr
                    ";
                }
            }
            if ((_searchConditions[(int)SearchFieldEnum.Performers].SearchMethod != SearchMethodEnum.None))
            {
                if(retVal != "")
                {
                    retVal += @"
                        join SocWid..widArtist t4 on t1.Wic = t4.Wic
                    ";
                }
                else
                {
                    retVal += @"
                        SocWid..widArtist t4
                    ";
                }
            }
            
            if(retVal == "")
            {
                throw new Exception("В умовах пошуку не вказано жодної позиції для пошуку");
            };
            return retVal;
        }

         private string GetWhereExpression()
         {
            var paramIdx = 1;
            var searchCondition = _searchConditions[(int)SearchFieldEnum.Name];
            var retVal = "";

            var expr = GetWhereExpression(searchCondition, "t1.WrkTtl", ref paramIdx);
            retVal += expr;

            searchCondition = _searchConditions[(int)SearchFieldEnum.Authors];
            expr = GetWhereExpression(searchCondition, "t3.Name", ref paramIdx);
            if(!string.IsNullOrEmpty(expr))
            {
                if(!string.IsNullOrEmpty(retVal))
                {
                    retVal += " and ";
                }
                retVal += expr;
            }

            searchCondition = _searchConditions[(int)SearchFieldEnum.Performers];
            expr = GetWhereExpression(searchCondition, "t4.PerfArtistLstName", ref paramIdx);
            if(!string.IsNullOrEmpty(expr))
            {
                if(!string.IsNullOrEmpty(retVal))
                {
                    retVal += " and ";
                }
                retVal += expr;
            }

            return retVal;
         }

        private string GetWhereExpression(SearchConditionDto searchCondition, string fieldName, ref int paramIdx)
        {
            switch(searchCondition.SearchMethod)
            {
                case SearchMethodEnum.Exact:
                    _searchQueryParamValues.Add(searchCondition.Value);
                    return $"{fieldName} = {{{paramIdx++}}}";
                case SearchMethodEnum.ContainsWord:
                    _searchQueryParamValues.Add($"{searchCondition.Value} %");
                    _searchQueryParamValues.Add($"% {searchCondition.Value} %");
                    _searchQueryParamValues.Add($"% {searchCondition.Value}");
                    return $"({fieldName} like {{{paramIdx++}}} or {fieldName} like {{{paramIdx++}}} or {fieldName} like {{{paramIdx++}}})";
                case SearchMethodEnum.Contains:
                    _searchQueryParamValues.Add($"%{searchCondition.Value}%");
                    return $"{fieldName} like {{{paramIdx++}}}";
                case SearchMethodEnum.StartsWith:
                    _searchQueryParamValues.Add($"{searchCondition.Value}%");
                    return $"{fieldName} like {{{paramIdx++}}}";
                case SearchMethodEnum.Pattern:
                    _searchQueryParamValues.Add($"{searchCondition.Value}");
                    return $"{fieldName} like {{{paramIdx++}}}";
                default:
                    return "";
            }
        }

        private string GetWhereExpression(SearchConditionDto searchCondition, ref int paramIdx)
        {
            switch(searchCondition.SearchMethod)
            {
                case SearchMethodEnum.Exact:
                    _searchQueryParamValues.Add(searchCondition.Value);
                    return $"WrkTtl = {{{paramIdx++}}}";
                case SearchMethodEnum.ContainsWord:
                    _searchQueryParamValues.Add($"{searchCondition.Value} %");
                    _searchQueryParamValues.Add($"% {searchCondition.Value} %");
                    _searchQueryParamValues.Add($"% {searchCondition.Value}");
                    return $"(WrkTtl like {{{paramIdx++}}} or WrkTtl like {{{paramIdx++}}} or WrkTtl like {{{paramIdx++}}})";
                case SearchMethodEnum.Contains:
                    _searchQueryParamValues.Add($"%{searchCondition.Value}%");
                    return $"WrkTtl like {{{paramIdx++}}}";
                case SearchMethodEnum.StartsWith:
                    _searchQueryParamValues.Add($"{searchCondition.Value}%");
                    return $"WrkTtl like {{{paramIdx++}}}";
                case SearchMethodEnum.Pattern:
                    _searchQueryParamValues.Add($"{searchCondition.Value}");
                    return $"WrkTtl like {{{paramIdx++}}}";
                default:
                    return "";
            }
        }

       /*private void SelectTitles(SqlCommand cmd)
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
*/
        private string GetCreateWicsSql()
        {
            return "";
        }
/*
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

        }*/
    }
}
