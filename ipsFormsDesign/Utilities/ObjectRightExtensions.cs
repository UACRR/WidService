using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using System.Collections.Generic;
using System.Linq;

namespace ipsFormsDesign.Utilities
{
    public static class ObjectRightExtensions
    {
        public static void SetDataFromRegisterItem(this ObjectRight objectRight, RegisterItemViewModel registerItem)
        {
            objectRight.Name = registerItem.ItemName;
            objectRight.MediaTrack.Duration = registerItem.DurationItem;

            if (!string.IsNullOrWhiteSpace(registerItem.AuthorMusic))
                objectRight.Authors.Add(new Authors { AuthorName = registerItem.AuthorMusic, FolkType = 1, RoleCode = 2 });

            if (!string.IsNullOrWhiteSpace(registerItem.AuthorText))
                objectRight.Authors.Add(new Authors { AuthorName = registerItem.AuthorText, FolkType = 1, RoleCode = 1 });

            if (!string.IsNullOrEmpty(registerItem.Performer))
                objectRight.SeekObject.Add(new SeekObject { CodeI = 2, Name = registerItem.Performer });
        }

        public static void AddObjectAuthorRightholder(this ObjectRight objectRight, ObjectAuthorRightholder objectAuthorRightholder)
        {
            var author = new Authors
            {
                AuthId = objectAuthorRightholder.AuthId,
                ObjId = objectAuthorRightholder.ObjId,
                FolkType = objectAuthorRightholder.FolkType,
                RoleCode = objectAuthorRightholder.RoleCode,
                CustId = objectAuthorRightholder.CustId,
                AuthorName = objectAuthorRightholder.AuthorName,
            };

            objectRight.Authors.Add(author);

            if (objectAuthorRightholder.IsRightholder)
            {
                var copyright = new CopyRight
                {
                    CRightId = objectAuthorRightholder.CRightId ?? 0,
                    CustId = (int)objectAuthorRightholder.CustId,
                    ObjId = objectAuthorRightholder.ObjId,
                    RoleCode = objectAuthorRightholder.RoleCode,
                    Rate = objectAuthorRightholder.Rate,
                    BeginDate = objectAuthorRightholder.BeginDate,
                    EndDate = objectAuthorRightholder.EndDate,
                    Status = objectAuthorRightholder.CopyrightStatus,
                };

                objectRight.CopyRight.Add(copyright);
            }
        }

        public static void AddObjectBrAuthorRightholder(this ObjectRight objectRight, ObjectAuthorRightholderBrViewModel objectAuthorRightholder)
        {
            objectRight.Authors.Add(objectAuthorRightholder.Author);

            var copyRight = objectAuthorRightholder.CopyRight;
            copyRight.CustId = (int)objectAuthorRightholder.Author.CustId;
            copyRight.RoleCode = objectAuthorRightholder.Author.RoleCode;

            copyRight.LicAuthorBr = objectAuthorRightholder.LicAuthorBr;
            copyRight.WorkRh = objectAuthorRightholder.WorkRh;

            objectRight.CopyRight.Add(objectAuthorRightholder.CopyRight);
        }

        public static decimal GetTotalRate(this IList<CopyRight> copyrightList)
        {
            return copyrightList.Where(cr => cr.Rate != null).Sum(cr => (decimal)cr.Rate);
        }
    }
}
