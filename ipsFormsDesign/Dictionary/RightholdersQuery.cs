using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Dictionary
{
    public class RightholdersQuery
    {
        public string SearchText { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public KeyValuePair<string, string>[] ToKeyValuePair()
        {
            var parameters = new Collection<KeyValuePair<string, string>>();

            if (SearchText != null)
                parameters.Add(new KeyValuePair<string, string>(nameof(SearchText), SearchText));

            if (Page.HasValue)
                parameters.Add(new KeyValuePair<string, string>(nameof(Page), Page.Value.ToString()));

            if (PageSize.HasValue)
                parameters.Add(new KeyValuePair<string, string>(nameof(PageSize), PageSize.Value.ToString()));

            return parameters.ToArray();
        }
    }
}
