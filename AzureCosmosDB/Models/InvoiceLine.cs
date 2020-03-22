﻿using System.Text.Json.Serialization;

namespace AzureCosmosDB.Models
{
    public class InvoiceLine
    {
        [JsonPropertyName("invoiceId")]
        public int InvoiceId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("total")]
        public decimal Total => Quantity * UnitPrice;

        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }
    }
}