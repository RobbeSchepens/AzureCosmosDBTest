using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AzureCosmosDB.Models;
using AzureCosmosDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;

namespace AzureCosmosDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        // GET: api/Invoices
        [HttpGet]
        public async Task<IEnumerable<Invoice>> Get()
        {
            return await DocumentDBRepository<Invoice>.GetItemsAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}", Name = "GetInvoice")]
        public async Task<Invoice> Get(Guid id)
        {
            return await DocumentDBRepository<Invoice>.GetItemAsync(id.ToString());
        }

        // POST: api/Invoices
        [HttpPost]
        public async Task<Document> Post([FromBody] Invoice post)
        {
            return await DocumentDBRepository<Invoice>.CreateItemAsync(post);
        }

        // PUT: api/Invoices/5
        [HttpPut("{id}")]
        public async Task<Document> Put(Guid id, [FromBody] Invoice put)
        {
            return await DocumentDBRepository<Invoice>.UpdateItemAsync(id.ToString(), put);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await DocumentDBRepository<Invoice>.DeleteItemAsync(id.ToString());
        }

        // PUT: api/Invoices/CompleteInvoice/5
        [HttpPut("CompleteInvoice/{id}")]
        public async Task<Document> CompleteInvoice(Guid id)
        {
            var invoiceToComplete = await DocumentDBRepository<Invoice>.GetItemAsync(id.ToString());

            if (invoiceToComplete.IsCompleted)
            {
                this.ModelState.AddModelError(
                    "IsCompleted",
                    "This invoices is already been completed.");
                return null;
            }

            invoiceToComplete.IsCompleted = true;
            return await DocumentDBRepository<Invoice>.UpdateItemAsync(id.ToString(), invoiceToComplete);
        }
    }
}
