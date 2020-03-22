﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.using System

using System.Threading.Tasks;
using AzureCosmosDB.Models;

namespace AzureCosmosDB.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
