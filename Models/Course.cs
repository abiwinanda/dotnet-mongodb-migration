using Mongo.Migration.Documents;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleMongodbMigration.Models;

public class Course : IDocument
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;
    public string Name { get; set; } = string.Empty;
    public DocumentVersion Version { get; set; }
}