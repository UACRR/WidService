using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecIsw : BaseRecTran
    {
        public string WorkTitle { get; set; }
        public string LangCode { get; set; }
        public string SubmWorkNr { get; set; }
        public string ISWC { get; set; }
        public DateTime? CopyrightDate { get; set; }
        public string CopyrightNr { get; set; }
        public string MwDistCat { get; set; }
        public TimeSpan? Duration { get; set; }
        public char RecordedIndicator { get; set; }
        public string TextMusicRelationship { get; set; }
        public string CompType { get; set; }
        public string VersionType { get; set; }
        public string ExcerptType { get; set; }
        public string MusicArrangement { get; set; }
        public string LyricAdaptation { get; set; }
        public string ContactName { get; set; }
        public string ContactID { get; set; }
        public string CWRWorkType { get; set; }
        public bool? GrandRightsInd { get; set; }
        public string CompCount { get; set; }
        public DateTime? PrintedEdPubDate { get; set; }
        public char? ExceptionalClause { get; set; }
        public string OpusNr { get; set; }
        public string CatalogueNr { get; set; }
        public char? PriorityFlag { get; set; }

        public override void FromLine(string line)
        {
            WorkTitle = (string)ParseA(line.Substring(19, 60));
            LangCode = (string)ParseL(line.Substring(79, 2));
            SubmWorkNr = (string)ParseA(line.Substring(81, 14));
            ISWC = (string)ParseA(line.Substring(95, 11));
            CopyrightDate = (DateTime?)ParseD(line.Substring(106, 8));
            CopyrightNr = (string)ParseA(line.Substring(114, 12));
            MwDistCat = (string)ParseL(line.Substring(126, 3));
            Duration = (TimeSpan?)ParseT(line.Substring(129, 6));
            RecordedIndicator = (char)ParseF(line.Substring(135, 1));
            TextMusicRelationship = (string)ParseL(line.Substring(136, 3));
            CompType = (string)ParseL(line.Substring(139, 3));
            VersionType = (string)ParseL(line.Substring(142, 3));
            ExcerptType = (string)ParseL(line.Substring(145, 3));
            MusicArrangement = (string)ParseL(line.Substring(148, 3));
            LyricAdaptation = (string)ParseL(line.Substring(151, 3));
            ContactName = (string)ParseA(line.Substring(154, 30));
            ContactID = (string)ParseA(line.Substring(184, 10));
            CWRWorkType = (string)ParseL(line.Substring(194, 2));
            GrandRightsInd = (bool?)ParseB(line.Substring(196, 1));
            CompCount = (string)ParseN(line.Substring(197, 3));
            PrintedEdPubDate = (DateTime?)ParseD(line.Substring(200, 8));
            ExceptionalClause = (char?)ParseF(line.Substring(208, 1));
            OpusNr = (string)ParseA(line.Substring(209, 25));
            CatalogueNr = (string)ParseA(line.Substring(234, 25));
            PriorityFlag = (char?)ParseF(line.Substring(259, 1));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("ISW");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(WorkTitle, 60));
            sw.Write(FormatFieldL(LangCode, 2));
            sw.Write(FormatFieldA(SubmWorkNr, 14));
            sw.Write(FormatFieldA(ISWC, 11));
            sw.Write(FormatFieldD(CopyrightDate, 8));
            sw.Write(FormatFieldA(CopyrightNr, 12));
            sw.Write(FormatFieldL(MwDistCat, 3));
            sw.Write(FormatFieldT(Duration, 6));
            sw.Write(FormatFieldF(RecordedIndicator, 1));
            sw.Write(FormatFieldL(TextMusicRelationship, 3));
            sw.Write(FormatFieldL(CompType, 3));
            sw.Write(FormatFieldL(VersionType, 3));
            sw.Write(FormatFieldL(ExcerptType, 3));
            sw.Write(FormatFieldL(MusicArrangement, 3));
            sw.Write(FormatFieldL(LyricAdaptation, 3));
            sw.Write(FormatFieldA(ContactName, 30));
            sw.Write(FormatFieldA(ContactID, 10));
            sw.Write(FormatFieldL(CWRWorkType, 2));
            sw.Write(FormatFieldB(GrandRightsInd, 1));
            sw.Write(FormatFieldN(CompCount, 3));
            sw.Write(FormatFieldD(PrintedEdPubDate, 8));
            sw.Write(FormatFieldF(ExceptionalClause, 1));
            sw.Write(FormatFieldA(OpusNr, 25));
            sw.Write(FormatFieldA(CatalogueNr, 25));
            sw.Write(FormatFieldF(PriorityFlag, 1));
            return sw.ToString();
        }
    }
}
