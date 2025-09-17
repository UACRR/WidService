using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecIns : BaseRecDetail
    {
        public string VoicesNr { get; set; }
        public string InstrType { get; set; }
        public string InstrumentationDesc { get; set; }

        public override void FromLine(string line)
        {
            VoicesNr = (string)ParseN(line.Substring(19, 3));
            InstrType = (string)ParseL(line.Substring(22, 3));
            InstrumentationDesc = (string)ParseA(line.Substring(25, 50));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("INS");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldN(VoicesNr, 3));
            sw.Write(FormatFieldL(InstrType, 3));
            sw.Write(FormatFieldA(InstrumentationDesc, 50));
            return sw.ToString();
        }
    }
}
