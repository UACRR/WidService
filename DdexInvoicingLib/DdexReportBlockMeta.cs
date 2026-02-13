using Microsoft.VisualBasic.FileIO;
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
    public class DdexReportBlockMeta : DdexReportBlock
    {
        public SRRecord_03_01 record;
        public int blockId;

        public DdexReportBlockMeta(DdexReport report, bool doFiltering) : base(report, doFiltering) { }

        public override bool Init(StreamReader streamReader, ref string line)
        {
            var fields = line.Split('\t');
            record = new SRRecord_03_01();
            record.fields = fields;

            blockId = int.Parse(fields[1]);

            if(blockId % 10000 == 0)
                Logger.WriteLine($"Обробка блоків - останнім оброблено блок {blockId}");
            return true;
        }

        public override void Process(DdexReportActionBase action, StreamReader streamReader, ref string firstLine)
        {
            action.ProcessBlock(this);
        }

        public override bool IsProcessed(int lastProcessedBlockId) => blockId <= lastProcessedBlockId;
    }
}
