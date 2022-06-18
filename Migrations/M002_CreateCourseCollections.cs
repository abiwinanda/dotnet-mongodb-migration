using Mongo.Migration.Migrations.Database;
using MongoDB.Driver;

namespace SampleMongodbMigration.Migrations;

public class M002_CreateCourseCollections : DatabaseMigration
{
    public M002_CreateCourseCollections() : base("0.0.2")
    {
    }

    public override void Up(IMongoDatabase db)
    {
        db.CreateCollection("courses");
    }

    public override void Down(IMongoDatabase db) { }
}