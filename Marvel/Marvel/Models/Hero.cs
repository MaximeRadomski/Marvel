using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.Models
{
    public class Hero
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("thumbnail")]
        public ImageUrl Thumbnail { get; set; }
    }
}
