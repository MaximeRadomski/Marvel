using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Marvel.Models;
using Newtonsoft.Json;

namespace Marvel.Services
{
    public class RestService : IRestService
    {
        private HttpClient _client = new HttpClient();
        private const string Url = "http://gateway.marvel.com/v1/public/characters";
        private const string TimeStamp = "?ts=1";
        private const string Apikey = "&apikey=9c0d7803beda670aa96f3618e8cc78c4";
        private const string Hash = "&hash=8d012c90ef8dfc4c1e53008a78ab3f9b";
        private string _parameters = "";

        public async Task<List<Hero>> LoadHeroesRange(int rangeStart)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            _parameters = "&offset="+rangeStart;
            string completeUrl = Url + TimeStamp + Apikey + Hash + _parameters;
            try
            {
                response = await _client.GetAsync(completeUrl);
                string responseText = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<MarvelApiResult<Hero>>(responseText);
                    return result.Data.Results;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
