using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestingDemo.Demo_4.Models
{
    public class SearchResponse
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }

        [JsonProperty("items")]
        public List<GithubUser> Items { get; set; }
    }
}
