using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecOrn : BaseRecDetail
    {
        public string IntendedPurpose { get; set; }
        public string ProductionTitle { get; set; }
        public string CDID { get; set; }
        public string CutNr { get; set; }
        public string Library { get; set; }
        public string BLTVR { get; set; }
        public string Filler { get; set; }
        public string ProductionNr { get; set; }
        public string EpisodeTitle { get; set; }
        public string EpisodeNr { get; set; }
        public string ProductionYear { get; set; }
        public string AVISocCode { get; set; }
        public string AudioVisualNr { get; set; }
        public string VISAN { get; set; }
        public string Episode { get; set; }
        public string CheckDigit1 { get; set; }
        public string Version { get; set; }
        public string CheckDigit2 { get; set; }
        public string VersionSegmentEIDR { get; set; }
        public string RootNumberCheckDigit { get; set; }

        public override void FromLine(string line)
        {
            IntendedPurpose = (string)ParseL(line.Substring(19, 3));
            ProductionTitle = (string)ParseA(line.Substring(22, 60));
            CDID = (string)ParseA(line.Substring(82, 15));
            CutNr = (string)ParseN(line.Substring(97, 4));
            Library = (string)ParseA(line.Substring(101, 60));
            BLTVR = (string)ParseA(line.Substring(161, 1));
            Filler = (string)ParseN(line.Substring(162, 25));
            ProductionNr = (string)ParseA(line.Substring(187, 12));
            EpisodeTitle = (string)ParseA(line.Substring(199, 60));
            EpisodeNr = (string)ParseA(line.Substring(259, 20));
            ProductionYear = (string)ParseN(line.Substring(279, 4));
            AVISocCode = (string)ParseN(line.Substring(283, 3));
            AudioVisualNr = (string)ParseA(line.Substring(286, 15));
            VISAN = (string)ParseA(line.Substring(301, 12));
            Episode = (string)ParseA(line.Substring(313, 4));
            CheckDigit1 = (string)ParseA(line.Substring(317, 1));
            Version = (string)ParseA(line.Substring(318, 8));
            CheckDigit2 = (string)ParseA(line.Substring(326, 1));
            VersionSegmentEIDR = (string)ParseA(line.Substring(327, 20));
            RootNumberCheckDigit = (string)ParseA(line.Substring(347, 1));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("ORN");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldL(IntendedPurpose, 3));
            sw.Write(FormatFieldA(ProductionTitle, 60));
            sw.Write(FormatFieldA(CDID, 15));
            sw.Write(FormatFieldN(CutNr, 4));
            sw.Write(FormatFieldA(Library, 60));
            sw.Write(FormatFieldA(BLTVR, 1));
            sw.Write(FormatFieldN(Filler, 25));
            sw.Write(FormatFieldA(ProductionNr, 12));
            sw.Write(FormatFieldA(EpisodeTitle, 60));
            sw.Write(FormatFieldA(EpisodeNr, 20));
            sw.Write(FormatFieldN(ProductionYear, 4));
            sw.Write(FormatFieldN(AVISocCode, 3));
            sw.Write(FormatFieldA(AudioVisualNr, 15));
            sw.Write(FormatFieldA(VISAN, 12));
            sw.Write(FormatFieldA(Episode, 4));
            sw.Write(FormatFieldA(CheckDigit1, 1));
            sw.Write(FormatFieldA(Version, 8));
            sw.Write(FormatFieldA(CheckDigit2, 1));
            sw.Write(FormatFieldA(VersionSegmentEIDR, 20));
            sw.Write(FormatFieldA(RootNumberCheckDigit, 1));
            return sw.ToString();
        }
    }
}
