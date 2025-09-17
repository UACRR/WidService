using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecOwt : BaseRecDetail
    {
        public string IpNr { get; set; }
        public string CollShrPR { get; set; }
        public string CollShrMR { get; set; }
        public string CollShrSR { get; set; }
        public string IncExcIndicator { get; set; }
        public string TISNumericCode { get; set; }
        public bool? SharesChange { get; set; }
        public string SeqNr { get; set; }

        public override void FromLine(string line)
        {
            IpNr = (string)ParseA(line.Substring(19, 9));
            CollShrPR = (string)ParseN(line.Substring(28, 5));
            CollShrMR = (string)ParseN(line.Substring(33, 5));
            CollShrSR = (string)ParseN(line.Substring(38, 5));
            IncExcIndicator = (string)ParseL(line.Substring(43, 1));
            TISNumericCode = (string)ParseL(line.Substring(44, 4));
            SharesChange = (bool?)ParseB(line.Substring(48, 1));
            SeqNr = (string)ParseN(line.Substring(49, 3));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("OWT");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(IpNr, 9));
            sw.Write(FormatFieldN(CollShrPR, 5));
            sw.Write(FormatFieldN(CollShrMR, 5));
            sw.Write(FormatFieldN(CollShrSR, 5));
            sw.Write(FormatFieldL(IncExcIndicator, 1));
            sw.Write(FormatFieldL(TISNumericCode, 4));
            sw.Write(FormatFieldB(SharesChange, 1));
            sw.Write(FormatFieldN(SeqNr, 3));
            return sw.ToString();
        }
    }
}
