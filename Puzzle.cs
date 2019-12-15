using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NAoCHelper
{
    public class Puzzle
    {
        public int Year { get; }
        public int Day { get; }
        [JsonProperty] // Required so that Newtonsoft.Json can populate it.
        public string Input { get; private set; }

        [JsonIgnore]
        private User User { get; }
        [JsonIgnore]
        private HttpClient Client { get; } = new HttpClient();
        [JsonIgnore]
        private Cache Cache { get; } = new Cache();

        public Puzzle(User user, int year, int day)
        {
            User = user;
            Year = year;
            Day = day;
        }

        public async Task<string> GetInputAsync()
        {
            Client.BaseAddress = new Uri($"https://adventofcode.com/{Year}/day/{Day}/");
            Client.DefaultRequestHeaders.Add("cookie", User.Cookie);

            Input = Cache.GetInput(Year, Day);
            if (string.IsNullOrWhiteSpace(Input))
            {
                var response = await Client.GetAsync("input");
                if (response.IsSuccessStatusCode)
                {
                    Input = await response.Content.ReadAsStringAsync();
                    Cache.SaveInput(this);
                }
            }

            return Input;
        }
    }
}