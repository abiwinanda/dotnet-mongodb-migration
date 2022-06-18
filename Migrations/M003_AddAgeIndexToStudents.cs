using MongoDB.Bson;
using MongoDB.Driver;
using SampleMongodbMigration.Models;
using Mongo.Migration.Migrations.Database;

namespace SampleMongodbMigration.Migrations;

public class M003_AddAgeIndexToStudents : DatabaseMigration
{
    public M003_AddAgeIndexToStudents() : base("0.0.3")
    {
    }

    public override void Up(IMongoDatabase db)
    {
        var studentCollection = db.GetCollection<Student>("students");
        var indexDefinition = Builders<Student>.IndexKeys.Ascending(s => s.Age);
        studentCollection.Indexes.CreateOne(new CreateIndexModel<Student>(indexDefinition));
    }

    public override void Down(IMongoDatabase db) { }
}