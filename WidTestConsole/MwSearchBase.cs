using System;
using System.Collections.Generic;
using System.Text;

namespace WidTestConsole
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
            public int? Wic { get; set; }
            public int? ObjId { get; set; }
            public string Title { get; set; }
            public string Authors { get; set; }
            public string Performers { get; set; }
        }

        protected string _connectionString;
        protected SearchCondition _searchCondition;

        protected Dictionary<int, TitleAuthorsPerformersEntry> _titleAuthorsPerformers;

        protected MwSearchBase(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void SetSearchCondition(SearchField searchField, SearchMethod searchMethod, List<string> searchValues, bool useAltTtl)
        {
            _searchCondition = new SearchCondition
            {
                SearchField = searchField,
                SearchMethod = searchMethod,
                SearchValues = searchValues,
                UseAltTtl = useAltTtl,
            };
        }

        public virtual List<TitleAuthorsPerformersAggr> SearchTitleAuthorsPerformers()
        {
            return null;
        }

    }
}
