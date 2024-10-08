namespace CopyrightObjectSearch.Server
{
    public class SearchParamsDto
    {
        public enum SearchFieldEnum
        {
            Name,
            Authors,
            Performers,
        }

        public enum SearchMethodEnum
        {
            None          = -1,
            Exact         =  0,
            ContainsWord  =  1,
            Contains      =  2,
            StartsWith    =  3,
            Pattern       =  4,
        }

        public class SearchConditionDto {
          public required SearchFieldEnum  SearchField  { get; set; }
          public required SearchMethodEnum SearchMethod { get; set; }
          public required string           Value        { get; set; }
        }

        public required SearchConditionDto[] SearchConditions { get; set; }

    }
}
