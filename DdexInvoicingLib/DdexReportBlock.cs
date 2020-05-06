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

        public ASRecord asRecord = new ASRecord();
        public MWRecord canonicalMwRecord = new MWRecord();
        public List<RURecord> ruRecords = new List<RURecord>();
        public List<SURecord> suRecords = new List<SURecord>();

        public DdexReportBlock(DdexReport report, bool doFiltering)
        {
            this.report = report;
            this.doFiltering = doFiltering;
        }

        public bool Init(StreamReader streamReader, ref string firstLine)
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
            
            SURecord curSuRecord = null;
            LIRecord curLiRecord = null;
            bool isFirstMwRecord = true;
            while ((!streamReader.EndOfStream && !fields[0].Equals("FOOT") && fields[1].Equals(blockId)))
            {
                string recordType = fields[0];
                if (recordType.Equals("AS01.01"))
                {
                    asRecord.fields = fields;
                }
                else if (recordType.Equals("MW01.01"))
                {
                    MWRecord mwRecord = new MWRecord();
                    mwRecord.fields = fields;
                    if (isFirstMwRecord)
                    {
                        canonicalMwRecord = mwRecord;
                        isFirstMwRecord = false;
                    }
                    else if(curLiRecord != null)
                        curLiRecord.mwRecord = mwRecord;
                }
                else if (recordType.Equals("RU01.01"))
                {
                    RURecord record = new RURecord();
                    record.fields = fields;
                    ruRecords.Add(record);
                }
                else if (recordType.Equals("SU03.02"))
                {
                    curSuRecord = new SURecord();
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
                        curLiRecord = new LIRecord();
                        curLiRecord.fields = fields;
                        if (doFiltering && !curLiRecord.RightsController.Equals("Residual", StringComparison.OrdinalIgnoreCase))
                            curLiRecord = null;
                        else
                            curSuRecord.liRecords.Add(curLiRecord);
                    }
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

        public void Process(DdexReportActionBase action, StreamReader streamReader, ref string firstLine)
        {
            action.ProcessBlock(this);
        }
    }
}
