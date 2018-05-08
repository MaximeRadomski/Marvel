using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Marvel.Models
{
    public class Comic
    {
        [JsonProperty("resourceURI")]
        public string ResourceUri { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
