using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ipsFormsDesign.Dictionary
{
    public class RightholderListQuery
    {
        public RightholderStatusType? Status { get; set; }

        public KeyValuePair<string, string>[] ToKeyValuePair()
        {
            var parameters = new Collection<KeyValuePair<string, string>>();

            if (Status.HasValue)
                parameters.Add(new KeyValuePair<string, string>("status", ((int)Status.Value).ToString()));

            return parameters.ToArray();
        }
    }
}
