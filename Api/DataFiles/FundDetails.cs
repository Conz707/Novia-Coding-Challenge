using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Api.DataFiles
{    
    public class FundDetails
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public bool Active { get; set; }

        [HiddenInput(DisplayValue = false)]
        public decimal CurrentUnitPrice { get; set; }

        //[JsonProperty(PropertyName = "Current Unit Price")]
        //public decimal CurrentUnitPriceRounded { get { return Math.Round(CurrentUnitPrice, 2); } }

        public string FundManager { get; set; }

        public string Name { get; set; }

        //[JsonProperty(PropertyName = "Code")]
        public string MarketCode { get; set; }
    }
}