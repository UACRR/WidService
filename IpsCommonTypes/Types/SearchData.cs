using System.Collections.Generic;
using IpsCommonTypes.Enums;

namespace IpsCommonTypes.Types
{
    public class SearchData
    {
        public SearchData()
        {
            MatchTextOfSearch = MatchTextOfSearch.Equal;
            SearchParametersValue = new List<string>();
        }

        public SearchData(string searchText, List<string> searchParametersValue)
        {
            MatchTextOfSearch = MatchTextOfSearch.Equal;
            SearchText = searchText;
            SearchParametersValue = searchParametersValue;
        }

        public string SearchText { get; set; }
        public List<string> SearchParametersValue { get; set; }
        public MatchTextOfSearch MatchTextOfSearch { get; set; }
    }
}
