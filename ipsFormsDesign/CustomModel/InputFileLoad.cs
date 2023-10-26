using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.CustomModel
{
    public class InputFileLoad : InputFile
    {
        public InputFileLoad()
        {
            Params = new Dictionary<CheckParamPays, ExternalPay>();
        }

        public Dictionary<CheckParamPays, ExternalPay> Params { get; set; }
    }
}
