using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureCosmosDB.Models;
using AzureCosmosDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;

namespace AzureCosmosDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await DocumentDBRepository<Customer>.GetItemsAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<Customer> Get(Guid id)
        {
            return await DocumentDBRepository<Customer>.GetItemAsync(id.ToString());
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<Document> Post([FromBody] Customer post)
        {
            return await DocumentDBRepository<Customer>.CreateItemAsync(post);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<Document> Put(Guid id, [FromBody] Customer put)
        {
            return await DocumentDBRepository<Customer>.UpdateItemAsync(id.ToString(), put);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await DocumentDBRepository<Customer>.DeleteItemAsync(id.ToString());
        }
    }
}
