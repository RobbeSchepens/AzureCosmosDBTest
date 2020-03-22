﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureCosmosDB.Models;
using AzureCosmosDB.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<Invoice> Get(string id)
        {
            return await DocumentDBRepository<Invoice>.GetItemAsync(id);
        }

        // POST: api/Invoices
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Invoices/5
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
