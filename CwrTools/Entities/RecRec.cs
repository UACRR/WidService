using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecRec : BaseRecDetail
    {
        public DateTime? ReleaseDate { get; set; }
        public string Constant { get; set; }
        public TimeSpan? ReleaseDuration { get; set; }
        public string Constant1 { get; set; }
        public string AlbumTitle { get; set; }
        public string AlbumLabel { get; set; }
        public string ReleaseCatalogNr { get; set; }
        public string EAN { get; set; }
        public string ISRC { get; set; }
        public string RecordingFormat { get; set; }
        public string RecordingTechnique { get; set; }
        public string MediaType { get; set; }
        public string RecordingTitle { get; set; }
        public string VersionTitle { get; set; }
        public string Performer { get; set; }
        public string RecordLabel { get; set; }
        public string Validity { get; set; }
        public string RecordingID { get; set; }

        public override void FromLine(string line)
        {
            ReleaseDate = (DateTime?)ParseD(line.Substring(19, 8));
            Constant = (string)ParseA(line.Substring(27, 60));
            ReleaseDuration = (TimeSpan?)ParseT(line.Substring(87, 6));
            Constant1 = (string)ParseA(line.Substring(93, 5));
            AlbumTitle = (string)ParseA(line.Substring(98, 60));
            AlbumLabel = (string)ParseA(line.Substring(158, 60));
            ReleaseCatalogNr = (string)ParseA(line.Substring(218, 18));
            EAN = (string)ParseL(line.Substring(236, 13));
            ISRC = (string)ParseL(line.Substring(249, 12));
            RecordingFormat = (string)ParseL(line.Substring(261, 1));
            RecordingTechnique = (string)ParseL(line.Substring(262, 1));
            MediaType = (string)ParseL(line.Substring(263, 3));
            RecordingTitle = (string)ParseA(line.Substring(266, 60));
            VersionTitle = (string)ParseA(line.Substring(326, 60));
            Performer = (string)ParseA(line.Substring(386, 60));
            RecordLabel = (string)ParseA(line.Substring(446, 60));
            Validity = (string)ParseL(line.Substring(506, 20));
            RecordingID = (string)ParseA(line.Substring(526, 14));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("REC");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldD(ReleaseDate, 8));
            sw.Write(FormatFieldA(Constant, 60));
            sw.Write(FormatFieldT(ReleaseDuration, 6));
            sw.Write(FormatFieldA(Constant1, 5));
            sw.Write(FormatFieldA(AlbumTitle, 60));
            sw.Write(FormatFieldA(AlbumLabel, 60));
            sw.Write(FormatFieldA(ReleaseCatalogNr, 18));
            sw.Write(FormatFieldL(EAN, 13));
            sw.Write(FormatFieldL(ISRC, 12));
            sw.Write(FormatFieldL(RecordingFormat, 1));
            sw.Write(FormatFieldL(RecordingTechnique, 1));
            sw.Write(FormatFieldL(MediaType, 3));
            sw.Write(FormatFieldA(RecordingTitle, 60));
            sw.Write(FormatFieldA(VersionTitle, 60));
            sw.Write(FormatFieldA(Performer, 60));
            sw.Write(FormatFieldA(RecordLabel, 60));
            sw.Write(FormatFieldL(Validity, 20));
            sw.Write(FormatFieldA(RecordingID, 14));
            return sw.ToString();
        }
    }
}
