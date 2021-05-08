using System.Threading.Tasks;
using TestingDemo.Demo_4.Models;

namespace TestingDemo.Demo_4.Api
{
    public interface IGithubApiService
    {
        Task<SearchResponse> SearchForUser(string username);
    }
}
