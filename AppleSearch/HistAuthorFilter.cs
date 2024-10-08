using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleSearch
{
    public class HistAuthorFilter
    {
        public int Id { get; set; }
        public int CustId { get; set; }
        public string WorkName { get; set; }
        public string WorkAuthor { get; set; }
        public string WorkPerformer { get; set; }
        public DateTime LastUsedAt { get; set; }

        public string GetDisplayText()
        {
            return $"N:{WorkName}; A:{WorkAuthor}; P:{WorkPerformer};";
        }
    }
}
