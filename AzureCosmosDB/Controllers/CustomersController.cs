using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureCosmosDB.Models;
using AzureCosmosDB.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
