using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Marvel.Models;
using Newtonsoft.Json;

namespace Marvel.Services
{
    public interface IRestService
    {
        Task<List<HeroListItem>> LoadHeroesRange(int rangeStart, int limit, string name);
        Task<HeroDetails> LoadHeroDetails(int id);
    }
}