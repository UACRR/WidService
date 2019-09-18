using ipsFormsDesign.Dictionary;

namespace ipsFormsDesign.ViewModels.ObjectsRight
{
    public class ObjectRightForTransfering
    {
        public int ObjId { get; set; }
        public int? CRightId { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public decimal? RateRh { get; set; }
        public bool ManualDistribution { get; set; }

        public static explicit operator ObjectRightForTransfering(ObjectRightForRightholder sourceObject)
        {
            return new ObjectRightForTransfering
            {
                ObjId = sourceObject.ObjId,
                CRightId = sourceObject.CRightId,
                Name = sourceObject.Name,
                RoleName = sourceObject.RoleName,
                RateRh = sourceObject.RateRh,
                ManualDistribution = false,
            };
        }
    }
}
