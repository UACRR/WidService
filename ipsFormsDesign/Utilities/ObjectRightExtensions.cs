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

            foreach (var re in registerItem.RegisterExtraList)
            {
                objectRight.Authors.Add(new Authors { AuthorName = re.Name, FolkType = 1, RoleCode = re.RoleCode });
            }
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

            if (objectAuthorRightholder.IsRightholder && objectAuthorRightholder.Author.CustId.HasValue)
            {
                var copyRight = objectAuthorRightholder.CopyRight;
                copyRight.CustId = (int)objectAuthorRightholder.Author.CustId;
                copyRight.RoleCode = objectAuthorRightholder.Author.RoleCode;

                copyRight.LicAuthorBr = objectAuthorRightholder.LicAuthorBr;
                copyRight.WorkRh = objectAuthorRightholder.WorkRh;

                objectRight.CopyRight.Add(copyRight);
            }
        }

        public static List<ObjectAuthorRightholderBrViewModel> GetObjectBrAuthorRightholderList(this ObjectRight objectRight, IList<ViewCustomer> rightholderList = null)
        {
            var authorRightholderList = objectRight.Authors.Select(a =>
            {
                var foundedCopyright = objectRight.CopyRight.FirstOrDefault(c => c.CustId == a.CustId && c.RoleCode == a.RoleCode);
                var foundedRightholder = rightholderList?.FirstOrDefault(r => r.custId == a.CustId);

                return new ObjectAuthorRightholderBrViewModel
                {
                    Author = a,
                    IsRightholder = a.CustId.HasValue,
                    Country = foundedRightholder?.Country,
                    InnerCode = foundedRightholder?.InnerCode,
                    CopyRight = foundedCopyright ?? new CopyRight(),
                    LicAuthorBr = foundedCopyright?.LicAuthorBr ?? new LicAuthorBr(),
                    WorkRh = foundedCopyright?.WorkRh ?? new WorkRh(),
                };
            })
            .ToList();

            return authorRightholderList;
        }

        public static decimal GetTotalRate(this IList<CopyRight> copyrightList)
        {
            return copyrightList.Where(cr => cr.Rate != null).Sum(cr => (decimal)cr.Rate);
        }
    }
}
