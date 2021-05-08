using Newtonsoft.Json;

namespace TestingDemo.Demo_4.Models
{
    public class GithubUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("login")]
        public string Name { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
