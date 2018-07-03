using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace apache_bench_dotnet_core_sample.Controllers
{
    [Route("api/apachebench")]
    [ApiController]
    public class ApacheBenchController : ControllerBase
    {

        [HttpGet("getsync")]
        public ActionResult GetSync(int id)
        {

            //IO işlemi yapıacal async için
            long result = 0;
            for (long i = 0; i < 1000000; i++)
            {
                result += i;
            }

            return Ok(result);
        }

        [HttpGet("getasync")]
        public async Task<ActionResult> GetAsync(int id)
        {
            long result = 0;
            for (long i = 0; i < 1000000; i++)
            {
                result += i;
            }

            return Ok(result);
        }
    }
}
