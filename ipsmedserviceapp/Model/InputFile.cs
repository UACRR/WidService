using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class InputFile
    {
        public InputFile()
        {
            CheckParamPays = new HashSet<CheckParamPays>();
            ExternalPay = new HashSet<ExternalPay>();
        }

        public int FileId { get; set; }
        public string AspId { get; set; }
        public string FileName { get; set; }
        public DateTime InputTime { get; set; }
        public int CountRows { get; set; }
        public int CountInput { get; set; }
        public int CountAutoLink { get; set; }

        public ICollection<CheckParamPays> CheckParamPays { get; set; }
        public ICollection<ExternalPay> ExternalPay { get; set; }
    }
}
