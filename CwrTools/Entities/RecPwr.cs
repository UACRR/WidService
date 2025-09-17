using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecPwr : BaseRecDetail
    {
        public string PublisherIPNr { get; set; }
        public string PublisherName { get; set; }
        public string SubmAgrNr { get; set; }
        public string SocAgrNr { get; set; }
        public string WriterIpNr { get; set; }
        public string PublisherSequenceNr { get; set; }

        public override void FromLine(string line)
        {
            PublisherIPNr = (string)ParseA(line.Substring(19, 9));
            PublisherName = (string)ParseA(line.Substring(28, 45));
            SubmAgrNr = (string)ParseA(line.Substring(73, 14));
            SocAgrNr = (string)ParseA(line.Substring(87, 14));
            WriterIpNr = (string)ParseA(line.Substring(101, 9));
            PublisherSequenceNr = (string)ParseN(line.Substring(110, 2));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("PWR");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(PublisherIPNr, 9));
            sw.Write(FormatFieldA(PublisherName, 45));
            sw.Write(FormatFieldA(SubmAgrNr, 14));
            sw.Write(FormatFieldA(SocAgrNr, 14));
            sw.Write(FormatFieldA(WriterIpNr, 9));
            sw.Write(FormatFieldN(PublisherSequenceNr, 2));
            return sw.ToString();
        }
    }
}
