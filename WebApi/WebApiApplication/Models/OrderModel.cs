﻿using Newtonsoft.Json;
using System;

namespace WebApiApplication.Models
{
    public class OrderModel
    {
        [JsonProperty("orderid")]
        public int Id { get; set; }

        [JsonProperty("orderstatus")]
        public int Status { get; set; }

        [JsonProperty("createddate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("updateddate")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty("productid")]
        public int ProductId { get; set; }
    }
}
