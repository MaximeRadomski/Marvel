using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.Models
{
    public class ImageUrl
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("extension")]
        public string Extension { get; set; }

        public string FullPath
        {
            get => Path + "." + Extension;
            set { }
        }
    }
}
