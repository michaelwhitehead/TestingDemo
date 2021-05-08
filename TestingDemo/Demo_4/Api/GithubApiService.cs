using System;
using System.Net.Http;
using System.Threading.Tasks;
using Bogus.Extensions;
using Newtonsoft.Json;
using TestingDemo.Demo_4.Models;

namespace TestingDemo.Demo_4.Api
{
    public class GithubApiService : IGithubApiService
    {
        private readonly HttpClient _httpClient;

        public GithubApiService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.github.com/"),
            };
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/vnd.github.v3+json");
        }

        public async Task<SearchResponse> SearchForUser(string username)
        {
            return GetFakeUsers();
            //var response = await _httpClient.GetAsync($"search/users?q={username}");
            //var responseContent = await response.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<SearchResponse>(responseContent);
        }

        private SearchResponse GetFakeUsers()
        {
            var fakeUser = new Bogus.Faker<GithubUser>()
                .RuleFor(c => c.Name, f => f.Person.UserName)
                .RuleFor(c => c.AvatarUrl, f => f.Image.PicsumUrl(200, 200));

            return new SearchResponse()
            {
                Items = fakeUser.GenerateBetween(5, 10),
            };
        }
    }
}
