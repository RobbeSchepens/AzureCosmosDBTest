using Newtonsoft.Json;

namespace AzureCosmosDB.Models
{
    public class InvoiceLine
    {
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "total")]
        public decimal Total => Quantity * UnitPrice;

        [JsonProperty(PropertyName = "unitPrice")]
        public decimal UnitPrice { get; set; }
    }
}
