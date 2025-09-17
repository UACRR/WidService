using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecAck : BaseRecTran
    {
        public DateTime CreationDate { get; set; }
        public TimeSpan CreationTime { get; set; }
        public string OrigGroupID { get; set; }
        public string OrigTranSeqNr { get; set; }
        public string OrigTranType { get; set; }
        public string CreationTitle { get; set; }
        public string SubmCreationNr { get; set; }
        public string RecipientCreationNr { get; set; }
        public DateTime ProcessingDate { get; set; }
        public string TranStatus { get; set; }

        public override void FromLine(string line)
        {
            CreationDate = (DateTime)ParseD(line.Substring(19, 8));
            CreationTime = (TimeSpan)ParseT(line.Substring(27, 6));
            OrigGroupID = (string)ParseN(line.Substring(33, 5));
            OrigTranSeqNr = (string)ParseN(line.Substring(38, 8));
            OrigTranType = (string)ParseL(line.Substring(46, 3));
            CreationTitle = (string)ParseA(line.Substring(49, 60));
            SubmCreationNr = (string)ParseA(line.Substring(109, 20));
            RecipientCreationNr = (string)ParseA(line.Substring(129, 20));
            ProcessingDate = (DateTime)ParseD(line.Substring(149, 8));
            TranStatus = (string)ParseL(line.Substring(157, 2));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("ACK");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldD(CreationDate, 8));
            sw.Write(FormatFieldT(CreationTime, 6));
            sw.Write(FormatFieldN(OrigGroupID, 5));
            sw.Write(FormatFieldN(OrigTranSeqNr, 8));
            sw.Write(FormatFieldL(OrigTranType, 3));
            sw.Write(FormatFieldA(CreationTitle, 60));
            sw.Write(FormatFieldA(SubmCreationNr, 20));
            sw.Write(FormatFieldA(RecipientCreationNr, 20));
            sw.Write(FormatFieldD(ProcessingDate, 8));
            sw.Write(FormatFieldL(TranStatus, 2));
            return sw.ToString();
        }
    }
}
