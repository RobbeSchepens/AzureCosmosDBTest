using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureCosmosDB.Models.Interfaces;
using AzureCosmosDB.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;

namespace AzureCosmosDB.Controllers
{
    public class BaseController<TEntity> : ControllerBase
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;

        protected BaseController(IRepository<TEntity> repository) => this.repository = repository;

        // GET: api/TEntity
        protected async Task<IEnumerable<TEntity>> Get()
        {
            return await repository.GetItemsAsync();
        }

        // GET: api/TEntity/5
        protected async Task<TEntity> Get(Guid id)
        {
            return await repository.GetItemAsync(id.ToString());
        }

        // POST: api/TEntity
        protected async Task<Document> Post([FromBody] TEntity post)
        {
            return await repository.CreateItemAsync(post);
        }

        // POST: api/TEntity/5
        protected async Task<Document> Put(Guid id, [FromBody] TEntity put)
        {
            return await repository.UpdateItemAsync(id.ToString(), put);
        }

        // DELETE: api/TEntity/5
        protected async Task Delete(Guid id)
        {
            await repository.DeleteItemAsync(id.ToString());
        }
    }
}
