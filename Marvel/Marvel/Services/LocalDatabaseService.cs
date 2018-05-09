using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Marvel.Models;
using SQLite;

namespace Marvel.Services
{
    public class LocalDatabaseService : ILocalDatabaseService
    {
        public SQLiteConnection Db;

        public LocalDatabaseService()
        {
            LoadDatabase();
            LoadTables();
        }

        private void LoadDatabase()
        {
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "marvelpeaks.db3");
            Db = new SQLiteConnection(dbPath);
        }

        private void LoadTables()
        {
            Db.CreateTable<HeroFavorite>();
        }

        public async Task<List<HeroFavorite>> LoadHeroes()
        {
            List<HeroFavorite> tmpList = new List<HeroFavorite>();
            var table = Db.Table<HeroFavorite>();
            foreach (var item in table)
            {
                tmpList.Add(item);
            }
            return tmpList;
        }

        public async Task AddFavoriteHero(HeroDetails hero)
        {
            HeroFavorite tmpHero = new HeroFavorite
            {
                Id = hero.Id,
                Name = hero.Name,
                Thumbnail = hero.Thumbnail.FullPath
            };
            Db.Insert(tmpHero);
        }

        public async Task RemoveFavoriteHero(HeroDetails hero)
        {
            Db.Delete<HeroFavorite>(hero.Id);
        }

        public async Task<HeroFavorite> GetFavoriteHeroFromId(int id)
        {
            HeroFavorite tmp;
            try
            {
                tmp = Db.Get<HeroFavorite>(id);
            }
            catch (Exception e)
            {
                return null;
            }
            if (tmp != null)
                return Db.Get<HeroFavorite>(id);
            return null;
        }
    }
}
