using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Consumer")]
    public class ConsumerController : Controller
    {
        private MediaServiceContext _dbContext;
        public ConsumerController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task<Customer> GetConsumerAllData(int id)
        {
            // Отримати основну інформацію
            var cust = await _dbContext.Customer.Where(row => row.CustId == id)
                        .Include(item => item.Company).ThenInclude(comp => comp.RelEmployee)
                        .Include(item => item.AnketaCompany)
                        .Include(item => item.Person)
                        .Include(item => item.AnketaPerson)
                        .Include(item => item.BankAccount)
                        .Include(item => item.Client).ThenInclude( cln => cln.ClnBusinessPlace )
                        .SingleOrDefaultAsync();
            // Отримати дані по Контрактах
            await _dbContext.Entry(cust).Collection(rec => rec.AgreementMaster)
                .Query()
                .Where(agree => agree.AgrStatus < 4)
                .Include(item => item.LicenseAgreement)
                .LoadAsync();

            // Отримати по контрактам Періоди оплат    
            await _dbContext.PaidPeriod.FromSql("select * from PaidPeriod where custId = @custId", new SqlParameter("@custId", cust.CustId))
                .Include( row => row.MoneyPeriodLink )
                .LoadAsync();
            // 
            await _dbContext.MoneyReceived.FromSql("select * from MoneyReceived where custId = @custId", new SqlParameter("@custId", cust.CustId)).LoadAsync();

            // Отримати Майданчики
            foreach ( var place in cust.Client.ClnBusinessPlace )
            {
                _dbContext.Entry(place).Collection(item => item.ClnPlaceHoll).Load();
                _dbContext.Entry(place).Reference(item=>item.PlCodeNavigation).Load();

            }

            // Отримати співробітників
            foreach (var relEmp in cust.Company.RelEmployee)
            {
                _dbContext.Entry(relEmp).Reference(item => item.Empl).Load();
            }

            return cust;

        }

        /// <summary>
        /// Отримати Споживача до Id
        /// </summary>
        /// <param name="id">ідентифікатор CustId бази даних</param>
        /// <returns></returns>
        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetCunsumerById( int id )
        {
            var cust = await GetConsumerAllData(id);
            return Json(cust);
        }

        [HttpGet("listSR")]
        public async Task<IActionResult> GetListSR()
        {
            var List = await _dbContext.getViewData("select * from vTsk_1_ListConsumer01", null);
            return Json(List);
        }
    }
}