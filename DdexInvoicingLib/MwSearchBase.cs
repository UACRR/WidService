using System;
using System.Collections.Generic;
using System.Text;

namespace DdexInvoicingLib
{
    public class MwSearchBase
    {
        public enum SearchField
        {
            Title,
            Authors,
            Performers,
            Iswc,
        }
        public enum SearchMethod
        {
            Exact,
            StartsWith,
            Contains,
            ContainsWord,
            Pattern,
        }
        public class SearchCondition
        {
            public SearchField SearchField { get; set; }
            public SearchMethod SearchMethod { get; set; }
            public List<string> SearchValues { get; set; }
            public bool UseAltTtl { get; set; }
        }
        public class TitleAuthorsPerformersEntry
        {
            public int? Wic { get; set; }
            public int? ObjId { get; set; }
            public string Title { get; set; }
            public List<string> Authors { get; set; }
            public List<string> Performers { get; set; }
        }

        public class TitleAuthorsPerformersAggr
        {
            public int SeqNr { get; set; }
            public int? Wic { get; set; }
            public int? ObjId { get; set; }
            public string Title { get; set; }
            public string Authors { get; set; }
            public string Performers { get; set; }
            public string Action { get; set; }
        }

        protected string _connectionString;
        protected List<SearchCondition> _searchConditions;

        protected Dictionary<int, TitleAuthorsPerformersEntry> _titleAuthorsPerformers;

        protected MwSearchBase(string connectionString)
        {
            _connectionString = connectionString;
            _searchConditions = new List<SearchCondition>();
        }
        public void CrearSearchConditions()
        {
            _searchConditions = new List<SearchCondition>();
        }
        public void AddSearchCondition(SearchField searchField, SearchMethod searchMethod, List<string> searchValues, bool useAltTtl)
        {
            _searchConditions.Add(new SearchCondition
            {
                SearchField = searchField,
                SearchMethod = searchMethod,
                SearchValues = searchValues,
                UseAltTtl = useAltTtl,
            });
        }

        public virtual List<TitleAuthorsPerformersAggr> SearchTitleAuthorsPerformers()
        {
            return null;
        }

        protected int GetPrefix(SearchCondition searchCondition)
        {
            return (int)searchCondition.SearchField;
        }


    }
}
