using System;

namespace AzureCosmosDB.Models.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
