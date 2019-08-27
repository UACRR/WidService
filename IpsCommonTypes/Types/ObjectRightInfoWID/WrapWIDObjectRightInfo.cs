using System.Collections.Generic;

namespace IpsCommonTypes.Types.ObjectRightInfoWID
{
    public class WrapWIDObjectRightInfo
    {
        public WIDObjectRight WIDObjectRight { get; set; }
        public List<WIDObjectAuthors> WIDObjectAuthors { get; set; }
        public List<WIDObjectAuthorsCommunities> WIDObjectAuthorsCommunities { get; set; } 
        public List<WIDObjectAlternativeNames> WIDObjectAlternativeNames { get; set; } 
        public List<WIDObjectPerformers> WIDObjectPerformers { get; set; }
    }
}
