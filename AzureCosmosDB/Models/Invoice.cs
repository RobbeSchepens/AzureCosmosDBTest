using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AzureCosmosDB.Models
{
    public class Invoice
    {
        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }

        public virtual Customer Customer { get; set; }

        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        [JsonPropertyName("isCompleted")]
        public bool IsCompleted { get; set; }
    }
}
