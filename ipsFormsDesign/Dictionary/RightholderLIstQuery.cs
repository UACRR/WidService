using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ipsFormsDesign.Dictionary
{
    public class RightholderListQuery
    {
        public string SearchString { get; set; }
        public RightholderStatusType? RightholderStatus { get; set; }
        public AgreementStatuses? AgreementStatus { get; set; }
        public int? FilterType { get; set; }
        public int? PageNumber { get; set;  }
        public int? RowsPerPage { get; set;  }

        public KeyValuePair<string, string>[] ToKeyValuePair()
        {
            var parameters = new Collection<KeyValuePair<string, string>>();

            if (RightholderStatus.HasValue)
                parameters.Add(new KeyValuePair<string, string>("rightholderStatus", ((int)RightholderStatus.Value).ToString()));

            if (AgreementStatus.HasValue)
                parameters.Add(new KeyValuePair<string, string>("agreementStatus", ((int)AgreementStatus.Value).ToString()));

            if (PageNumber.HasValue)
                parameters.Add(new KeyValuePair<string, string>("pageNumber", (PageNumber.Value).ToString()));

            if (RowsPerPage.HasValue)
                parameters.Add(new KeyValuePair<string, string>("rowsPerPage", (RowsPerPage.Value).ToString()));

            if(!string.IsNullOrEmpty(SearchString) && SearchString.Trim().Length > 0)
                parameters.Add(new KeyValuePair<string, string>("searchString", SearchString));

            if (FilterType.HasValue)
                parameters.Add(new KeyValuePair<string, string>("filterType", (FilterType.Value).ToString()));


            return parameters.ToArray();
        }
    }
}
