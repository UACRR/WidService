using InvoicingLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexReportBlock
    {
        public DdexReport report;
        public bool doFiltering;

        public DdexReportBlock(DdexReport report, bool doFiltering)
        {
            this.report = report;
            this.doFiltering = doFiltering;
        }

        public virtual bool Init(StreamReader streamReader, ref string firstLine) { return true; }

        public virtual void Process(DdexReportActionBase action, StreamReader streamReader, ref string firstLine) { }

        public virtual bool IsProcessed(int lastProcessedBlockId) => false;
    }
}
