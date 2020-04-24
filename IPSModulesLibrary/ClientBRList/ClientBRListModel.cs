using ipsFormsDesign.Interfaces;

namespace IPSModulesLibrary.ClientBRList
{
    public class ClientBRListModel: ConsumerBigRightView
    {
        public int StatusMasterActive { get; set; }
        public int StatusMasterNoactive { get; set; }
        public int StatusMasterProlong { get; set; }
        public int StatusUndistribute { get; set; }
    }
}
