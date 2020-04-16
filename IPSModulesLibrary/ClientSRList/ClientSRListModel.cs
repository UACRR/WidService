using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSModulesLibrary.ClientSRList
{
    public class ClientSRListModel
    {
        public int? CustId { get; set; }
        public string INNOKPO { get; set; }
        public string Name { get; set; }
        public int? CountActive { get; set; }
        public int? CountNoAccept { get; set; }
        public float UndistribAmount { get; set; }
        public float AmountBorg { get; set; }
        public float UnattachAmount { get; set; }
        public byte StatusActive { get; set; }
        public byte StatusNoAccept { get; set; }
        public byte StatusForAccept { get; set; }
        public byte StatusProlong { get; set; }
        public byte StatusUndistribute { get; set; }
        public byte RgStatusOk { get; set; }
        public byte RgStatusRefuse { get; set; }
        public byte StatusBorg { get; set; }
        public byte StatusNoReport { get; set; }
        public byte StatusNoMoney { get; set; }
        public byte StatusUnattach { get; set; }
        public byte StatusClose { get; set; }

    }
}
