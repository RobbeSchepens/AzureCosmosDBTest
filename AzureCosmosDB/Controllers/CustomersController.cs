using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureCosmosDB.Models;
using AzureCosmosDB.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;

namespace AzureCosmosDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : BaseController<Customer>
    {
        private readonly IRepositoryCustomer repository;

        public CustomersController(IRepositoryCustomer repository) : base(repository)
        {
            this.repository = repository;
        }

        // GET: api/Customers
        [HttpGet]
        public new async Task<IEnumerable<Customer>> Get()
        {
            return await base.Get();
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public new async Task<Customer> Get(Guid id)
        {
            return await base.Get(id);
        }

        // POST: api/Customers
        [HttpPost]
        public new async Task<Document> Post([FromBody] Customer post)
        {
            return await base.Post(post);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public new async Task<Document> Put(Guid id, [FromBody] Customer put)
        {
            return await base.Put(id, put);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public new async Task Delete(Guid id)
        {
            await base.Delete(id);
        }
    }
}
