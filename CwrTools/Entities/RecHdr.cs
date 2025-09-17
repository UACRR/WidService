using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecHdr : BaseRec
    {
        public string SenderType { get; set; }
        public string SenderID { get; set; }
        public string SenderName { get; set; }
        public string EDIVerNr { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan CreationTime { get; set; }
        public DateTime TransmissionDate { get; set; }

        public RecTrl RecTrl { get; set; }
        public List<RecGrh> GroupList { get; set; }

        public override void FromLine(string line)
        {
            SenderType = (string)ParseA(line.Substring(3, 2));
            SenderID = (string)ParseN(line.Substring(5, 9));
            SenderName = (string)ParseA(line.Substring(14, 45));
            EDIVerNr = (string)ParseA(line.Substring(59, 5));
            CreationDate = (DateTime)ParseD(line.Substring(64, 8));
            CreationTime = (TimeSpan)ParseT(line.Substring(72, 6));
            TransmissionDate = (DateTime)ParseD(line.Substring(78, 8));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("HDR");
            sw.Write(FormatFieldA(SenderType, 2));
            sw.Write(FormatFieldN(SenderID, 9));
            sw.Write(FormatFieldA(SenderName, 45));
            sw.Write(FormatFieldA(EDIVerNr, 5));
            sw.Write(FormatFieldD(CreationDate, 8));
            sw.Write(FormatFieldT(CreationTime, 6));
            sw.Write(FormatFieldD(TransmissionDate, 8));
            return sw.ToString();
        }
    }
}
