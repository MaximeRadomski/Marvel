using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.Models
{
    class Comics
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
