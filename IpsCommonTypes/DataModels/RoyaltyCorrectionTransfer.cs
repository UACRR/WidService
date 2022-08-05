using System.Collections;
using System.Collections.Generic;
using IpsCommonTypes.SQLViews;

namespace IpsCommonTypes.DataModels
{
    public class RoyaltyCorrectionTransfer
    {
        public string ObjectRightName { get; set; }
        public string RightholderName { get; set; }
        public ICollection<MPay41_D21K21_TransferList> TransferList { get; set; }
    }
}
