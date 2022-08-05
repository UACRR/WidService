using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private const string RootDirectory = "Languages";

        private readonly MediaServiceContext _dbContext;

        public LanguagesController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [DisableRequestSizeLimit]
        [HttpPut("sync/server")]
        public async Task<IActionResult> UpdateLanguagesOnAppServer([FromBody] Dictionary<string, byte[]> dictionary)
        {
            ResponseOfRequest responseOfRequest;
            try
            {
                foreach (var content in dictionary)
                {
                    string path = $@"{RootDirectory}\{content.Key}";

                    if (!Directory.Exists(RootDirectory))
                        Directory.CreateDirectory(RootDirectory);

                    if (!System.IO.File.Exists(path))
                    {
                        using (var fs = System.IO.File.Create(path))
                        {
                            await fs.WriteAsync(content.Value, 0, content.Value.Length);
                        }
                    }
                    else
                    {
                        await System.IO.File.WriteAllBytesAsync(path, content.Value);
                    }
                }

                responseOfRequest = new ResponseOfRequest("Синхронізовано на сервері.");
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                responseOfRequest = new ResponseOfRequest(e.Message, e);
                return BadRequest(responseOfRequest);
            }
        }

        [DisableRequestSizeLimit]
        [HttpGet("sync/client")]
        public async Task<IActionResult> UpdateLanguagesOnAppClient()
        {
            try
            {
                var dictionary = new Dictionary<string, byte[]>();

                if (!Directory.Exists(RootDirectory))
                {
                    Directory.CreateDirectory(RootDirectory);
                    return Ok(dictionary);
                }


                var files = Directory.GetFiles(RootDirectory);

                foreach (var file in files)
                {
                    var bytes = await System.IO.File.ReadAllBytesAsync(file);
                    dictionary.Add(file, bytes);
                }

                return Ok(dictionary);
            }
            catch (Exception e)
            {
                var responseOfRequest = new ResponseOfRequest(e.Message, e);
                return BadRequest(responseOfRequest);
            }
        }
    }
}