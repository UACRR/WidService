using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecGrt : BaseRec
    {
        public string GroupID { get; set; }
        public string TranCount { get; set; }
        public string RecordCount { get; set; }

        public override void FromLine(string line)
        {
            GroupID = (string)ParseN(line.Substring(3, 5));
            TranCount = (string)ParseN(line.Substring(8, 8));
            RecordCount = (string)ParseN(line.Substring(16, 8));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("GRT");
            sw.Write(FormatFieldN(GroupID, 5));
            sw.Write(FormatFieldN(TranCount, 8));
            sw.Write(FormatFieldN(RecordCount, 8));
            return sw.ToString();
        }
    }
}
