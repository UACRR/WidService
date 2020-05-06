using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexMusicWorkAuthor
    {
        public int? Id { get; set; }
        public int DdexReportId { get; set; }
        public int MasterMwRecordIndex { get; set; }
        public string BlockId { get; set; }

        public string ISRC { get; set; }
        public string ResourceTitle { get; set; }
        public string DisplayArtistName { get; set; }

        public string ISWC { get; set; }
        public string MusicWorkTitle { get; set; }
        public string ComposerAuthor { get; set; }

        public int WidCode { get; set; }
        public int ObjId { get; set; }
    }
}
