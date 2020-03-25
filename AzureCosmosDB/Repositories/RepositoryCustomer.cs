using AzureCosmosDB.Models;
using AzureCosmosDB.Repositories.Interfaces;

namespace AzureCosmosDB.Repositories
{
    public class RepositoryCustomer : DocumentDBRepository<Customer>, IRepositoryCustomer
    {
    }
}
