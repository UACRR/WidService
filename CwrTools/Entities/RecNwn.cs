using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecNwn : BaseRecDetail
    {
        public string IpNr { get; set; }
        public string WriterLastName { get; set; }
        public string WriterFirstName { get; set; }
        public string LangCode { get; set; }

        public override void FromLine(string line)
        {
            IpNr = (string)ParseA(line.Substring(19, 9));
            WriterLastName = (string)ParseA(line.Substring(28, 160));
            WriterFirstName = (string)ParseA(line.Substring(188, 160));
            LangCode = (string)ParseL(line.Substring(348, 2));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("NWN");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(IpNr, 9));
            sw.Write(FormatFieldA(WriterLastName, 160));
            sw.Write(FormatFieldA(WriterFirstName, 160));
            sw.Write(FormatFieldL(LangCode, 2));
            return sw.ToString();
        }
    }
}
