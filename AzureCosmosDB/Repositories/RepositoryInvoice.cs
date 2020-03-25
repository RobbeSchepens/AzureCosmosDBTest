using AzureCosmosDB.Models;
using AzureCosmosDB.Repositories.Interfaces;

namespace AzureCosmosDB.Repositories
{
    public class RepositoryInvoice : DocumentDBRepository<Invoice>, IRepositoryInvoice
    {
    }
}
