# MongoDB Code Migration in Dotnet 6

This is a sample project that shows how to do database code migration for MongoDB in dotnet 6. To perform the code migration this sample
project depend on [Mongo.Migration NuGet Package](https://github.com/SRoddis/Mongo.Migration). 

# How to Run the Sample Project

## Setup MongoDB Locally

To run this sample project and see the code migration result, first you must have an instance of MongoDB running locally.
To set up MongoDB locally quickly you could use the existing docker-compose in this project to set it up.

```sh
# Create MongoDB container
docker-compose up -up

# Check if the container is running
docker ps
```

## Run the Database Code Migration

To run the database code migration, simply run the project. Make sure you have restored the project dependencies before running it.

```sh
# Restore project dependencies
dotnet restore

# Run the project
docker run
```

If the project successfully running, a mongo database called `mongodb-migrations` should be created in your locally running MongoDB instance.

# How the Code Migration Works

The code migration is run when the project is started due to the following line of code in `Program.cs`

```c#
// ...

// Run MongoDB migrations
MongoMigrator.Migrate();

// ...
```

When `MongoMigrator.Migrate()` is called, all migrations under `/migrations` folder will be executed. Each migration
will have a version number (with any formatting you like) and this version is what being tracked by `Mongo.Migration` to know whether a certain
migration has been run or not.

```c#
public class M001_CreateStudentCollections : DatabaseMigration
{
    public M001_CreateStudentCollections() : base("0.0.1")  // version number
    {
    }
    
    // ...
}
```

Once a migration has been successfully run, you should be able to see a record of it in the `_migrations` collections. 
**All migrations should have a unique version, otherwise a runtime exception will be thrown during a startup.**
