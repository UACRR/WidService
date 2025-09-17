using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecVer : BaseRecDetail
    {
        public string OrigWorkTitle { get; set; }
        public string OriglWorkISWC { get; set; }
        public string LangCode { get; set; }
        public string Writer1LastName { get; set; }
        public string Writer1FirstName { get; set; }
        public string Source { get; set; }
        public string IpNameNr { get; set; }
        public string Writer1IpBaseNr { get; set; }
        public string Writer2LastName { get; set; }
        public string Writer2FirstName { get; set; }
        public string Writer2IpNameNr { get; set; }
        public string Writer2IpBaseNr { get; set; }
        public string SubmWorkNr { get; set; }

        public override void FromLine(string line)
        {
            OrigWorkTitle = (string)ParseA(line.Substring(19, 60));
            OriglWorkISWC = (string)ParseA(line.Substring(79, 11));
            LangCode = (string)ParseL(line.Substring(90, 2));
            Writer1LastName = (string)ParseA(line.Substring(92, 45));
            Writer1FirstName = (string)ParseA(line.Substring(137, 30));
            Source = (string)ParseA(line.Substring(167, 60));
            IpNameNr = (string)ParseL(line.Substring(227, 11));
            Writer1IpBaseNr = (string)ParseL(line.Substring(238, 13));
            Writer2LastName = (string)ParseA(line.Substring(251, 45));
            Writer2FirstName = (string)ParseA(line.Substring(296, 30));
            Writer2IpNameNr = (string)ParseL(line.Substring(326, 11));
            Writer2IpBaseNr = (string)ParseL(line.Substring(337, 13));
            SubmWorkNr = (string)ParseA(line.Substring(350, 14));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("VER");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(OrigWorkTitle, 60));
            sw.Write(FormatFieldA(OriglWorkISWC, 11));
            sw.Write(FormatFieldL(LangCode, 2));
            sw.Write(FormatFieldA(Writer1LastName, 45));
            sw.Write(FormatFieldA(Writer1FirstName, 30));
            sw.Write(FormatFieldA(Source, 60));
            sw.Write(FormatFieldL(IpNameNr, 11));
            sw.Write(FormatFieldL(Writer1IpBaseNr, 13));
            sw.Write(FormatFieldA(Writer2LastName, 45));
            sw.Write(FormatFieldA(Writer2FirstName, 30));
            sw.Write(FormatFieldL(Writer2IpNameNr, 11));
            sw.Write(FormatFieldL(Writer2IpBaseNr, 13));
            sw.Write(FormatFieldA(SubmWorkNr, 14));
            return sw.ToString();
        }
    }
}
