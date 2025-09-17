using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecNpn : BaseRecDetail
    {
        public string PublisherSequenceNr { get; set; }
        public string IpNr { get; set; }
        public string PublisherName { get; set; }
        public string LangCode { get; set; }

        public override void FromLine(string line)
        {
            PublisherSequenceNr = (string)ParseN(line.Substring(19, 2));
            IpNr = (string)ParseA(line.Substring(21, 9));
            PublisherName = (string)ParseA(line.Substring(30, 480));
            LangCode = (string)ParseL(line.Substring(510, 2));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("NPN");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldN(PublisherSequenceNr, 2));
            sw.Write(FormatFieldA(IpNr, 9));
            sw.Write(FormatFieldA(PublisherName, 480));
            sw.Write(FormatFieldL(LangCode, 2));
            return sw.ToString();
        }
    }
}
