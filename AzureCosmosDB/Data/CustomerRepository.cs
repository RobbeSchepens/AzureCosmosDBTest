// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.using System

using System;
using AzureCosmosDB.Interfaces;
using AzureCosmosDB.Models;
using Microsoft.Azure.Documents;

namespace AzureCosmosDB.Data
{
    public class CustomerRepository : CosmosDbRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ICosmosDbClientFactory factory) : base(factory) { }

        public override string CollectionName { get; } = "Customers";
        public override string GenerateId(Customer entity) => Guid.NewGuid().ToString();
        public override PartitionKey ResolvePartitionKey(string entityId) => new PartitionKey(entityId.Split(':')[0]);
    }
}
