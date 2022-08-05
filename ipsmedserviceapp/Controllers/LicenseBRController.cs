using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseBRController : Controller
    {
        private readonly MediaServiceContext _dbContext;

        public LicenseBRController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetLicenseBRList([FromBody] SearchModuleResource resource)
        {
            string query = "select t0.* from vTsk_1_BRAllDocs_wpf t0";
            List<FrameParam> frameParam = await _dbContext.FrameParam.Where(rec => rec.FrameCode == 7).ToListAsync();
            var result = await _dbContext.Database.GetItemsListAsync(query, frameParam, resource);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetLicenseAgreements([FromQuery] LicenseAgreementListResource query)
        {
            var queryText = "select * from vTsk_1_BRAllDocs";

            var conditions = new Collection<string>();
            if (query != null)
            {
                if (query.States.Any())
                {
                    conditions.Add($"licType in ({string.Join(", ", query.States)})");
                }
                if (query.Status.HasValue)
                {
                    conditions.Add($"licStatus = {query.Status.Value}");
                }

                if (conditions.Any())
                {
                    queryText = queryText + " where " + string.Join(" and ", conditions);
                }
            }

            var list = await _dbContext.getViewData(queryText, null);
            return Ok(list);
        }

        /// <summary>
        /// Створити нову заявку для великих прав
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("CreateLicenseBR")]
        public async Task<IActionResult> CreateLicenseBR([FromBody] LicenseAgreement source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var sourceLicenseAgrParam = source.LicenseAgrParam.Single();
                var sourceLicenseBigR = sourceLicenseAgrParam.LicenseBigR;

                var target = new LicenseAgreement
                {
                    LicVersion = 1,
                    LicType = 2,
                };

                target.SetFields(source, new[] { "LicId" });

                var targetLicenseAgrParam = new LicenseAgrParam
                {
                    LicVersion = 1,
                };
                targetLicenseAgrParam.SetFields(sourceLicenseAgrParam, new[] { "LicId" });

                target.LicenseAgrParam.Add(targetLicenseAgrParam);

                var sourceLicense = sourceLicenseAgrParam.License.Single();
                var targetLicense = new License();
                targetLicense.SetFields(sourceLicense,new []{ "LId" });
                targetLicenseAgrParam.License.Add(targetLicense);

                // умови ліцензії ВП
                targetLicenseAgrParam.LicenseBigR = new LicenseBigR
                {
                    LicVersion = 1,
                };
                var targetLicenseBigR = targetLicenseAgrParam.LicenseBigR;
                targetLicenseBigR.SetFields(sourceLicenseBigR, new[] { "LicId" });

                // збірна музика/музичне оформлення
                foreach (var sourceMusicalDesign in sourceLicenseBigR.MusicalDesign)
                {
                    var targetMusicalDesign = new MusicalDesign();
                    targetMusicalDesign.SetFields(sourceMusicalDesign, new[] { "MdId" });
                    targetLicenseBigR.MusicalDesign.Add(targetMusicalDesign);
                }

                // об'єкт права
                targetLicenseBigR.Obj = new ObjectRight();
                targetLicenseBigR.Obj.SetFields(sourceLicenseBigR.Obj, new[] { "ObjId" });

                // автори
                foreach (var sourceAuthor in sourceLicenseBigR.Obj.Authors)
                {
                    var targetAuthor = new Authors();
                    targetAuthor.SetFields(sourceAuthor, new[] { "AuthId" });
                    targetLicenseBigR.Obj.Authors.Add(targetAuthor);
                }

                // копірайти
                foreach (var sourceCopyRight in sourceLicenseBigR.Obj.CopyRight)
                {
                    var targetCopyRight = new CopyRight();
                    targetCopyRight.SetFields(sourceCopyRight);
                    targetLicenseBigR.Obj.CopyRight.Add(targetCopyRight);
                }

                // змінюється в службі розподілу:
                // WorkRh
                // LicAuthorBr

                BalanceRate(targetLicenseBigR, targetLicenseAgrParam.LicenseBigR.Obj.CopyRight);

                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.LicenseAgreement.AddAsync(target);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                
                return Ok(ResponseOfRequest.Success());
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return Ok(ResponseOfRequest.NotSuccess(e));
            }
        }

        [HttpPut("UpdateLicenseBR")]
        public async Task<IActionResult> UpdateLicenseBR([FromBody] LicenseAgreement source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var sourceLicenseAgrParam = source.LicenseAgrParam.Single(rec => rec.LicVersion == source.LicVersion);
                var sourceLicenseBigR = sourceLicenseAgrParam.LicenseBigR;

                var target = await _dbContext.LicenseAgreement
                    .SingleAsync(rec => rec.LicId == source.LicId);

                #region load data

                await _dbContext.Entry(target)
                    .Collection(item => item.LicenseAgrParam).Query()
                    .Where(rec => rec.LicVersion == target.LicVersion).LoadAsync();

                var targetLicenseAgrParam = target.LicenseAgrParam.Single(rec => rec.LicVersion == target.LicVersion);

                await _dbContext.Entry(targetLicenseAgrParam)
                    .Collection(item => item.License).Query()
                    .LoadAsync();

                await _dbContext.Entry(targetLicenseAgrParam)
                    .Reference(item => item.LicenseBigR).Query()
                    .LoadAsync();

                await _dbContext.Entry(targetLicenseAgrParam.LicenseBigR)
                    .Collection(item => item.MusicalDesign).Query()
                    .LoadAsync();

                await _dbContext.Entry(targetLicenseAgrParam.LicenseBigR)
                    .Collection(item => item.LicAuthorBr).Query()
                    .LoadAsync();

                await _dbContext.Entry(targetLicenseAgrParam.LicenseBigR)
                    .Reference(item => item.Obj).Query()
                    .LoadAsync();

                await _dbContext.Entry(targetLicenseAgrParam.LicenseBigR.Obj)
                    .Collection(item => item.Authors).Query()
                    .LoadAsync();

                await _dbContext.Entry(targetLicenseAgrParam.LicenseBigR.Obj)
                    .Collection(item => item.CopyRight).Query()
                    .LoadAsync();

                foreach (var copyRight in targetLicenseAgrParam.LicenseBigR.Obj.CopyRight)
                {
                    await _dbContext.Entry(copyRight)
                        .Reference(item => item.WorkRh).Query()
                        .LoadAsync();
                }

                #endregion

                targetLicenseAgrParam.SetFields(sourceLicenseAgrParam, new[] { "LicId" });

                var sourceLicense = sourceLicenseAgrParam.License.Single();
                var targetLicense = targetLicenseAgrParam.License.Single();
                targetLicense.SetFields(sourceLicense, new[] { "LId" });

                // умови ліцензії ВП
                var targetLicenseBigR = targetLicenseAgrParam.LicenseBigR;
                targetLicenseBigR.SetFields(sourceLicenseBigR, new[] { "LicId" });

                #region збірна музика/музичне оформлення
 
                foreach (var sourceMusicalDesign in sourceLicenseBigR.MusicalDesign)
                {
                    MusicalDesign targetMusicalDesign;
                    // перевіряємо наявність нового
                    if (sourceMusicalDesign.MdId == 0)
                    {
                        targetMusicalDesign = new MusicalDesign();
                        targetMusicalDesign.SetFields(sourceMusicalDesign, new[] {"MdId"});
                        targetLicenseBigR.MusicalDesign.Add(targetMusicalDesign);
                        continue;
                    }
                    targetMusicalDesign = targetLicenseBigR.MusicalDesign.Single(rec => rec.MdId == sourceMusicalDesign.MdId);
                    targetMusicalDesign.SetFields(sourceMusicalDesign, new[] { "MdId", "LicId", "LicVersion" });
                }

                var existMdId = sourceLicenseBigR.MusicalDesign
                    //.Where(rec => rec.MdId != 0)
                    .Select(rec => rec.MdId).ToArray();

                var removeMusicalDesignList = targetLicenseBigR.MusicalDesign.Where(rec => !existMdId.Contains(rec.MdId)).ToList();
                foreach (var musicalDesign in removeMusicalDesignList)
                {
                    targetLicenseBigR.MusicalDesign.Remove(musicalDesign);
                }

                #endregion

                // об'єкт права
                targetLicenseBigR.Obj.SetFields(sourceLicenseBigR.Obj, new[] { "ObjId" });

                #region автори/правовласники

                foreach (var sourceAuthor in sourceLicenseBigR.Obj.Authors)
                {
                    Authors targetAuthor;
                    // перевіряємо на наявність нового
                    if (sourceAuthor.AuthId == 0)
                    {
                        targetAuthor = new Authors();
                        targetAuthor.SetFields(sourceAuthor, new[] { "AuthId" });
                        targetLicenseBigR.Obj.Authors.Add(targetAuthor);
                        continue;
                    }

                    targetAuthor = targetLicenseBigR.Obj.Authors.Single(rec => rec.AuthId == sourceAuthor.AuthId);
                    targetAuthor.SetFields(sourceAuthor, new []{ "AuthId" });
                }

                var existAuthId = sourceLicenseBigR.Obj.Authors
                    //.Where(rec => rec.AuthId != 0)
                    .Select(rec => rec.AuthId).ToArray();
                
                var removeAuthors = targetLicenseBigR.Obj.Authors.Where(rec => !existAuthId.Contains(rec.AuthId)).ToList();
                foreach (var author in removeAuthors)
                {
                    targetLicenseBigR.Obj.Authors.Remove(author);
                }

                #endregion

                #region копірайти авторів

                foreach (var sourceCopyRight in sourceLicenseBigR.Obj.CopyRight)
                {
                    CopyRight targetCopyRight;
                    // перевіряємо на наявність нового
                    if (sourceCopyRight.CRightId == 0)
                    {
                        targetCopyRight = new CopyRight();
                        targetCopyRight.SetFields(sourceCopyRight);

                        targetCopyRight.WorkRh = new WorkRh();
                        targetCopyRight.WorkRh.SetFields(sourceCopyRight.WorkRh);
                        
                        targetLicenseBigR.Obj.CopyRight.Add(targetCopyRight);
                        continue;
                    }

                    // оновлюємо існуючі
                    targetCopyRight = targetLicenseBigR.Obj.CopyRight.Single(rec => rec.CRightId == sourceCopyRight.CRightId);
                    targetCopyRight.SetFields(sourceCopyRight);

                    // оновлення статусу роботи з правовласником
                    if (sourceCopyRight.WorkRh != null)
                    {
                        if (targetCopyRight.WorkRh == null)
                            targetCopyRight.WorkRh = new WorkRh();

                        targetCopyRight.WorkRh.SetFields(sourceCopyRight.WorkRh);
                        targetCopyRight.WorkRh.CRightId = targetCopyRight.CRightId;
                    }
                }

                // ті що залишились, решта була видалена, шукаємо - видаляємо 
                var existCopyRightsId = sourceLicenseBigR.Obj.CopyRight
                    //.Where(rec => rec.CRightId != 0)
                    .Select(rec => rec.CRightId).ToArray();

                var removeCopyRightList = targetLicenseBigR.Obj.CopyRight.Where(rec => !existCopyRightsId.Contains(rec.CRightId)).ToList();
                foreach (var copyRight in removeCopyRightList)
                {
                    targetLicenseBigR.Obj.CopyRight.Remove(copyRight);
                }

                #endregion

                #region аванси та паушальні платежі

                // оновлення авансів
                foreach (var licAuthorBr in sourceLicenseBigR.LicAuthorBr)
                {
                    var targetLicAuthorBr = targetLicenseBigR.LicAuthorBr
                        .SingleOrDefault(rec =>
                            rec.CRightId == licAuthorBr.CRightId && 
                            rec.LicId == licAuthorBr.LicId &&
                            rec.LicVersion == licAuthorBr.LicVersion);

                    if (targetLicAuthorBr == null)
                    {
                        targetLicAuthorBr = new LicAuthorBr();
                        targetLicAuthorBr.SetFields(licAuthorBr);
                        targetLicenseBigR.LicAuthorBr.Add(targetLicAuthorBr);
                    }
                    else
                    {
                        targetLicAuthorBr.SetFields(licAuthorBr);
                    }
                }

                // можливе видалення авансу
                var removeLicAuthorBrList = targetLicenseBigR.LicAuthorBr
                    .Where(rec => !rec.PrepaySumAuthor.HasValue || rec.PrepaySumAuthor == 0)
                    .ToList();

                foreach (var licAuthorBr in removeLicAuthorBrList)
                {
                    targetLicenseBigR.LicAuthorBr.Remove(licAuthorBr);
                }

                #endregion

                BalanceRate(targetLicenseBigR, targetLicenseAgrParam.LicenseBigR.Obj.CopyRight);

                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok(ResponseOfRequest.Success());
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return Ok(ResponseOfRequest.NotSuccess(e));
            }
        }

        /// <summary>
        /// Перерахувати % Rate за RoleRate
        /// </summary>
        /// <param name="licenseBigR"></param>
        /// <param name="copyRightLCollection"></param>
        private static void BalanceRate(LicenseBigR licenseBigR, ICollection<CopyRight> copyRightLCollection)
        {
            if (!licenseBigR.Rate.HasValue || licenseBigR.Rate == 0 || !copyRightLCollection.Any()) 
                return;
            
            var sumRate = 0m;
            foreach (var copyRight in copyRightLCollection)
            {
                copyRight.Rate = Math.Round(((copyRight.RoleRate ?? 0) * 100) / licenseBigR.Rate.Value, 2);
                sumRate += copyRight.Rate;
            }

            // згладжування
            var delta = Math.Round(100m - sumRate, 2);
            if (delta != 0 && sumRate != 0)
            {
                sumRate = 0m;
                var list = licenseBigR.Obj.CopyRight.Where(rec => rec.RoleRate.HasValue && rec.RoleRate.Value != 0).ToList();

                var divDelta = Math.Round(delta / list.Count, 2);
                foreach (var copyRight in list)
                {
                    copyRight.Rate = Math.Round(copyRight.Rate + divDelta, 2);
                    sumRate += copyRight.Rate;
                }

                // вирівнювання до 100%
                delta = Math.Round(100m - sumRate, 2);
                if (delta != 0)
                {
                    licenseBigR.Obj.CopyRight.OrderByDescending(rec => rec.Rate).First().Rate += delta;
                }
            }
        }
    }
}
