# Azure Cosmos DB Emulator HTTP API example

## Setup

1. Install the Cosmos DB Emulator (local db) https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator.
2. Copy your `Primary key` to the `key` field in Repositories > DocumentDBRepository.cs.
3. Create a database called "AzureCosmosDBTest" in the Azure Cosmos DB Data Explorer.
4. Create two new containers: "Invoice" and "Customer" both with partition key `/id`.
5. Run the project with IIS Express.
6. Use Postman or other HTTP Call clients to query to the https:// address of your application. It is possible that you need to disable 'certificate validation' in the settings.


## Example calls

### GET Invoices

GET `https://localhost:44314/api/Invoices` 

### GET Invoice by Id

GET `https://localhost:44314/api/Invoices/cf8be6e0-6b54-4831-8c1b-65cae194aa16`

### POST Invoice

POST `https://localhost:44314/api/Invoices`

with JSON text body:

```
{
  "createdOn": "2020-02-17T17:10:59.42+01:00",
  "customerId": 1,
  "description": "Test insert via Emulator Explorer",
  "invoiceLines": [
    {
      "quantity": 300,
      "unitPrice": 0.5
    },
    {
      "quantity": 50,
      "unitPrice": 1.25
    }
  ],
  "isCompleted": false
}
```

### PUT Invoice

PUT `https://localhost:44314/api/Invoices/cf8be6e0-6b54-4831-8c1b-65cae194aa16`

with JSON text body:

```
{
  "id": "cf8be6e0-6b54-4831-8c1b-65cae194aa16",
  "createdOn": "2020-02-17T17:10:59.42+01:00",
  "customerId": 1,
  "description": "Test insert via Emulator Explorer",
  "invoiceLines": [
    {
      "quantity": 300,
      "unitPrice": 0.5
    },
    {
      "quantity": 50,
      "unitPrice": 1.25
    }
  ],
  "isCompleted": false
}
```

### DELETE Invoice

DELETE `https://localhost:44314/api/Invoices/cf8be6e0-6b54-4831-8c1b-65cae194aa16`

### POST Customer

POST `https://localhost:44314/api/Customers`

with JSON text body:

```
{
  "firstName": "Robbe",
  "lastName": "Schepens",
  "address": "Wetteren",
  "contactInfos": [
    {
      "contactTypeId": 1,
      "value": "robbe@rob.be"
    }
  ]
}
```
