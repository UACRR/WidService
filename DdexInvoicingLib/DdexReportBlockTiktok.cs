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
    public class DdexReportBlockTiktok : DdexReportBlock
    {
        public ASRecord_02_02 asRecord;
        public SURecord_02 suRecord;

        public DdexReportBlockTiktok(DdexReport report, bool doFiltering) : base(report, doFiltering) { }

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
                if (recordType.Equals("AS02.02"))
                {
                    var record = new ASRecord_02_02();
                    record.fields = fields;
                    asRecord = record;
                }
                else if (recordType.Equals("SU02"))
                {
                    var record = new SURecord_02();
                    record.fields = fields;
                    suRecord = record;
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

        public override bool IsProcessed(int lastProcessedBlockId) => 
            int.Parse(asRecord.BlockId) <= lastProcessedBlockId;
    }
}
