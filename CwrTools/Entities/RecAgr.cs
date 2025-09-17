using System;
using System.Collections.Generic;
using System.IO;

namespace CwrTools
{
    public class RecAgr : BaseRecTran
    {
        public string SubmAgrNr { get; set; }
        public string AgrCode { get; set; }
        public string AgrType { get; set; }
        public DateTime AgrStartDate { get; set; }
        public DateTime? AgrEndDate { get; set; }
        public DateTime? RetentionEndDate { get; set; }
        public string PriorRoyaltyStatus { get; set; }
        public DateTime? PriorRoyaltyStartDate { get; set; }
        public string PtCollStatus { get; set; }
        public DateTime? PtCollEndDate { get; set; }
        public DateTime? AgrSignDate { get; set; }
        public string WorksNr { get; set; }
        public string SalesManufactureClause { get; set; }
        public bool? SharesChange { get; set; }
        public bool? AdvGived { get; set; }
        public string SocAgrNr { get; set; }

        public override void FromLine(string line)
        {
            SubmAgrNr = (string)ParseA(line.Substring(19, 14));
            AgrCode = (string)ParseA(line.Substring(33, 14));
            AgrType = (string)ParseL(line.Substring(47, 2));
            AgrStartDate = (DateTime)ParseD(line.Substring(49, 8));
            AgrEndDate = (DateTime?)ParseD(line.Substring(57, 8));
            RetentionEndDate = (DateTime?)ParseD(line.Substring(65, 8));
            PriorRoyaltyStatus = (string)ParseA(line.Substring(73, 1));
            PriorRoyaltyStartDate = (DateTime?)ParseD(line.Substring(74, 8));
            PtCollStatus = (string)ParseA(line.Substring(82, 1));
            PtCollEndDate = (DateTime?)ParseD(line.Substring(83, 8));
            AgrSignDate = (DateTime?)ParseD(line.Substring(91, 8));
            WorksNr = (string)ParseN(line.Substring(99, 5));
            SalesManufactureClause = (string)ParseL(line.Substring(104, 1));
            SharesChange = (bool?)ParseB(line.Substring(105, 1));
            AdvGived = (bool?)ParseB(line.Substring(106, 1));
            SocAgrNr = (string)ParseA(line.Substring(107, 14));
        }

        public override string ToFileLine(int tranSeqNr, int recSeqNr)
        {
            var sw = new StringWriter();
            sw.Write("AGR");
            sw.Write(FormatSeqNr(tranSeqNr, 8));
            sw.Write(FormatSeqNr(recSeqNr, 8));
            sw.Write(FormatFieldA(SubmAgrNr, 14));
            sw.Write(FormatFieldA(AgrCode, 14));
            sw.Write(FormatFieldL(AgrType, 2));
            sw.Write(FormatFieldD(AgrStartDate, 8));
            sw.Write(FormatFieldD(AgrEndDate, 8));
            sw.Write(FormatFieldD(RetentionEndDate, 8));
            sw.Write(FormatFieldA(PriorRoyaltyStatus, 1));
            sw.Write(FormatFieldD(PriorRoyaltyStartDate, 8));
            sw.Write(FormatFieldA(PtCollStatus, 1));
            sw.Write(FormatFieldD(PtCollEndDate, 8));
            sw.Write(FormatFieldD(AgrSignDate, 8));
            sw.Write(FormatFieldN(WorksNr, 5));
            sw.Write(FormatFieldL(SalesManufactureClause, 1));
            sw.Write(FormatFieldB(SharesChange, 1));
            sw.Write(FormatFieldB(AdvGived, 1));
            sw.Write(FormatFieldA(SocAgrNr, 14));
            return sw.ToString();
        }
    }
}
