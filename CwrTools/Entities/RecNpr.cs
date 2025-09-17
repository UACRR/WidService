using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecNpr : BaseRecDetail
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string IpNameNr { get; set; }
        public string IpBaseNr { get; set; }
        public string LangCode { get; set; }
        public string PerformanceLang { get; set; }
        public string PerformanceDialect { get; set; }

        public override void FromLine(string line)
        {
            Name = (string)ParseA(line.Substring(19, 160));
            FirstName = (string)ParseA(line.Substring(179, 160));
            IpNameNr = (string)ParseL(line.Substring(339, 11));
            IpBaseNr = (string)ParseL(line.Substring(350, 13));
            LangCode = (string)ParseL(line.Substring(363, 2));
            PerformanceLang = (string)ParseL(line.Substring(365, 2));
            PerformanceDialect = (string)ParseL(line.Substring(367, 3));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("NPR");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(Name, 160));
            sw.Write(FormatFieldA(FirstName, 160));
            sw.Write(FormatFieldL(IpNameNr, 11));
            sw.Write(FormatFieldL(IpBaseNr, 13));
            sw.Write(FormatFieldL(LangCode, 2));
            sw.Write(FormatFieldL(PerformanceLang, 2));
            sw.Write(FormatFieldL(PerformanceDialect, 3));
            return sw.ToString();
        }
    }
}
