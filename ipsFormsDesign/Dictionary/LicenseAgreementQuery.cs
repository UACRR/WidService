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
        public List<LicenseTypes> States { get; set; } = new List<LicenseTypes>();
        public AgreementStatuses? Status { get; set; }

        public KeyValuePair<string, string>[] ToKeyValuePair()
        {
            var parameters = new Collection<KeyValuePair<string, string>>();

            if (States.Any())
            {
                foreach (var s in States)
                {
                    parameters.Add(new KeyValuePair<string, string>(nameof(States), ((int)s).ToString()));
                }
            }

            if (Status.HasValue)
                parameters.Add(new KeyValuePair<string, string>(nameof(Status), ((int)Status.Value).ToString()));

            return parameters.ToArray();
        }
    }
}
