using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace AzureCosmosDB.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync();
        Task<Document> CreateItemAsync(T item);
        Task<Document> UpdateItemAsync(string id, T item);
        Task DeleteItemAsync(string id);
    }
}
