using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecCom : BaseRecDetail
    {
        public string Title { get; set; }
        public string CompISWC { get; set; }
        public string SubmWorkNr { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Writer1LastName { get; set; }
        public string Writer1FirstName { get; set; }
        public string Writer1IpNameNr { get; set; }
        public string Writer2LastName { get; set; }
        public string Writer2FirstName { get; set; }
        public string Writer2IpNameNr { get; set; }
        public string Writer1IpBaseNr { get; set; }
        public string Writer2IpBaseNr { get; set; }

        public override void FromLine(string line)
        {
            Title = (string)ParseA(line.Substring(19, 60));
            CompISWC = (string)ParseA(line.Substring(79, 11));
            SubmWorkNr = (string)ParseA(line.Substring(90, 14));
            Duration = (TimeSpan?)ParseT(line.Substring(104, 6));
            Writer1LastName = (string)ParseA(line.Substring(110, 45));
            Writer1FirstName = (string)ParseA(line.Substring(155, 30));
            Writer1IpNameNr = (string)ParseL(line.Substring(185, 11));
            Writer2LastName = (string)ParseA(line.Substring(196, 45));
            Writer2FirstName = (string)ParseA(line.Substring(241, 30));
            Writer2IpNameNr = (string)ParseL(line.Substring(271, 11));
            Writer1IpBaseNr = (string)ParseL(line.Substring(282, 13));
            Writer2IpBaseNr = (string)ParseL(line.Substring(295, 13));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("COM");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(Title, 60));
            sw.Write(FormatFieldA(CompISWC, 11));
            sw.Write(FormatFieldA(SubmWorkNr, 14));
            sw.Write(FormatFieldT(Duration, 6));
            sw.Write(FormatFieldA(Writer1LastName, 45));
            sw.Write(FormatFieldA(Writer1FirstName, 30));
            sw.Write(FormatFieldL(Writer1IpNameNr, 11));
            sw.Write(FormatFieldA(Writer2LastName, 45));
            sw.Write(FormatFieldA(Writer2FirstName, 30));
            sw.Write(FormatFieldL(Writer2IpNameNr, 11));
            sw.Write(FormatFieldL(Writer1IpBaseNr, 13));
            sw.Write(FormatFieldL(Writer2IpBaseNr, 13));
            return sw.ToString();
        }
    }
}
