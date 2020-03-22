// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.using System

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace AzureCosmosDB.Data
{
    public class CosmosDbClient : ICosmosDbClient
    {
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly IDocumentClient _documentClient;

        public CosmosDbClient(string databaseName, string collectionName, IDocumentClient documentClient)
        {
            _databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
            _collectionName = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
            _documentClient = documentClient ?? throw new ArgumentNullException(nameof(documentClient));
        }

        public async Task<Document> ReadDocumentAsync(string documentId, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.ReadDocumentAsync(
                UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId), options, cancellationToken);
        }

        public async Task<Document> ReadDocumentsAsync(RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {

            var query = _documentClient.CreateDocumentQuery<Document>(
                    UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName),
                    new FeedOptions { MaxItemCount = -1 })
                .AsDocumentQuery();

            var results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;


            return await _documentClient.ReadDocumentAsync(
                UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId), options, cancellationToken);
        }

        public async Task<Document> CreateDocumentAsync(object document, RequestOptions options = null,
            bool disableAutomaticIdGeneration = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName), document, options,
                disableAutomaticIdGeneration, cancellationToken);
        }

        public async Task<Document> ReplaceDocumentAsync(string documentId, object document,
            RequestOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId), document, options,
                cancellationToken);
        }

        public async Task<Document> DeleteDocumentAsync(string documentId, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.DeleteDocumentAsync(
                UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId), options, cancellationToken);
        }
    }
}
