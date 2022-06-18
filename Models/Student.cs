using Mongo.Migration.Documents;
using Mongo.Migration.Documents.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SampleMongodbMigration.Models;

[RuntimeVersion("0.0.1")]
public class Student : IDocument
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string HomeAddress { get; set; } = string.Empty;
    public DocumentVersion Version { get; set; }
}
