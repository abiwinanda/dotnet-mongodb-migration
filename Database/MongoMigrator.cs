using Mongo.Migration.Migrations.Adapters;
using Mongo.Migration.Startup;
using Mongo.Migration.Startup.Static;
using MongoDB.Driver;

namespace SampleMongodbMigration.Database;

public static class MongoMigrator
{
    private static string ConnectionString = "mongodb://root:password@localhost:27017/admin";
    private static string Database = "mongodb-migrations";
    
    public static void Migrate()
    {
        IMongoClient client = new MongoClient(ConnectionString);
        
        // Init MongoMigration
        MongoMigrationClient.Initialize(client, new MongoMigrationSettings()
        {
            ConnectionString = ConnectionString,
            Database = Database // Database automatically created if not exists yet
        }, new LightInjectAdapter(new LightInject.ServiceContainer()));
    }
}
