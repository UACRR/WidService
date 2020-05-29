using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoyaltyCorrectionController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public RoyaltyCorrectionController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("searchobject/{custId}/{objId}")]
        public async Task<IActionResult> SearchObjectRightAsync(int custId, int objId)
        {
            ResponseOfRequest<object> responseOfRequest;
            try
            {

                responseOfRequest = new ResponseOfRequest<object>(new object());
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                responseOfRequest = new ResponseOfRequest<object>(e);
                return Ok(responseOfRequest);
            }
        }
    }
}
