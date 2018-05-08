using System;
using System.Collections.Generic;
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
            var cust = await _dbContext.Customer.Where(row => row.CustId == id)
                        .Include(item => item.Company).ThenInclude(comp => comp.RelEmployee)
                        .Include(item => item.AnketaCompany)
                        .Include(item => item.Person)
                        .Include(item => item.AnketaPerson)
                        .Include(item => item.BankAccount)
                        .Include(item => item.AnketaAddName)
                        .Include(item => item.Client).ThenInclude( cln => cln.ClnBusinessPlace )
                        .SingleOrDefaultAsync();

            foreach( var place in cust.Client.ClnBusinessPlace )
            {
                _dbContext.Entry(place).Collection(item => item.ClnPlaceHoll).Load();
            }


            foreach (var relEmp in cust.Company.RelEmployee)
            {
                _dbContext.Entry(relEmp).Reference(item => item.Empl).Load();
            }

            return cust;

        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetCunsumerById( int id )
        {
            var cust = await GetConsumerAllData(id);
            return Json(cust);
        }
    }
}