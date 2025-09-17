using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecMsg : BaseRecDetail
    {
        public string MsgType { get; set; }
        public string OrigRecSeqNr { get; set; }
        public string MsgLevel { get; set; }
        public string ValidationNrber { get; set; }
        public string MsgText { get; set; }

        public override void FromLine(string line)
        {
            MsgType = (string)ParseL(line.Substring(19, 1));
            OrigRecSeqNr = (string)ParseN(line.Substring(20, 8));
            MsgLevel = (string)ParseL(line.Substring(31, 1));
            ValidationNrber = (string)ParseA(line.Substring(32, 3));
            MsgText = (string)ParseA(line.Substring(35, 150));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("MSG");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldL(MsgType, 1));
            sw.Write(FormatFieldN(OrigRecSeqNr, 8));
            sw.Write(FormatFieldL(MsgLevel, 1));
            sw.Write(FormatFieldA(ValidationNrber, 3));
            sw.Write(FormatFieldA(MsgText, 150));
            return sw.ToString();
        }
    }
}
