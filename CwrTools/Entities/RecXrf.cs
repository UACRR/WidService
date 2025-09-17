using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecXrf : BaseRecDetail
    {
        public string OrgCode { get; set; }
        public string Identifier { get; set; }
        public string IdentifierType { get; set; }
        public char Validity { get; set; }

        public override void FromLine(string line)
        {
            OrgCode = (string)ParseL(line.Substring(19, 3));
            Identifier = (string)ParseA(line.Substring(22, 14));
            IdentifierType = (string)ParseL(line.Substring(36, 1));
            Validity = (char)ParseF(line.Substring(37, 1));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("XRF");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldL(OrgCode, 3));
            sw.Write(FormatFieldA(Identifier, 14));
            sw.Write(FormatFieldL(IdentifierType, 1));
            sw.Write(FormatFieldF(Validity, 1));
            return sw.ToString();
        }
    }
}
