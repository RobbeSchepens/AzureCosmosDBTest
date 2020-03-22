// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.using System

using System;
using AzureCosmosDB.Interfaces;
using AzureCosmosDB.Models;
using Microsoft.Azure.Documents;

namespace AzureCosmosDB.Data
{
    public class InvoiceRepository : CosmosDbRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ICosmosDbClientFactory factory) : base(factory) { }

        public override string CollectionName { get; } = "Invoices";
        public override string GenerateId(Invoice entity) => Guid.NewGuid().ToString();
        public override PartitionKey ResolvePartitionKey(string entityId) => new PartitionKey(entityId.Split(':')[0]);
    }
}
