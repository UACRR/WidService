using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecAlt : BaseRecDetail
    {
        public string AltTitle { get; set; }
        public string TitleType { get; set; }
        public string LangCode { get; set; }

        public override void FromLine(string line)
        {
            AltTitle = (string)ParseA(line.Substring(19, 60));
            TitleType = (string)ParseL(line.Substring(79, 2));
            LangCode = (string)ParseL(line.Substring(81, 2));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("ALT");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(AltTitle, 60));
            sw.Write(FormatFieldL(TitleType, 2));
            sw.Write(FormatFieldL(LangCode, 2));
            return sw.ToString();
        }
    }
}
