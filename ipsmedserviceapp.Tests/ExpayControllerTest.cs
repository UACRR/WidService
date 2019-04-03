using System;
using System.Collections;
using System.Threading.Tasks;
using ipsmedserviceapp.Controllers;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ipsmedserviceapp.Tests
{
    public class ExpayControllerTest
    {
        private readonly MediaServiceContext dbContext = new MediaServiceContext();

        [Fact]
        public async Task GetVCustomer_Test()
        {
            var controller = new ExpayController(dbContext);

            var result = await controller.GetVCustomers();
            
            //Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }
    }
}
