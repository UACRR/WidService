using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecNat : BaseRecDetail
    {
        public string Title { get; set; }
        public string TitleType { get; set; }
        public string LangCode { get; set; }

        public override void FromLine(string line)
        {
            Title = (string)ParseA(line.Substring(19, 640));
            TitleType = (string)ParseL(line.Substring(659, 2));
            LangCode = (string)ParseL(line.Substring(661, 2));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("NAT");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(Title, 640));
            sw.Write(FormatFieldL(TitleType, 2));
            sw.Write(FormatFieldL(LangCode, 2));
            return sw.ToString();
        }
    }
}
