using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecSpu : BaseRecDetail
    {
        public string PublisherSequenceNr { get; set; }
        public string IpNr { get; set; }
        public string PublisherName { get; set; }
        public char? PublisherUnknownIndicator { get; set; }
        public string PublisherType { get; set; }
        public string TaxIDNr { get; set; }
        public string PublisherIPNameNr { get; set; }
        public string SubmAgrNr { get; set; }
        public string AffSocNrPR { get; set; }
        public string OwnShrPR { get; set; }
        public string SocMR { get; set; }
        public string OwnShrMR { get; set; }
        public string SocSR { get; set; }
        public string OwnShrSR { get; set; }
        public string SpecAgrInd { get; set; }
        public char? FirstRecordingRefusalInd { get; set; }
        public string Filler { get; set; }
        public string PublisherIPBaseNr { get; set; }
        public string AgrCode { get; set; }
        public string SocAgrNr { get; set; }
        public string AgrType { get; set; }
        public string LicenseIndUSA { get; set; }

        public override void FromLine(string line)
        {
            PublisherSequenceNr = (string)ParseN(line.Substring(19, 2));
            IpNr = (string)ParseA(line.Substring(21, 9));
            PublisherName = (string)ParseA(line.Substring(30, 45));
            PublisherUnknownIndicator = (char?)ParseF(line.Substring(75, 1));
            PublisherType = (string)ParseL(line.Substring(76, 2));
            TaxIDNr = (string)ParseA(line.Substring(78, 9));
            PublisherIPNameNr = (string)ParseL(line.Substring(87, 11));
            SubmAgrNr = (string)ParseA(line.Substring(98, 14));
            AffSocNrPR = (string)ParseL(line.Substring(112, 3));
            OwnShrPR = (string)ParseN(line.Substring(115, 5));
            SocMR = (string)ParseL(line.Substring(120, 3));
            OwnShrMR = (string)ParseN(line.Substring(123, 5));
            SocSR = (string)ParseL(line.Substring(128, 3));
            OwnShrSR = (string)ParseN(line.Substring(131, 5));
            SpecAgrInd = (string)ParseL(line.Substring(136, 1));
            FirstRecordingRefusalInd = (char?)ParseF(line.Substring(137, 1));
            Filler = (string)ParseA(line.Substring(138, 1));
            PublisherIPBaseNr = (string)ParseL(line.Substring(139, 13));
            AgrCode = (string)ParseA(line.Substring(152, 14));
            SocAgrNr = (string)ParseA(line.Substring(166, 14));
            AgrType = (string)ParseL(line.Substring(180, 2));
            LicenseIndUSA = (string)ParseL(line.Substring(182, 1));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("SPU");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldN(PublisherSequenceNr, 2));
            sw.Write(FormatFieldA(IpNr, 9));
            sw.Write(FormatFieldA(PublisherName, 45));
            sw.Write(FormatFieldF(PublisherUnknownIndicator, 1));
            sw.Write(FormatFieldL(PublisherType, 2));
            sw.Write(FormatFieldA(TaxIDNr, 9));
            sw.Write(FormatFieldL(PublisherIPNameNr, 11));
            sw.Write(FormatFieldA(SubmAgrNr, 14));
            sw.Write(FormatFieldL(AffSocNrPR, 3));
            sw.Write(FormatFieldN(OwnShrPR, 5));
            sw.Write(FormatFieldL(SocMR, 3));
            sw.Write(FormatFieldN(OwnShrMR, 5));
            sw.Write(FormatFieldL(SocSR, 3));
            sw.Write(FormatFieldN(OwnShrSR, 5));
            sw.Write(FormatFieldL(SpecAgrInd, 1));
            sw.Write(FormatFieldF(FirstRecordingRefusalInd, 1));
            sw.Write(FormatFieldA(Filler, 1));
            sw.Write(FormatFieldL(PublisherIPBaseNr, 13));
            sw.Write(FormatFieldA(AgrCode, 14));
            sw.Write(FormatFieldA(SocAgrNr, 14));
            sw.Write(FormatFieldL(AgrType, 2));
            sw.Write(FormatFieldL(LicenseIndUSA, 1));
            return sw.ToString();
        }
    }
}
