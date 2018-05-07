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
        Task<List<Hero>> LoadHeroesRange(int rangeStart, int limit);
    }
}