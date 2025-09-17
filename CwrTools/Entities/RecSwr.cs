using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecSwr : BaseRecDetail
    {
        public string IpNr { get; set; }
        public string WriterLastName { get; set; }
        public string WriterFirstName { get; set; }
        public char? WriterUnknownIndicator { get; set; }
        public string WriterDesignationCode { get; set; }
        public string TaxIDNr { get; set; }
        public string WriterIpNameNr { get; set; }
        public string AffSocNrPR { get; set; }
        public string OwnShrPR { get; set; }
        public string SocMR { get; set; }
        public string OwnShrMR { get; set; }
        public string SocSR { get; set; }
        public string OwnShrSR { get; set; }
        public char? SpecFieldsRevInd { get; set; }
        public bool? FirstRecordingRefusalInd { get; set; }
        public bool? WorkForHireIndicator { get; set; }
        public string Filler { get; set; }
        public string WriterIpBaseNr { get; set; }
        public string PersonalNr { get; set; }
        public string LicenseIndUSA { get; set; }

        public override void FromLine(string line)
        {
            IpNr = (string)ParseA(line.Substring(19, 9));
            WriterLastName = (string)ParseA(line.Substring(28, 45));
            WriterFirstName = (string)ParseA(line.Substring(73, 30));
            WriterUnknownIndicator = (char?)ParseF(line.Substring(103, 1));
            WriterDesignationCode = (string)ParseL(line.Substring(104, 2));
            TaxIDNr = (string)ParseA(line.Substring(106, 9));
            WriterIpNameNr = (string)ParseL(line.Substring(115, 11));
            AffSocNrPR = (string)ParseL(line.Substring(126, 3));
            OwnShrPR = (string)ParseN(line.Substring(129, 5));
            SocMR = (string)ParseL(line.Substring(134, 3));
            OwnShrMR = (string)ParseN(line.Substring(137, 5));
            SocSR = (string)ParseL(line.Substring(142, 3));
            OwnShrSR = (string)ParseN(line.Substring(145, 5));
            SpecFieldsRevInd = (char?)ParseF(line.Substring(150, 1));
            FirstRecordingRefusalInd = (bool?)ParseB(line.Substring(151, 1));
            WorkForHireIndicator = (bool?)ParseB(line.Substring(152, 1));
            Filler = (string)ParseA(line.Substring(153, 1));
            WriterIpBaseNr = (string)ParseL(line.Substring(154, 13));
            PersonalNr = (string)ParseN(line.Substring(167, 12));
            LicenseIndUSA = (string)ParseL(line.Substring(179, 1));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("SWR");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(IpNr, 9));
            sw.Write(FormatFieldA(WriterLastName, 45));
            sw.Write(FormatFieldA(WriterFirstName, 30));
            sw.Write(FormatFieldF(WriterUnknownIndicator, 1));
            sw.Write(FormatFieldL(WriterDesignationCode, 2));
            sw.Write(FormatFieldA(TaxIDNr, 9));
            sw.Write(FormatFieldL(WriterIpNameNr, 11));
            sw.Write(FormatFieldL(AffSocNrPR, 3));
            sw.Write(FormatFieldN(OwnShrPR, 5));
            sw.Write(FormatFieldL(SocMR, 3));
            sw.Write(FormatFieldN(OwnShrMR, 5));
            sw.Write(FormatFieldL(SocSR, 3));
            sw.Write(FormatFieldN(OwnShrSR, 5));
            sw.Write(FormatFieldF(SpecFieldsRevInd, 1));
            sw.Write(FormatFieldB(FirstRecordingRefusalInd, 1));
            sw.Write(FormatFieldB(WorkForHireIndicator, 1));
            sw.Write(FormatFieldA(Filler, 1));
            sw.Write(FormatFieldL(WriterIpBaseNr, 13));
            sw.Write(FormatFieldN(PersonalNr, 12));
            sw.Write(FormatFieldL(LicenseIndUSA, 1));
            return sw.ToString();
        }
    }
}
