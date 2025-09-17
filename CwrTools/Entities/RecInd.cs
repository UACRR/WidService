using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecInd : BaseRecDetail
    {
        public string InstrumentCode { get; set; }
        public string PlayersNr { get; set; }

        public override void FromLine(string line)
        {
            InstrumentCode = (string)ParseL(line.Substring(19, 3));
            PlayersNr = (string)ParseN(line.Substring(22, 3));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("IND");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldL(InstrumentCode, 3));
            sw.Write(FormatFieldN(PlayersNr, 3));
            return sw.ToString();
        }
    }
}
