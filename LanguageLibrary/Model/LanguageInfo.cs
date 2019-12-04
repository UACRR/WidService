using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLibrary.Model
{
    public class LanguageInfo
    {
        public static readonly Dictionary<string,string> XMLMapper = new Dictionary<string, string>
        {
            [nameof(LanguageName)] = "name",
            [nameof(UkrainianName)] = "ua-name",
            [nameof(SpecificationCode)] = "specificationCode",
            [nameof(IncompletenessItemCount)] = "incompletenessItemCount",
        };

        public string LanguageName { get; set; }

        public string UkrainianName { get; set; }

        public string SpecificationCode { get; set; }

        public int IncompletenessItemCount { get; set; }
    }
}
