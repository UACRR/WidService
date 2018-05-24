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
    [Produces("application/json")]
    [Route("api/RH")]
    public class RHController : Controller
    {
        private MediaServiceContext _dbContext;
        public RHController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }


        private async Task<Customer> GetRightHolderAllData(int id)
        {
            var cust = await _dbContext.Customer.Where(row => row.CustId == id)
                        .Include(item => item.Company)
                            .ThenInclude(comp => comp.RelEmployee)
                        .Include(item => item.AnketaCompany)
                        .Include(item => item.Person)
                        .Include(item => item.AnketaPerson)
                        .Include(item => item.Community)
                        .Include(item => item.BankAccount)
                        .Include(item => item.AnketaAddName)
                        .Include(item => item.RightHolder)
                            .ThenInclude(rh => rh.TermsOfService)
                        .SingleOrDefaultAsync();

            var currDate = DateTime.Now.Date;

            await _dbContext.TermsOfService
                .Include(tos => tos.CrkindCodeNavigation)
                    .ThenInclude(ck => ck.CrGroupCodeNavigation)
                .Where(tos => tos.CustId == id)
                .LoadAsync();

            await _dbContext.CustCmRight
                .Where(cr => cr.CustId == id && currDate >= cr.DateBegin && currDate <= cr.DateEnd)
                .LoadAsync();

            if (cust.Company != null)
            {
                foreach (var relEmp in cust.Company.RelEmployee)
                {
                    _dbContext.Entry(relEmp).Reference(item => item.Empl).Load();
                }
            }

            // load only one active agreement with AgreementAddRh for customer
            await _dbContext.Entry(cust).Collection(rec => rec.AgreementMaster)
                .Query()
                .Where(item => item.AgrStatus != 4)
                .Include(item => item.AgreementAddRh)
                .LoadAsync();

            return cust;

        }

        /// <summary>
        /// Збереження нового Споживача
        /// </summary>
        /// <param name="newRightHolder"></param>
        /// <returns></returns>
        [HttpPost("newrightholder")]
        public async Task<IActionResult> Newrightholder([FromBody] Customer newRightHolder)
        {
            IDbContextTransaction tran = null;
            try
            {
                if (newRightHolder == null)
                    throw new Exception("new rightholder is empty");
                if (!(newRightHolder.CustType > 0 && newRightHolder.CustType < 4))
                    throw new Exception("Bad customer type for new rightholder");

                _dbContext.Customer.Add(newRightHolder);

                //.Include(item => item.Company)
                //.Include(comp => comp.RelEmployee)
                //.Include(item => item.AnketaCompany)
                //.Include(item => item.Person)
                //.Include(item => item.AnketaPerson)
                //.Include(item => item.Community)
                //.Include(item => item.BankAccount)
                //.Include(item => item.AnketaAddName)
                //.Include(item => item.RightHolder)
                //    .ThenInclude(rh => rh.TermsOfService)

                // Збереження Customer
                _dbContext.Entry(newRightHolder).State = EntityState.Added;
                // Збереження RightHolder
                if (newRightHolder.RightHolder == null)
                    newRightHolder.RightHolder = new RightHolder();
                _dbContext.Entry(newRightHolder.RightHolder).State = EntityState.Added;

                if (newRightHolder.Community != null)
                    _dbContext.Entry(newRightHolder.Community).State = EntityState.Added;

                // AnketaAddName
                if (newRightHolder.AnketaAddName.Count > 0)
                {
                    foreach (var item in newRightHolder.AnketaAddName)
                        _dbContext.Entry(item).State = EntityState.Added;
                }

                if (newRightHolder.RightHolder.TermsOfService.Count > 0)
                    foreach (var item in newRightHolder.RightHolder.TermsOfService)
                    {
                        _dbContext.Entry(item).State = EntityState.Added;
                        foreach (var subItem in item.CustCmRight)
                            _dbContext.Entry(subItem).State = EntityState.Added;
                    }
                // territoryInclude
                if (newRightHolder.RightHolder.TerritoryInclude.Count > 0)
                    // TermsOfService
                    foreach (var item in newRightHolder.RightHolder.TerritoryInclude)
                        _dbContext.Entry(item).State = EntityState.Added;

                // territoryExclude
                if (newRightHolder.RightHolder.TerritoryExclude.Count > 0)
                    // TermsOfService
                    foreach (var item in newRightHolder.RightHolder.TerritoryExclude)
                        _dbContext.Entry(item).State = EntityState.Added;



                // Збереження BankAccount
                if (newRightHolder.BankAccount.Count > 0)
                    foreach (var item in newRightHolder.BankAccount)
                        _dbContext.Entry(item).State = EntityState.Added;

                // Збереження AgreementMaster
                if (newRightHolder.AgreementMaster.Count > 0)
                    foreach (var item in newRightHolder.AgreementMaster)
                    {
                        _dbContext.Entry(item).State = EntityState.Added;
                        // Збереження AgreementAddRh
                        if (item.AgreementAddRh != null)
                            _dbContext.Entry(item.AgreementAddRh).State = EntityState.Added;
                    }


                if (newRightHolder.CustType == 3) //   Юридична особа
                {

                    // Збереження Company
                    if (newRightHolder.Company == null)
                        throw new Exception("Not input data for Company");
                    _dbContext.Entry(newRightHolder.Company).State = EntityState.Added;

                    // Збереження AnketaCompany
                    if (newRightHolder.AnketaCompany.Count == 0)
                        throw new Exception("Not input data for AnketaCompany");
                    foreach (var item in newRightHolder.AnketaCompany)
                        _dbContext.Entry(item).State = EntityState.Added;

                    // Збереження RelEmployee
                    if (newRightHolder.Company.RelEmployee.Count > 0)
                    {
                        foreach (var item in newRightHolder.Company.RelEmployee)
                        {
                            // Збереження Employee
                            if (item.Empl?.Emplid != null && item.Empl.Emplid == 0)
                                _dbContext.Entry(item.Empl).State = EntityState.Added;

                            _dbContext.Entry(item).State = EntityState.Added;
                        }
                    }
                }
                else
                {
                    // Збереження Person
                    if (newRightHolder.Person == null)
                        throw new Exception("Not input data for Company");
                    _dbContext.Entry(newRightHolder.Person).State = EntityState.Added;
                    // Збереження AnketaPerson
                    if (newRightHolder.AnketaPerson.Count == 0)
                        throw new Exception("Not input data for AnketaPerson");

                    foreach (var item in newRightHolder.AnketaPerson)
                        _dbContext.Entry(item).State = EntityState.Added;
                }


                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return await getRh(newRightHolder.CustId);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Отримати всю інформацію по Правовласнику
        /// </summary>
        /// <param name="rhId"> Ид Правовласника </param>
        /// <returns></returns>
        [HttpGet("detail/{rhId}")]
        public async Task<IActionResult> getRh(int rhId)
        {
            var customer = await GetRightHolderAllData(rhId);

            return Json(customer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sors"></param>
        /// <param name="dest"></param>
        /// <param name="maxId"></param>
        /// <param name="compId"></param>
        private void UpdateList<T>(ICollection<T> sors, ICollection<T> dest, Action<T> maxId, Func<T, T, bool> compId) where T : class
        {
            // Видалення
            List<T> tempList = dest.Where(row => !sors.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => _dbContext.Entry(item).State = EntityState.Deleted);
            // Додаємо нові
            tempList = sors.Where(row => !dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => { sors.Remove(item); maxId(item); dest.Add(item); });
            // Змінюємо спільні записи
            sors.ToList().ForEach(item => dest.First(row => compId(item, row)).SetFields(item));

        }

        /// <summary>
        /// Отримати всю інформацію по Правовласнику
        /// </summary>
        /// <param name="rhId"> Ид Правовласника </param>
        /// <returns></returns>
        [HttpPut("detail/{rhId}")]
        public async Task<IActionResult> updateRh(int rhId, [FromBody] Customer updCustomer)
        {
            IDbContextTransaction tran = null;
            if (updCustomer == null || rhId != updCustomer.CustId)
                return BadRequest();

            try
            {


                var dest = await GetRightHolderAllData(rhId);
                // Customer
                dest.SetFields(updCustomer);
                //.Include(item => item.BankAccount)
                UpdateList(updCustomer.BankAccount, dest.BankAccount, row => row.BanAccId = 0, (sorsItem, destItem) => sorsItem.BanAccId == destItem.BanAccId);
                //.Include(item => item.AnketaAddName)
                UpdateList(updCustomer.AnketaAddName, dest.AnketaAddName, row => { }, (sorsItem, destItem) => sorsItem.Lang == destItem.Lang);
                //.Include(item => item.RightHolder)
                dest.RightHolder.SetFields(updCustomer.RightHolder);
                //.Include(item => item.AnketaAddName)
                UpdateList(updCustomer.RightHolder.AnketaAddNick, dest.RightHolder.AnketaAddNick, row => { }, (sorsItem, destItem) => sorsItem.AddId == destItem.AddId);
                //.Include(rh => rh.TermsOfService)
                UpdateList(updCustomer.RightHolder.TermsOfService, dest.RightHolder.TermsOfService, row => { }, (sorsItem, destItem) => sorsItem.CrkindCode == destItem.CrkindCode);
                UpdateList(updCustomer.RightHolder.TerritoryExclude, dest.RightHolder.TerritoryExclude, row => { }, (sorsItem, destItem) => sorsItem.CountryCode == destItem.CountryCode);
                UpdateList(updCustomer.RightHolder.TerritoryInclude, dest.RightHolder.TerritoryInclude, row => { }, (sorsItem, destItem) => sorsItem.CountryCode == destItem.CountryCode);

                List<AgreementAddRh> tempList = dest.RightHolder.AgreementAddRh.Where(row => !updCustomer.RightHolder.AgreementAddRh.Any(item => row.AgrId == item.AgrId)).ToList();
                tempList.ForEach(item =>
                {
                    // Delete LicenseAgreement
                    var agreeItem = dest.AgreementMaster.Where(rec => rec.AgrId == item.AgrId).SingleOrDefault();
                    foreach (var license in agreeItem.LicenseAgreement)
                    {
                        // LicAutor
                        foreach( var licBr in license.LicenseBigR.M )
                        {

                        }
                        // MusicalDesign
                        // LicenseBr
                        // LicPlaceHoll
                    }
                    // AgreementMaster
                }
                );



                if (dest.CustType == 3) // Company
                {
                    //.Include(item => item.Company)
                    //.Include(comp => comp.RelEmployee)
                    //.Include(item => item.AnketaCompany)

                }
                else
                {
                    //.Include(item => item.Person)
                    //.Include(item => item.AnketaPerson)

                }



                //.Include(item => item.Community)

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;
                dest = await GetRightHolderAllData(rhId);
                return Json(dest);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();

                return BadRequest(ex.Message);
            }

        }

    }
}