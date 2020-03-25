using System;
using System.Collections.Generic;
using AzureCosmosDB.Models.Interfaces;
using Newtonsoft.Json;

namespace AzureCosmosDB.Models
{
    public class Customer : IEntity
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        
        [JsonProperty(PropertyName = "contactInfos")]
        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
    }
}
