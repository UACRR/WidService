using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ipsFormsDesign.Dictionary
{
    public class RightholderListQuery
    {
        public RightholderStatusType? RightholderStatus { get; set; }
        public AgreementStatuses? AgreementStatus { get; set; }

        public KeyValuePair<string, string>[] ToKeyValuePair()
        {
            var parameters = new Collection<KeyValuePair<string, string>>();

            if (RightholderStatus.HasValue)
                parameters.Add(new KeyValuePair<string, string>("rightholderStatus", ((int)RightholderStatus.Value).ToString()));

            if (AgreementStatus.HasValue)
                parameters.Add(new KeyValuePair<string, string>("agreementStatus", ((int)AgreementStatus.Value).ToString()));

            return parameters.ToArray();
        }
    }
}
