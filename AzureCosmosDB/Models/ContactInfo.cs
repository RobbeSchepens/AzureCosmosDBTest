using Newtonsoft.Json;

namespace AzureCosmosDB.Models
{
    public enum ContactTypes
    {
        EmailAddress = 1,
        PhoneNumber = 2
    }

    public class ContactInfo
    {
        [JsonProperty(PropertyName = "contactTypeId")]
        public int ContactTypeId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
