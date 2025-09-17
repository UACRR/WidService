using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecTer : BaseRecDetail
    {
        public string IncExcIndicator { get; set; }
        public string TISNumericCode { get; set; }

        public override void FromLine(string line)
        {
            IncExcIndicator = (string)ParseL(line.Substring(19, 1));
            TISNumericCode = (string)ParseL(line.Substring(20, 4));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("TER");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldL(IncExcIndicator, 1));
            sw.Write(FormatFieldL(TISNumericCode, 4));
            return sw.ToString();
        }
    }
}
