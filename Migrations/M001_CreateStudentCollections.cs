using Mongo.Migration.Migrations.Database;
using Mongo.Migration.Migrations.Document;
using MongoDB.Bson;
using MongoDB.Driver;
using SampleMongodbMigration.Models;

namespace SampleMongodbMigration.Migrations;

public class M001_CreateStudentCollections : DatabaseMigration
{
    public M001_CreateStudentCollections() : base("0.0.1")
    {
    }
    
    public override void Up(IMongoDatabase db)
    {
        db.CreateCollection("students");
    }

    public override void Down(IMongoDatabase db) { }
}