using Mongo.Migration.Migrations.Adapters;
using Mongo.Migration.Startup;
using Mongo.Migration.Startup.Static;
using MongoDB.Driver;

namespace SampleMongodbMigration.Database;

public static class MongoMigrator
{
    public static void Migrate()
    {
        IMongoClient client = new MongoClient("mongodb://root:password@localhost:27017/admin");
        
        // Create database
        // client.GetDatabase("mongodb-migrations");
        
        // Init MongoMigration
        MongoMigrationClient.Initialize(client, new MongoMigrationSettings()
        {
            ConnectionString = "mongodb://root:password@localhost:27017/admin",
            Database = "mongodb-migrations"
        }, new LightInjectAdapter(new LightInject.ServiceContainer()));
    }
}