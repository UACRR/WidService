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
    public class DdexReportBlockSpotify : DdexReportBlock
    {
        public RERecord_01 reRecord = new RERecord_01();
        public List<ASRecord_02_02> asRecords = new List<ASRecord_02_02>();
        public List<SURecord_02> suRecords = new List<SURecord_02>();

        public DdexReportBlockSpotify(DdexReport report, bool doFiltering) : base(report, doFiltering) { }

        public override bool Init(StreamReader streamReader, ref string firstLine)
        {
            string[] fields = firstLine.Split('\t');
            if (fields[0].Equals("FOOT"))
                return false;

            string blockId = fields[1];
            if(int.Parse(blockId) % 10000 == 0)
                Logger.WriteLine($"Обробка блоків - останнім оброблено блок {blockId}");

            var nextLine = firstLine;

            while ((!streamReader.EndOfStream && !fields[0].Equals("FOOT") && fields[1].Equals(blockId)))
            {
                string recordType = fields[0];
                if (recordType.Equals("RE01"))
                {
                    reRecord.fields = fields;
                }
                else if (recordType.Equals("AS02.02"))
                {
                    var record = new ASRecord_02_02();
                    record.fields = fields;
                    asRecords.Add(record);
                }
                else if (recordType.Equals("SU02"))
                {
                    var record = new SURecord_02();
                    record.fields = fields;
                    suRecords.Add(record);
                }

                nextLine = streamReader.ReadLine();
                fields = nextLine.Split('\t');
            }

            firstLine = nextLine;

            return true;
        }

        public override void Process(DdexReportActionBase action, StreamReader streamReader, ref string firstLine)
        {
            action.ProcessBlock(this);
        }

        public override bool IsProcessed(int lastProcessedBlockId) => int.Parse(reRecord.BlockId) < lastProcessedBlockId;
    }
}
