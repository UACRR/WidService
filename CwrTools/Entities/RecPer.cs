using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecPer : BaseRecDetail
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string IpNameNr { get; set; }
        public string IpBaseNr { get; set; }

        public override void FromLine(string line)
        {
            LastName = (string)ParseA(line.Substring(19, 45));
            FirstName = (string)ParseA(line.Substring(64, 30));
            IpNameNr = (string)ParseL(line.Substring(94, 11));
            IpBaseNr = (string)ParseL(line.Substring(105, 13));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("PER");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(LastName, 45));
            sw.Write(FormatFieldA(FirstName, 30));
            sw.Write(FormatFieldL(IpNameNr, 11));
            sw.Write(FormatFieldL(IpBaseNr, 13));
            return sw.ToString();
        }
    }
}
