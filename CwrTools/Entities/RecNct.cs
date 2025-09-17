using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecNct : BaseRecDetail
    {
        public string Title { get; set; }
        public string LangCode { get; set; }

        public override void FromLine(string line)
        {
            Title = (string)ParseA(line.Substring(19, 640));
            LangCode = (string)ParseL(line.Substring(659, 2));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("NCT");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(Title, 640));
            sw.Write(FormatFieldL(LangCode, 2));
            return sw.ToString();
        }
    }
}
