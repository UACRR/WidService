using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecTrl : BaseRec
    {
        public string GroupCount { get; set; }
        public string TranCount { get; set; }
        public string RecordCount { get; set; }

        public override void FromLine(string line)
        {
            GroupCount = (string)ParseN(line.Substring(3, 5));
            TranCount = (string)ParseN(line.Substring(8, 8));
            RecordCount = (string)ParseN(line.Substring(16, 8));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("TRL");
            sw.Write(FormatFieldN(GroupCount, 5));
            sw.Write(FormatFieldN(TranCount, 8));
            sw.Write(FormatFieldN(RecordCount, 8));
            return sw.ToString();
        }
    }
}
