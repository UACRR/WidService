using System;
using System.Collections.Generic;
using System.Text;

namespace IpsCommonTypes.Types
{
    public class SetsList<TFirst, TSecond>
    {
        public TFirst FirstItem { get; set; }
        public TSecond SecondItem { get; set; }
    }
}
