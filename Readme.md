
# .NET GraphQL

This is a simple repository containing a .NET 6.0 Web API and GraphQL functionality using Hot Chocolate. Started with code from Christian Schou and his [guide](https://blog.christian-schou.dk/how-to-implement-graphql-in-asp-net-core/).

## Getting Started

Everything is mostly setup. You will need:

 1. A MS SQL Server Databse.
 2. Entity Framework Core Tools (See [Migration Tools](#migration-tools)).

Once you have those, change the connection string in appsettings.json to point to your database. After that, you will need to migrate the database.

## Migrating the Database

There are seeders in `Data\ContextConfigurations` folder. Once you deploy your database migration, these will seed the database. Once you are ready to migrate your database, you will just need to run the following commands in the NuGet Package Manager (Tools > NuGet Package Manager > Nuget Package Manager Console):
    
You may need to get [Entity Framework Core Tools](#migration-tools) to run these commands.

```
Add-Migration Initial

Update-Database
```

## Migration Tools

If there is an error with the above section, you will need to download **Entity Framework Core Tools**. To do so, run this in the NuGet Package Manager console:

```
Install-Package Microsoft.EntityFrameworkCore.Tools
```

## Running the Application

Once you have completed migrating the database, you can just hit the lovely 'Run' button that Visual Studio gives you.

There are two interfaces, a RESTful API with abstraction and a GraphQL endpoint. The GraphQL endpoint can be hit by POSTing a GraphQL query to `/graphql`.

## Mutations

Along with queries there are the following mutations for each model.

- Add
- Update
- Delete

## Adding a Model

To add a model, you will need to follow these steps:

- Create the model in the `Models` directory.
- Create a repository.
  - Repositories go in the `Repositories` directory.
  - Add the new repository to the `ApplicationDbContext` under the `Data` directory.
  - Add the new repository to the `AddRepositories` method in `StartupExtensions.cs`.
- Create a service.
  - Services are in the `Services` directory.
  - Add the new service to the `AddServices` method in `StartupExtensions.cs`.
- (optional) You can create your own seeder under the `Data\ContextConfigurations` directory.
- Add a new migration with a different name (other than 'Initial').
- Update the database.

After that is done, you can go ahead and create the controller and the GraphQL query and mutations.

- Create a new controller in the `Controllers` directory.
- Create the GraphQL Query and Mutations.
  - Create the Query
    - Queries are in the `Data\Queries` directory.
    - Add the query to the `AddQueryTypes` method in `StartupExtensions.cs`.
    - Make sure to have the `[ExtendObjectType("Query")]` attribute on your new query class.
  - Create the Mutation(s)
    - Mutations are in the `Data\Mutations` directory.
    - Add the query to the `AddMutationTypes` method in `StartupExtensions.cs`.
    - Make sure to have the `[ExtendObjectType("Mutation")]` attribute on your new query class.

## Your First GraphQL Query

If you are new to GraphQL, you can use this query below to get started.

```graphql
query {
    superheroes {
        name
    }
}
```

This would result in the following JSON:

```json
{
    "data": {
        "superheroes": [
            {
                "name": "Batman"
            },
            {
                "name": "Black Widow"
            },
            {
                "name": "Luke Skywalker"
            }
        ]
    }
}
```

This would be the equivalent to making an API call to `/api/superheroes`, but instead of getting all of the data you are getting specific columns (name in this case).

Try different queries and learn GraphQL. To pass data to a query, like an Id, just use the parenthesis. For example:

```graphql
query {
    superhero(id: "6e14e0a9-3a1c-45c8-bd67-193dcc6a4098") {
        name
    }
}
```

This would result in the following JSON:

```json
{
    "data": {
        "superhero": {
            "name": "Batman"
        }
    }
}
```