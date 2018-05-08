using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    public interface IConsumerCompany : ICustCompany
    {
        IList<IClnBusinessPlace> clnBusinessPlaceList { get; set; }
        IList<IClnPlaceHoll> clnPlaceHoll { get; set; }
        IList<ILicPlaceHoll> licPlaceHoll { get; set; }
    }
}
