using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecGrh : BaseRec
    {
        public string TranType { get; set; }
        public string GroupID { get; set; }
        public string VerNum { get; set; }
        public string BatchReq { get; set; }
        public string SubmDistType { get; set; }

        public RecGrt RecGrt { get; set; }
        public List<BaseRecTran> TranList { get; set; }

        public override void FromLine(string line)
        {
            TranType = (string)ParseL(line.Substring(3, 3));
            GroupID = (string)ParseN(line.Substring(6, 5));
            VerNum = (string)ParseA(line.Substring(11, 5));
            BatchReq = (string)ParseN(line.Substring(16, 10));
            SubmDistType = (string)ParseL(line.Substring(26, 2));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("GRH");
            sw.Write(FormatFieldL(TranType, 3));
            sw.Write(FormatFieldN(GroupID, 5));
            sw.Write(FormatFieldA(VerNum, 5));
            sw.Write(FormatFieldN(BatchReq, 10));
            sw.Write(FormatFieldL(SubmDistType, 2));
            return sw.ToString();
        }
    }
}
