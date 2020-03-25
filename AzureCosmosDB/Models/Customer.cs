using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AzureCosmosDB.Models
{
    public class Customer
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
        
        [JsonPropertyName("contactInfos")]
        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
