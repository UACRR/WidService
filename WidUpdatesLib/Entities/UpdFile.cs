using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidUpdatesLib.Entities
{
    [Table("UpdFiles")]
    public class UpdFile
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "varchar(32)")] public string Name { get; set; }
        [Column(TypeName = "int")] public int Year { get; set; }
        [Column(TypeName = "int")] public int Month { get; set; }
        [Column(TypeName = "int")] public int Day { get; set; }

        public ICollection<RecAck> RecAckLst { get; set; }
        public ICollection<RecAlt> RecAltLst { get; set; }
        public ICollection<RecCom> RecComLst { get; set; }
        public ICollection<RecCon> RecConLst { get; set; }
        public ICollection<RecDel> RecDelLst { get; set; }
        public ICollection<RecEwt> RecEwtLst { get; set; }
        public ICollection<RecInd> RecIndLst { get; set; }
        public ICollection<RecIns> RecInsLst { get; set; }
        public ICollection<RecIsw> RecIswLst { get; set; }
        public ICollection<RecLnk> RecLnkLst { get; set; }
        public ICollection<RecMsg> RecMsgLst { get; set; }
        public ICollection<RecOip> RecOipLst { get; set; }
        public ICollection<RecOrn> RecOrnLst { get; set; }
        public ICollection<RecOsr> RecOsrLst { get; set; }
        public ICollection<RecPer> RecPerLst { get; set; }
        public ICollection<RecRes> RecResLst { get; set; }
        public ICollection<RecSip> RecSipLst { get; set; }
        public ICollection<RecSoc> RecSocLst { get; set; }
        public ICollection<RecSsr> RecSsrLst { get; set; }
        public ICollection<RecTtu> RecTtuLst { get; set; }
        public ICollection<RecVer> RecVerLst { get; set; }
        public ICollection<RecWia> RecWiaLst { get; set; }
        public ICollection<RecWiu> RecWiuLst { get; set; }
        public ICollection<RecWpl> RecWplLst { get; set; }
    }
}
