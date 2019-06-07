using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/consumers/external")]
    [ApiController]
    public class ConsumersExternalController : Controller
    {
        private readonly MediaServiceContext _dbContext;
        private readonly IMapper _mapper;

        public ConsumersExternalController(MediaServiceContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("{custId}")]
        public async Task<IActionResult> GetById(int custId)
        {
            var item = await GetCustomerById(custId);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer newCustomer)
        {
            if (newCustomer == null)
                BadRequest();

            _dbContext.Customer.Add(newCustomer);
            await _dbContext.SaveChangesAsync();

            return Ok(newCustomer);
        }

        [HttpPut("{custId}")]
        public async Task<IActionResult> Update(int? custId, [FromBody] Customer updCustomer)
        {
            if (!custId.HasValue)
                BadRequest();

            if (updCustomer == null)
                BadRequest();

            var customer = await GetCustomerById(custId.Value);

            if (customer == null)
                NotFound();

            _mapper.Map(updCustomer, customer);
            
            await _dbContext.SaveChangesAsync();

            return Ok(customer);
        }

        private async Task<Customer> GetCustomerById(int custId)
        {
            return await _dbContext.Customer
                .Include(c => c.AnketaExternal)
                .FirstOrDefaultAsync(c => c.CustId == custId);
        }
    }
}