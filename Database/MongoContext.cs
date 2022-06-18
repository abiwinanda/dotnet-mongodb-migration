using Mongo.Migration.Startup.Static;
using MongoDB.Bson;
using MongoDB.Driver;
using Pluralize.NET.Core;

namespace SampleMongodbMigration.Database;

public class MongoContext
{
    private readonly IMongoDatabase _database;

    public MongoContext()
    {
        IMongoClient client = new MongoClient("mongodb://root:password@localhost:27017/admin");
        _database = client.GetDatabase("mongodb-migrations")!;
    }
    
    public MongoContext(string connectionString)
    {
        IMongoClient client = new MongoClient(connectionString);
        _database = client.GetDatabase("mongodb-migrations")!;
    }
    
    public IMongoCollection<BsonDocument> GetCollection(string entityName)
    {
        return _database.GetCollection<BsonDocument>(entityName);
    }
    
    public IMongoCollection<TEntity> GetCollection<TEntity>()
    {
        var entityName = typeof(TEntity).Name.ToLowerInvariant();
        var collectionName = new Pluralizer().Pluralize(entityName);
        return _database.GetCollection<TEntity>(collectionName);
    }

    public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName)
    {
        return _database.GetCollection<TEntity>(collectionName);
    }
}
