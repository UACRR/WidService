using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerAgreementController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public ConsumerAgreementController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Створити ліцензійний договір
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAgreement([FromBody] LicenseAgreement source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var fieldExclude = new[] {"LicId"};

                var target = new LicenseAgreement();
                target.SetFields(source, fieldExclude);

                var agreementMaster = await _dbContext.AgreementMaster.FirstOrDefaultAsync(rec => rec.CustId == source.CustId);
                target.AgrId = agreementMaster.AgrId;

                var licenseAgrParam = new LicenseAgrParam();
                var sourceLicenseAgrParam = source.LicenseAgrParam.SingleOrDefault();

                licenseAgrParam.SetFields(sourceLicenseAgrParam, fieldExclude);

                if (sourceLicenseAgrParam?.License != null)
                {
                    foreach (var license in sourceLicenseAgrParam.License)
                    {
                        var newLicense = new License();
                        newLicense.SetFields(license, new []{ "LicId" });
                        
                        licenseAgrParam.License.Add(newLicense);
                    }
                }

                target.LicenseAgrParam.Add(licenseAgrParam);

                await _dbContext.LicenseAgreement.AddAsync(target);

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();

                // викликати процедуру присвоєння номеру договору
                string setAgrNumber = "exec pTsk4_GetClnNdog @licId, @version";
                _dbContext.Database.ExecuteSqlCommand(setAgrNumber, new SqlParameter("@licId", target.LicId), new SqlParameter("@version", target.LicVersion));

                transaction.Commit();

                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Створити нову версію ліцензійного договору дял пролонгації або внесення змін в поточну версію договору
        /// </summary>
        /// <param name="source"></param>
        /// <param name="isProlong"></param>
        /// <returns></returns>
        [HttpPost("createversion/{isProlong}")]
        public async Task<IActionResult> CreateAgreementVersion([FromBody] LicenseAgrParam source, bool isProlong)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var license = await _dbContext.LicenseAgreement.SingleOrDefaultAsync(rec => rec.LicId == source.LicId);
                if (license == null)
                    return NotFound();

                var target = new LicenseAgrParam();
                target.SetFields(source);
                target.LicId = license.LicId;

                foreach (var placeLicense in source.License)
                {
                    var newPlaceLicense = new License();
                    newPlaceLicense.SetFields(placeLicense, new[] { "LId" });
                    newPlaceLicense.LicId = license.LicId;

                    target.License.Add(newPlaceLicense);
                }

                if (isProlong)
                    license.ProlongVersion = source.LicVersion;

                _dbContext.LicenseAgrParam.Add(target);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Оновити дані ліцензійного договору
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAgreement([FromBody] LicenseAgrParam source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.LicenseAgrParam
                    .Include(item => item.License)
                    .SingleOrDefaultAsync(rec => rec.LicId == source.LicId && rec.LicVersion == source.LicVersion);

                if (target == null)
                    return NotFound();

                target.SetFields(source, new []{ "LicId" });
                target.ModifyDate = DateTime.Now;

                int[] sourceIds = source.License.Where(rec => rec.LId != 0 && rec.PlaceId.HasValue).Select(rec => (int)rec.PlaceId).ToArray();
                var deleteItems = target.License.Where(rec => !sourceIds.Contains((int)rec.PlaceId)).ToList();
                foreach (var deleteItem in deleteItems)
                {
                    target.License.Remove(deleteItem);
                }

                var addItems = source.License.Where(rec => rec.LId == 0).ToList();
                foreach (var license in addItems)
                {
                    var newLicense = new License();
                    newLicense.SetFields(license, new []{ "LId" });
                    newLicense.Status = source.LicStatus;
                    license.LicId = target.LicId;
                    target.License.Add(newLicense);
                }

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Змінити статус ліцензійного договору
        /// </summary>
        /// <param name="licenseId"></param>
        /// <param name="licenseVersion"></param>
        /// <param name="status"></param>
        /// <param name="versionChanging"></param>
        /// <returns></returns>
        [HttpPut("licensestatus/{licenseId}/{licenseVersion}/{status}/{versionChanging}")]
        public async Task<IActionResult> UpdateLicenseAgreementStatus(int licenseId, int licenseVersion, int status, bool versionChanging)
        {
            int[] exceptionalStatuses = { 4, 10 };

            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.LicenseAgreement
                    .Where(item => item.LicId == licenseId)
                    .Include(item => item.LicenseAgrParam)
                    .SingleOrDefaultAsync();

                if (target == null)
                    return NotFound();

                if (exceptionalStatuses.Contains(status))
                {
                    // закрити ліцензійний договір
                    if (status == 4) 
                    {
                        // всі майбутні версії ліцензій
                        var deleteLicenses = target.LicenseAgrParam
                            .Where(rec => rec.LicVersion > target.LicVersion)
                            .ToList();

                        // ліцензії бізнес-точок майбутніх версій
                        var versions = deleteLicenses.Select(v => v.LicVersion).ToArray();
                        var deletePlaceLicense = await _dbContext.License
                            .Where(rec => rec.LicId == target.LicId && rec.LicVersion.HasValue && versions.Contains((int) rec.LicVersion))
                            .ToListAsync();

                        _dbContext.License.RemoveRange(deletePlaceLicense);
                        _dbContext.LicenseAgrParam.RemoveRange(deleteLicenses);

                        // видалити версію для пролонгації, яка не була в дії
                        if (target.ProlongVersion.HasValue)
                        {
                            if (target.ProlongVersion > target.LicVersion)
                                target.ProlongVersion = null;

                            if (target.ProlongVersion < target.LicVersion)
                            {
                                var prolongLicense = target.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == target.ProlongVersion && rec.LicStatus == 2);
                                if (prolongLicense != null)
                                {
                                    var placeLicensesProlong = await _dbContext.License
                                        .Where(rec => rec.LicId == target.LicId && rec.LicVersion == prolongLicense.LicVersion)
                                        .ToListAsync();

                                    if(placeLicensesProlong.Any())
                                        _dbContext.License.RemoveRange(placeLicensesProlong);

                                    _dbContext.LicenseAgrParam.Remove(prolongLicense);
                                }
                            }
                        }

                        target.LicStatus = status;
                        
                        foreach (var agrParam in target.LicenseAgrParam)
                            agrParam.LicStatus = status;

                        var licenseAgrParam = target.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == target.LicVersion);
                        licenseAgrParam.DateEnd = DateTime.Now;

                        // ліцензії бізнес-точок
                        var placeLicenses = await _dbContext.License
                            .Where(rec => rec.LicId == target.LicId && rec.LicVersion == target.LicVersion)
                            .ToListAsync();

                        foreach (var placeLicense in placeLicenses)
                            placeLicense.Status = status;
                    }
                    else if (status == 10)
                    {
                        target.LicStatus = status;

                        foreach (var licenseAgrParam in target.LicenseAgrParam)
                            licenseAgrParam.LicStatus = status;

                        // видалити ліцензії бізнес-точок
                        var deletePlaceLicenses = await _dbContext.License
                            .Where(rec => rec.LicId == target.LicId)
                            .ToListAsync();

                        _dbContext.License.RemoveRange(deletePlaceLicenses);
                    }
                }
                else
                {
                    if (versionChanging)
                    {
                        // змінюється на нову версію, отже стару закриваємо
                        var oldLicenseAgrParam = target.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == target.LicVersion && rec.LicVersion != licenseVersion);
                        if (oldLicenseAgrParam != null)
                            oldLicenseAgrParam.LicStatus = 4;
                        
                        // ліцензії по майданчикам
                        var placeLicenses = await _dbContext.License
                            .Where(rec => rec.LicId == target.LicId && rec.LicVersion == target.LicVersion && rec.LicVersion != licenseVersion)
                            .ToListAsync();

                        foreach (var placeLicense in placeLicenses)
                            placeLicense.Status = 4;

                        target.LicVersion = licenseVersion;
                    }

                    target.LicStatus = status;

                    var licenseArgParam = target.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == licenseVersion);
                    licenseArgParam.LicStatus = status;

                    var newPlaceLicenses = await _dbContext.License
                        .Where(rec => rec.LicId == target.LicId && rec.LicVersion == target.LicVersion)
                        .ToListAsync();

                    foreach (var placeLicense in newPlaceLicenses)
                        placeLicense.Status = status;
                }

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Оновити примітку до ліцензійного договору
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPut("updatecomment")]
        public async Task<IActionResult> UpdateAgreementComment([FromBody] LicenseAgrParam source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.LicenseAgrParam
                    .SingleOrDefaultAsync(rec => rec.LicId == source.LicId && rec.LicVersion == source.LicVersion);

                target.Comment = source.Comment;

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

    }
}