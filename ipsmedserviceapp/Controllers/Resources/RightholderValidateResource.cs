namespace ipsmedserviceapp.Controllers.Resources
{
    public class RightholderValidateResource
    {
        public int RowNum { get; set; }
        public string Name { get; set; }
        public string CreativeRole { get; set; }
        public decimal Rate { get; set; }
        public int? CustId { get; set; }
        public int? RoleId { get; set; }
    }
}
