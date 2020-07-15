using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Utilities;

namespace IpsViewComponentLibrary.ControlsHelpers.Base
{
    public abstract class LicenseBRHelper
    {
        public ICollection<RegisterItemViewModel> MusicalDesignList { get; set; }
        public ICollection<ObjectAuthorRightholderBrViewModel> AuthorRightholderBrList { get; set; }

        public virtual LicenseAgreement LicenseAgreement { get; set; }

        private LicenseAgrParam _licenseAgrParam;
        public LicenseAgrParam LicenseAgrParam
        {
            get
            {
                if (LicenseAgreement != null)
                {
                    var licenseAgrParam = LicenseAgreement.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == LicenseAgreement.LicVersion);
                    _licenseAgrParam = licenseAgrParam;
                }

                return _licenseAgrParam;
            }
            protected set => _licenseAgrParam = value;
        }

        public ObjectRight ObjectRight => LicenseAgrParam.LicenseBigR.Obj;

        public ICollection<ClnBusinessPlace> ClnBusinessPlaceList { get; set; }

        public int CustId { get; set; }
        public int AgrId { get; set; }

        public abstract Task<bool> SaveAsync();

        protected void ParseAuthors()
        {
            // map from single table to Authors, Copyright, LicAuthorBr and WorkRh tables
            ObjectRight.Authors.Clear();
            ObjectRight.CopyRight.Clear();

            foreach (var authorRightholder in AuthorRightholderBrList)
            {
                if (string.IsNullOrEmpty(authorRightholder.Author.AuthorName))
                    continue;

                ObjectRight.AddObjectBrAuthorRightholder(authorRightholder);

                var licAuthorBr = LicenseAgrParam.LicenseBigR.LicAuthorBr.FirstOrDefault(rec => rec.CRightId == authorRightholder.CopyRight.CRightId);
                if (licAuthorBr == null)
                {
                    LicenseAgrParam.LicenseBigR.LicAuthorBr.Add(new LicAuthorBr
                    {
                        CRightId = authorRightholder.CopyRight.CRightId,
                        CustIdRh = authorRightholder.CopyRight.CustId,
                        LicId = LicenseAgreement.LicId,
                        LicVersion = 1,
                        PrepayType = authorRightholder.LicAuthorBr.PrepayType,
                        PrepaySum = authorRightholder.LicAuthorBr.PrepaySum,
                        PrepaySumAuthor = authorRightholder.LicAuthorBr.PrepaySumAuthor,
                        R030 = authorRightholder.LicAuthorBr.R030,
                    });
                }
            }
        }

        protected void ParseMusicalDisign()
        {
            var licenseAgrParam = LicenseAgreement.LicenseAgrParam.Single(rec => rec.LicVersion == LicenseAgreement.LicVersion);

            // TODO: мб надлишкова дія, перевірити 
            licenseAgrParam.LicenseBigR.MusicalDesign.Clear();
            //if(MusicalDesignList.Any())
            foreach (var item in MusicalDesignList)
            {
                if (!CheckMusicalDesignEmptyObject(item))
                    continue;

                var musicalDesign = new MusicalDesign
                {
                    MdId = item.MdId,
                    LicId = item.LicId,
                    Objid = item.ObjId,
                    ObjName = item.ItemName,
                    NameSinger = item.Performer,
                    NameMusician = item.AuthorMusic,
                    Duration = item.DurationItem,
                    NumbPerfom = item.CountUse,
                    AuthorText = item.AuthorText,
                };

                musicalDesign.LicId = LicenseAgreement.LicId;

                licenseAgrParam.LicenseBigR.MusicalDesign.Add(musicalDesign);
            }
        }

        /// <summary>
        /// Перевірка об'єкта на наявність хоча б однї необхідної властивості для збереження цього об'єкта.
        /// True - об'єкт можна записати, False - об'єкт не містить необхідних для запису даних.
        /// </summary>
        /// <param name="item">Об'єкт музичного оформлення</param>
        /// <returns>Результат перевірки об'єкта</returns>
        private static bool CheckMusicalDesignEmptyObject(RegisterItemViewModel item)
        {
            return !(string.IsNullOrEmpty(item.AuthorMusic)
                     && string.IsNullOrEmpty(item.AuthorText)
                     && string.IsNullOrEmpty(item.Performer)
                     && string.IsNullOrEmpty(item.ItemName)
                     && item.CountUse == null
                     && item.DurationItem == null);
        }
    }
}
