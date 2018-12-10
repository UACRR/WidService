using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class InputFile : IInputFile
    {
        public InputFile()
        {
            CheckParamPays = new ObservableListSource<CheckParamPays>();
        }

        public int UserId { get; set; }
        public string AspId { get; set; }
        public string FileName { get; set; }
        public DateTime InputTime { get; set; }
        public int CountRows { get; set; }
        public int CountInput { get; set; }
        public int CountAutoLink { get; set; }

        public AspNetUsers Asp { get; set; }
        public ObservableListSource<CheckParamPays> CheckParamPays { get; set; }
    }
}

