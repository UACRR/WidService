using System;

namespace IPSModulesLibrary.CommunitiesList
{
    public class CommunitiesListModel
    {
        public int CustId { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public DateTime? RegistrDate { get; set; }
        public int CountAuthors { get; set; }
        public byte IsMy { get; set; }
    }
}
