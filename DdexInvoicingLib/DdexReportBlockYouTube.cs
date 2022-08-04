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
    public class DdexReportBlockYouTube: DdexReportBlock
    {
        public ASRecord_01_01 asRecord = null;
        public MWRecord_01_01 canonicalMwRecord = null;
        public List<RURecord_01_01> ruRecords = new List<RURecord_01_01>();
        public List<SURecord_03_02> suRecords = new List<SURecord_03_02>();

        public DdexReportBlockYouTube(DdexReport report, bool doFiltering) : base(report, doFiltering) { }

        public override bool Init(StreamReader streamReader, ref string firstLine)
        {
            // CORRECT ERROR IN FILE
            CorrectLine(ref firstLine);
            //======================
            string[] fields = firstLine.Split('\t');
            if (fields[0].Equals("FOOT"))
                return false;

            string blockId = fields[1];
            if(int.Parse(blockId) % 10000 == 0)
                Logger.WriteLine($"Обробка блоків - останнім оброблено блок {blockId}");

            var nextLine = firstLine;

            SURecord_03_02 curSuRecord = null;
            LIRecord_01_02 curLiRecord = null;
            bool isFirstMwRecord = true;
            while ((!streamReader.EndOfStream && !fields[0].Equals("FOOT") && fields[1].Equals(blockId)))
            {
                string recordType = fields[0];
                if (recordType.Equals("AS01.01"))
                {
                    asRecord = new ASRecord_01_01();
                    asRecord.fields = fields;
                }
                else if (recordType.Equals("AS01.02"))
                {
                    asRecord = new ASRecord_01_02();
                    asRecord.fields = fields;
                }
                else if (recordType.Equals("MW01.01"))
                {
                    MWRecord_01_01 mwRecord = new MWRecord_01_01();
                    mwRecord.fields = fields;
                    if (isFirstMwRecord)
                    {
                        canonicalMwRecord = mwRecord;
                        isFirstMwRecord = false;
                    }
                    else if(curLiRecord != null)
                        curLiRecord.mwRecord = mwRecord;
                }
                else if (recordType.Equals("MW01.02"))
                {
                    MWRecord_01_02 mwRecord = new MWRecord_01_02();
                    mwRecord.fields = fields;
                    if (isFirstMwRecord)
                    {
                        canonicalMwRecord = mwRecord;
                        isFirstMwRecord = false;
                    }
                    else if (curLiRecord != null)
                        curLiRecord.mwRecord = mwRecord;
                }
                else if (recordType.Equals("RU01.01"))
                {
                    RURecord_01_01 record = new RURecord_01_01();
                    record.fields = fields;
                    ruRecords.Add(record);
                }
                else if (recordType.Equals("RU01.02"))
                {
                    RURecord_01_01 record = new RURecord_01_02();
                    record.fields = fields;
                    ruRecords.Add(record);
                }
                else if (recordType.Equals("SU03.02"))
                {
                    curSuRecord = new SURecord_03_02();
                    curSuRecord.fields = fields;
                    if (doFiltering && curSuRecord.GetNetRevenue().Equals(0))
                        curSuRecord = null;
                    else
                        suRecords.Add(curSuRecord);
                }
                else if (recordType.Equals("LI01.02"))
                {
                    if (curSuRecord != null)
                    {
                        curLiRecord = new LIRecord_01_02();
                        curLiRecord.fields = fields;
                        if (doFiltering && !curLiRecord.RightsController.Equals("Residual", StringComparison.OrdinalIgnoreCase))
                            curLiRecord = null;
                        else
                            curSuRecord.liRecords.Add(curLiRecord);
                    }
                }
                else if (recordType.Equals("LI01.03"))
                {
                    if (curSuRecord != null)
                    {
                        curLiRecord = new LIRecord_01_03();
                        curLiRecord.fields = fields;
                        if (doFiltering && !curLiRecord.RightsController.Equals("Residual", StringComparison.OrdinalIgnoreCase))
                            curLiRecord = null;
                        else
                            curSuRecord.liRecords.Add(curLiRecord);
                    }
                }
                else if (recordType.Equals("LC01") || recordType.Equals("ST01"))
                {
                }

                nextLine = streamReader.ReadLine();
                // CORRECT ERROR IN FILE
                CorrectLine(ref nextLine);
                //======================
                fields = nextLine.Split('\t');
            }

            firstLine = nextLine;

            return true;
        }

        private void CorrectLine(ref string line)
        {
            if (report.RecordsToCorrect == null)
                return;
            string[] fields = line.Split('\t');
            string key = $"{fields[1]}-{fields[0]}";
            if(report.RecordsToCorrect.Contains(key))
            {
                line = line.Replace("\\\t", ",");
            }
        }

        public override void Process(DdexReportActionBase action, StreamReader streamReader, ref string firstLine)
        {
            action.ProcessBlock(this);
        }

        public override bool IsProcessed(int lastProcessedBlockId) => int.Parse(asRecord.BlockId) <= lastProcessedBlockId;
    }
}
