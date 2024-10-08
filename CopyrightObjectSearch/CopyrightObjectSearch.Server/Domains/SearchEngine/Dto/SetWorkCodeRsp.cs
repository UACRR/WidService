using System.Security.Cryptography;

namespace CopyrightObjectSearch.Server
{
    public class SetWorkCodeRsp
    {
        public int ExternalObjectId { get; set; }
        public int ObjId { get; set; }
        public int Wic { get; set; }
        public string Iswc { get; set; }
        public string ErrorText { get; set; }

        public SetWorkCodeRsp()
        {
            ExternalObjectId = 0;
            ObjId = 0;
            Wic = 0;
            Iswc = "";
            ErrorText = "";
        }
    }
}
