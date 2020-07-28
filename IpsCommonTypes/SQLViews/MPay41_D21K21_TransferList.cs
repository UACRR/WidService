using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IpsCommonTypes.SQLViews
{
    [NotMapped]
    public class MPay41_D21K21_TransferList
    {
        public int Turnid { get; set; }
        public DateTime Datework { get; set; }
        public int Kindcode { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Rate { get; set; }
    }
}