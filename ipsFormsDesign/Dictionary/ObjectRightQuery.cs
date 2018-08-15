using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectRightQuery
    {
        public ObjectRightStates? State { get; set; }
        public int? Category { get; set; }
        public int? Genre { get; set; }
        public string SearchText { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public KeyValuePair<string, string>[] ToKeyValuePair()
        {
            var parameters = new Collection<KeyValuePair<string, string>>();

            if (State.HasValue)
                parameters.Add(new KeyValuePair<string, string>(nameof(State), ((int)State.Value).ToString()));

            if (Category.HasValue)
                parameters.Add(new KeyValuePair<string, string>(nameof(Category), (Category.Value).ToString()));

            if (Genre.HasValue)
                parameters.Add(new KeyValuePair<string, string>(nameof(Genre), (Genre.Value).ToString()));

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
