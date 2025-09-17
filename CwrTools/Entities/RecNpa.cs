using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecNpa : BaseRecDetail
    {
        public string IpNr { get; set; }
        public string IpName { get; set; }
        public string IpWriterFirstName { get; set; }

        public override void FromLine(string line)
        {
            IpNr = (string)ParseA(line.Substring(19, 9));
            IpName = (string)ParseA(line.Substring(28, 160));
            IpWriterFirstName = (string)ParseA(line.Substring(188, 160));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("NPA");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(IpNr, 9));
            sw.Write(FormatFieldA(IpName, 160));
            sw.Write(FormatFieldA(IpWriterFirstName, 160));
            return sw.ToString();
        }
    }
}
