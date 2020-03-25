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
    public class InvoicesController : BaseController<Invoice>
    {
        private readonly IRepositoryInvoice repository;

        public InvoicesController(IRepositoryInvoice repository) : base(repository)
        {
            this.repository = repository;
        }

        // GET: api/Invoices
        [HttpGet]
        public new async Task<IEnumerable<Invoice>> Get()
        {
            return await base.Get();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}", Name = "GetInvoice")]
        public new async Task<Invoice> Get(Guid id)
        {
            return await base.Get(id);
        }

        // POST: api/Invoices
        [HttpPost]
        public new async Task<Document> Post([FromBody] Invoice post)
        {
            return await base.Post(post);
        }

        // PUT: api/Invoices/5
        [HttpPut("{id}")]
        public new async Task<Document> Put(Guid id, [FromBody] Invoice put)
        {
            return await base.Put(id, put);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public new async Task Delete(Guid id)
        {
            await base.Delete(id);
        }

        // PUT: api/Invoices/CompleteInvoice/5
        [HttpPut("CompleteInvoice/{id}")]
        public async Task<Document> CompleteInvoice(Guid id)
        {
            var invoiceToComplete = await repository.GetItemAsync(id.ToString());

            if (invoiceToComplete.IsCompleted)
            {
                this.ModelState.AddModelError(
                    "IsCompleted",
                    "This invoices is already been completed.");
                return null;
            }

            invoiceToComplete.IsCompleted = true;
            return await repository.UpdateItemAsync(id.ToString(), invoiceToComplete);
        }
    }
}
