using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Marvel.Models;

namespace Marvel.Services
{
    public interface ILocalDatabaseService
    {
        Task<List<HeroFavorite>> LoadHeroes();
        Task AddFavoriteHero(HeroDetails hero);
        Task RemoveFavoriteHero(HeroDetails hero);
        Task<HeroFavorite> GetFavoriteHeroFromId(int id);
    }
}
