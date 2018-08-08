using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Dictionary
{
    public class LicenseAgreementQuery
    {
        public LicenseTypes? State { get; set; }
        public AgreementStatuses? Status { get; set; }

        public KeyValuePair<string, string>[] ToKeyValuePair()
        {
            var parameters = new Collection<KeyValuePair<string, string>>();

            if (State.HasValue)
                parameters.Add(new KeyValuePair<string, string>(nameof(State), ((int)State.Value).ToString()));

            if (Status.HasValue)
                parameters.Add(new KeyValuePair<string, string>(nameof(Status), ((int)Status.Value).ToString()));

            return parameters.ToArray();
        }
    }
}
