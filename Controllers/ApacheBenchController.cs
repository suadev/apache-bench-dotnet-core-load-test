using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace apache_bench_dotnet_core_sample.Controllers
{
    [Route("api/apachebench")]
    [ApiController]
    public class ApacheBenchController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApacheBenchController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("getsync")]
        public ActionResult GetSync(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient("cni");
            var response = client.GetAsync("/downloads/Racers.xml").Result;

            response.EnsureSuccessStatusCode();
            string content = response.Content.ReadAsStringAsync().Result;

            return Ok(content);
        }

        [HttpGet("getasync")]
        public async Task<ActionResult> GetAsync(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient("cni");
            var response = await client.GetAsync("/downloads/Racers.xml");

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();

            return Ok(content);
        }
    }
}
