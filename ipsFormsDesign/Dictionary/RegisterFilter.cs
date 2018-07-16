using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Dictionary
{
    public class RegisterFilter
    {
        public int? Status { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public KeyValuePair<string, string>[] GetKeyValuePairParameters()
        {
            Collection<KeyValuePair<string, string>> parameters = new Collection<KeyValuePair<string, string>>();

            if (Status.HasValue)
                parameters.Add(new KeyValuePair<string, string>("status", Status.Value.ToString()));

            if (BeginDate.HasValue)
                parameters.Add(new KeyValuePair<string, string>("beginDate", BeginDate.Value.ToString("yyyy-MM-dd")));

            if (EndDate.HasValue)
                parameters.Add(new KeyValuePair<string, string>("endDate", EndDate.Value.ToString("yyyy-MM-dd")));

            return parameters.ToArray();
        }
    }
}
