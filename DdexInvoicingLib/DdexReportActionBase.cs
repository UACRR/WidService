using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexReportActionBase
    {
        protected const string UACRR_CS = "UACRR_CS";
        public DdexReport report;

        public virtual string GetDescription() { return ""; }
        public virtual void Init(DdexReport report) { this.report = report; }
        public virtual int GetLastProcessedBlockId() { return 0; }
        public virtual void ProcessBlock(DdexReportBlock block) { }
        public virtual void ProcessHead(HEADRecordGoogle readRecord) { }
        public virtual void ProcessFoot(FOOTRecord footRecord) { }
        public virtual void ProcessSY_02_02(SYRecord_02_02 syRecord) { }
        public virtual void ProcessSY_04_01(SYRecord_04_01 syRecord) { }
        public virtual void ProcessSY_05_02(SYRecord_05_02 syRecord) { }
        public virtual void ProcessAP(APRecord apRecord) { }
        public virtual bool DoFiltering() { return false; }
    }
}
