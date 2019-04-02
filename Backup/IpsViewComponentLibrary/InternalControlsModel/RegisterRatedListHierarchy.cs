namespace IpsViewComponentLibrary.InternalControlsModel
{
    public class ParentTemplate: MusicDesignHeaderInfo
    {
        public int? ObjId { get; set; }
        public int? RegId { get; set; }
        public decimal PrepaySumAuthor { get; set; }
        public decimal? AvanseRest { get; set; }
    }

    public class ChildTemplate
    {
        public int? ObjId { get; set; }
        public int CustId { get; set; }
        public string RoleName { get; set; }
        public string NameRh { get; set; }
        public decimal? RoleRate { get; set; }
        public decimal? AmountDistributed { get; set; }
        public decimal AvanseUsed { get; set; }
    }
}