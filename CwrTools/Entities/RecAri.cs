using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecAri : BaseRecDetail
    {
        public string SocNr { get; set; }
        public string WorkNr { get; set; }
        public string RightType { get; set; }
        public string SubjCode { get; set; }
        public string Note { get; set; }

        public override void FromLine(string line)
        {
            SocNr = (string)ParseL(line.Substring(19, 3));
            WorkNr = (string)ParseA(line.Substring(22, 14));
            RightType = (string)ParseL(line.Substring(36, 3));
            SubjCode = (string)ParseL(line.Substring(39, 2));
            Note = (string)ParseA(line.Substring(41, 160));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("ARI");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldL(SocNr, 3));
            sw.Write(FormatFieldA(WorkNr, 14));
            sw.Write(FormatFieldL(RightType, 3));
            sw.Write(FormatFieldL(SubjCode, 2));
            sw.Write(FormatFieldA(Note, 160));
            return sw.ToString();
        }
    }
}
