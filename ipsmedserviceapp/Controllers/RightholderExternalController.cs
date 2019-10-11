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
    public class RightholderExternalController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public RightholderExternalController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Перевести зовнішнього правовласника у внітрішнього
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpPut("transfer/{custId}")]
        public async Task<IActionResult> TransferExternalRHToInternal(int custId)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.Customer
                    .Include(item => item.RightHolder)
                    .Include(item => item.AnketaExternal)
                    .SingleOrDefaultAsync(rec => rec.CustId == custId);

                if (target == null)
                    return NotFound();

                target.AnkVersion = 1;

                // фіз. особа
                if (target.RightHolder.RHolderType == 1)
                {
                    target.CustType = 1;
                    target.Person = new Person
                    {
                        CustId = target.CustId,
                        Version = 1,
                    };
                    var anketaPerson = new AnketaPerson
                    {
                        CustId = target.CustId,
                        Version = 1,
                        NikName = string.Empty,
                        LastName = target.AnketaExternal.Name,
                        FirstName = target.AnketaExternal.FirstName,
                        FaCountry = target.AnketaExternal.CountryCode,
                        ReCountry = target.AnketaExternal.CountryCode,
                        LeCountry = target.AnketaExternal.CountryCode,
                        Inn = target.AnketaExternal.InnOkpo,
                    };
                    target.Person.AnketaPerson.Add(anketaPerson);
                }
                // юр. особа
                else if (target.RightHolder.RHolderType == 3)
                {
                    target.CustType = 3;
                    target.Company = new Company
                    {
                        CustId = target.CustId,
                        Version = 1,
                    };

                    var anketaCompany = new AnketaCompany
                    {
                        CustId = target.CustId,
                        Version = 1,
                        Name = target.AnketaExternal.Name + target.AnketaExternal.FirstName,
                        ShortName = target.AnketaExternal.Name + target.AnketaExternal.FirstName,
                        FaCountry = target.AnketaExternal.CountryCode,
                        JaCountry = target.AnketaExternal.CountryCode,
                        LeCountry = target.AnketaExternal.CountryCode,
                        Okpo = target.AnketaExternal.InnOkpo,
                    };
                    target.Company.AnketaCompany.Add(anketaCompany);
                }

                var agreementMaster = new AgreementMaster
                {
                    CustId = target.CustId,
                    Version = 1,
                    AgrStatus = 0,
                    AgrType = target.RightHolder.RHolderType == 3 ? 5 : 1
                };

                var sysConst = await _dbContext.SystemConstant.Where(rec => (new[] { 4, 5 }).Contains(rec.CodeI)).ToDictionaryAsync(rec => rec.CodeI);

                var agreementAddRh = new AgreementAddRh
                {
                    CustId = target.CustId,
                    Version = 1,
                    AgrDate = DateTime.Now,
                    DateBegin = DateTime.Now,
                    DateEnd = new DateTime(3000, 01, 01),
                    AgrStatus = 0,
                    RateCommiss = sysConst.GetValueOrDefault(4)?.Rate ?? 20,
                    RateCourt = sysConst.GetValueOrDefault(5)?.Rate ?? 15
                };
                agreementMaster.AgreementAddRh.Add(agreementAddRh);
                target.AgreementMaster.Add(agreementMaster);

                var removeAnketaExternal = await _dbContext.AnketaExternal.SingleOrDefaultAsync(rec => rec.CustId == target.CustId);

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();

                if (target.AgreementMaster.FirstOrDefault()?.AgrId is int agrId)
                {
                    // викликати процедуру присвоєння номеру договору для правовласника
                    string setAgrNumber = "exec pTsk4_GetRHNdog @agrId";
                    _dbContext.Database.ExecuteSqlCommand(setAgrNumber, new SqlParameter("@agrId", agrId));
                }

                if (removeAnketaExternal != null)
                    _dbContext.AnketaExternal.Remove(removeAnketaExternal);

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