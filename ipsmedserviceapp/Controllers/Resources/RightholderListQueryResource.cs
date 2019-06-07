
namespace ipsmedserviceapp.Controllers.Resources
{
    public class RightholderListQueryResource
    {
        public string SearchString { get; set; }
        public int? RightholderStatus { get; set; }
        public int? AgreementStatus { get; set; }
        public int? PageNumber { get; set; }
        public int? RowsPerPage { get; set; }
    }
}
