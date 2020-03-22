// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.using System

using AzureCosmosDB.Models;
using Microsoft.Azure.Documents;

namespace AzureCosmosDB.Data
{
    public interface IDocumentCollectionContext<in T> where T : Entity
    {
        string CollectionName { get; }

        string GenerateId(T entity);

        PartitionKey ResolvePartitionKey(string entityId);
    }
}
