using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace apache_bench_dotnet_core_load_test
{
    [Route("api/apachebench")]
    [ApiController]
    public class ApacheBenchController : ControllerBase
    {
        private readonly IGithubHttpClient _githubHttpClient;

        public ApacheBenchController(IGithubHttpClient githubHttpClient)
        {
            _githubHttpClient = githubHttpClient;
        }

        [HttpGet("getsync")]
        public ActionResult GetSync(string userName)
        {
            for (int i = 0; i < 5; i++)
            {
                _githubHttpClient.GetUserInfo(userName);
            }
            return Ok();
        }

        [HttpGet("getasync")]
        public async Task<ActionResult> GetAsync(string userName)
        {
            var taskList = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                taskList.Add(_githubHttpClient.GetUserInfoAsync(userName));
            }

            await Task.WhenAll(taskList);
            return Ok();
        }
    }
}
