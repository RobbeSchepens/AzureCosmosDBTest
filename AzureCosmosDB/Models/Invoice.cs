using System;
using System.Collections.Generic;
using AzureCosmosDB.Models.Interfaces;
using Newtonsoft.Json;

namespace AzureCosmosDB.Models
{
    public class Invoice : IEntity
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "customerId")]
        public int CustomerId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "invoiceLines")]
        public ICollection<InvoiceLine> InvoiceLines { get; set; }

        [JsonProperty(PropertyName = "isCompleted")]
        public bool IsCompleted { get; set; }
    }
}
