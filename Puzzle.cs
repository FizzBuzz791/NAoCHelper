using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MAoCHelper
{
    public class Puzzle
    {
        public int Year { get; }
        public int Day { get; }

        private User User { get; }
        private HttpClient Client { get; }

        public Puzzle(User user, int year, int day)
        {
            User = user;
            Year = year;
            Day = day;

            Client = new HttpClient();
            Client.BaseAddress = new Uri($"https://adventofcode.com/{Year}/day/{Day}/");
            Client.DefaultRequestHeaders.Add("cookie", User.Cookie);
        }

        public async Task<string> GetInputAsync()
        {
            // TODO: Cache this.
            var response = await Client.GetAsync("input");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // TODO: Add some logging.
                return string.Empty;
            }
        }
    }
}