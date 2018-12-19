using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CheckParamPays : ICheckParamPays
    {
        public int InputFileId { get; set; }
        public int CheckId { get; set; }
        public string MfoCorr { get; set; }
        public string AccountCorr { get; set; }
        public string OkpoCorr { get; set; }
        public string DocNum { get; set; }
        public DateTime DocDate { get; set; }
        public decimal SCredit { get; set; }
        public string Nplat { get; set; }
        public int? InputStatus { get; set; }
        public int? LinkStatus { get; set; }

        public InputFile InputFile { get; set; }
    }
}

