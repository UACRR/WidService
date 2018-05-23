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
    [Route("api/RH")]
    public class RHController : Controller
    {
        private MediaServiceContext _dbContext;
        public RHController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }


        private async Task<Customer> GetRightHolderAllData( int id )
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
        /// Отримати всю інформацію по Правовласнику
        /// </summary>
        /// <param name="rhId"> Ид Правовласника </param>
        /// <returns></returns>
        [HttpGet("detail/{rhId}")]
        public async Task<IActionResult> getRh( int rhId )
        {
            var customer = await GetRightHolderAllData(rhId);

            return Json(customer);
        }

    }
}