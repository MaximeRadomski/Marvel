using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.Models
{
    public class Comics
    {
        [JsonProperty("available")]
        public string Available { get; set; }
        [JsonProperty("returned")]
        public string Returned { get; set; }
        [JsonProperty("collectionURI")]
        public string CollectionUri { get; set; }
        [JsonProperty("items")]
        public List<Comic> Items { get; set; }
    }
}
