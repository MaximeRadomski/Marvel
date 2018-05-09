using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;

namespace Marvel.Models
{
    public class HeroDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("thumbnail")]
        public ImageUrl Thumbnail { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("comics")]
        public Comics Comics { get; set; }
    }
}
