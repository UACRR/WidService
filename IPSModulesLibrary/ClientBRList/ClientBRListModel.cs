using ipsFormsDesign.Interfaces;

namespace IPSModulesLibrary.ClientBRList
{
    public class ClientBRListModel: ConsumerBigRightView
    {
        public int StatusMasterActive { get; set; }
        public int StatusMasterNoactive { get; set; }
        public int StatusMasterProlong { get; set; }
        public int StatusUndistribute { get; set; }
        public int StatusLic1Active { get; set; }
        public int StatusLic1NoActive { get; set; }
        public int StatusLic1ToProlong { get; set; }
        public int StatusLic2Active { get; set; }
        public int StatusLic2NoActive { get; set; }
        public int StatusLic3Active { get; set; }
        public int StatusLic3NoActive { get; set; }
    }
}
