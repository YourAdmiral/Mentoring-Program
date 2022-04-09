using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApplication.Models
{
    public class ProductModel
    {
        [JsonProperty("ProductName")]
        public string Name { get; set; }

        [JsonProperty("ProductDescription")]
        public string Description { get; set; }

        [JsonProperty("ProductWeight")]
        public int Weight { get; set; }

        [JsonProperty("ProductHeight")]
        public int Height { get; set; }

        [JsonProperty("ProductWidth")]
        public int Width { get; set; }

        [JsonProperty("ProductLength")]
        public int Length { get; set; }
    }
}
