using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecIpa : BaseRecDetail
    {
        public string AgrRoleCode { get; set; }
        public string IpNameNr { get; set; }
        public string IpBaseNr { get; set; }
        public string IpNr { get; set; }
        public string IpLastName { get; set; }
        public string IpWriterFirstName { get; set; }
        public string AffSocPR { get; set; }
        public string ShrPR { get; set; }
        public string AffSocMR { get; set; }
        public string ShrMR { get; set; }
        public string AffSocSR { get; set; }
        public string ShareSR { get; set; }

        public override void FromLine(string line)
        {
            AgrRoleCode = (string)ParseL(line.Substring(19, 2));
            IpNameNr = (string)ParseL(line.Substring(21, 11));
            IpBaseNr = (string)ParseL(line.Substring(32, 13));
            IpNr = (string)ParseA(line.Substring(45, 9));
            IpLastName = (string)ParseA(line.Substring(54, 45));
            IpWriterFirstName = (string)ParseA(line.Substring(99, 30));
            AffSocPR = (string)ParseL(line.Substring(129, 3));
            ShrPR = (string)ParseN(line.Substring(132, 5));
            AffSocMR = (string)ParseL(line.Substring(137, 3));
            ShrMR = (string)ParseN(line.Substring(140, 5));
            AffSocSR = (string)ParseL(line.Substring(145, 3));
            ShareSR = (string)ParseN(line.Substring(148, 5));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("IPA");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldL(AgrRoleCode, 2));
            sw.Write(FormatFieldL(IpNameNr, 11));
            sw.Write(FormatFieldL(IpBaseNr, 13));
            sw.Write(FormatFieldA(IpNr, 9));
            sw.Write(FormatFieldA(IpLastName, 45));
            sw.Write(FormatFieldA(IpWriterFirstName, 30));
            sw.Write(FormatFieldL(AffSocPR, 3));
            sw.Write(FormatFieldN(ShrPR, 5));
            sw.Write(FormatFieldL(AffSocMR, 3));
            sw.Write(FormatFieldN(ShrMR, 5));
            sw.Write(FormatFieldL(AffSocSR, 3));
            sw.Write(FormatFieldN(ShareSR, 5));
            return sw.ToString();
        }
    }
}
