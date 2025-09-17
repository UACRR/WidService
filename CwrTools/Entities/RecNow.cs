using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecNow : BaseRecDetail
    {
        public string WriterName { get; set; }
        public string WriterFirstName { get; set; }
        public string LangCode { get; set; }
        public string WriterPosition { get; set; }

        public override void FromLine(string line)
        {
            WriterName = (string)ParseA(line.Substring(19, 160));
            WriterFirstName = (string)ParseA(line.Substring(179, 160));
            LangCode = (string)ParseL(line.Substring(339, 2));
            WriterPosition = (string)ParseL(line.Substring(341, 1));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("NOW");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(WriterName, 160));
            sw.Write(FormatFieldA(WriterFirstName, 160));
            sw.Write(FormatFieldL(LangCode, 2));
            sw.Write(FormatFieldL(WriterPosition, 1));
            return sw.ToString();
        }
    }
}
