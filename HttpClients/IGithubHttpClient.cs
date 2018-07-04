using System.Net.Http;
using System.Threading.Tasks;

namespace apache_bench_dotnet_core_load_test
{
    public interface IGithubHttpClient
    {
        HttpResponseMessage GetUserInfo(string userName);
        Task<HttpResponseMessage> GetUserInfoAsync(string userName);
    }
}