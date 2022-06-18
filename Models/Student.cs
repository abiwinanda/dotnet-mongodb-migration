using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SampleMongodbMigration.Models;

public class Student
{
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string HomeAddress { get; set; } = string.Empty;
}
