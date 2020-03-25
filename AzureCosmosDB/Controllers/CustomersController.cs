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
        public async Task<Customer> Get(string id)
        {
            return await DocumentDBRepository<Customer>.GetItemAsync(id);
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<Document> Post([FromBody] Customer post)
        {
            return await DocumentDBRepository<Customer>.CreateItemAsync(post);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Customer put)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
