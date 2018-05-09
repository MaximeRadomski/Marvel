using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;

namespace Marvel.Models
{
    public class HeroFavorite
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
    }
}
