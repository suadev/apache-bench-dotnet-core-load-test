
using System.Net.Http;
using System.Threading.Tasks;

namespace apache_bench_dotnet_core_load_test
{
    public class GithubHttpClient : IGithubHttpClient
    {
        private readonly HttpClient _httpClient;

        public GithubHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpResponseMessage GetUserInfo(string userName)
        {
            return _httpClient.GetAsync("/users/" + userName).Result;
        }

        public Task<HttpResponseMessage> GetUserInfoAsync(string userName)
        {
            return _httpClient.GetAsync("/users/" + userName);
        }
    }
}