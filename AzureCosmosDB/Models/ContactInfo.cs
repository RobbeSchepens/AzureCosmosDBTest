using System.Text.Json.Serialization;

namespace AzureCosmosDB.Models
{
    public enum ContactTypes
    {
        EmailAddress = 1,
        PhoneNumber = 2
    }

    public class ContactInfo
    {
        [JsonPropertyName("contactTypeId")]
        public int ContactTypeId { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
