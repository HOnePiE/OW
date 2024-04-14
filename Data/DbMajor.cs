using astn_course.Model;
using MongoDB.Driver;

namespace astn_course.Data
{
  public class DbMajor
  {
    public static string _collection = "majors";
    public static async Task<List<MajorModel>> GetAll()
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<MajorModel>(_collection);
      var result = collection.Find(_ => true).ToList();
      return result;
    }

    public static async Task Create(MajorModel majorModel)
    {
      if (string.IsNullOrEmpty(majorModel.id))
      {
        majorModel.id = Mongo.RandomId();
      }
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<MajorModel>(_collection);
      await collection.InsertOneAsync(majorModel);
    }

    public static async Task<bool> Update(MajorModel majorModel)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<MajorModel>(_collection);
      var result = await collection.ReplaceOneAsync(x => x.id == majorModel.id, majorModel);
      if (result.IsAcknowledged && result.MatchedCount > 0)
      {
        return true;
      }
      return false;
    }

    public static async Task<bool> Delete(string id)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<MajorModel>(_collection);
      var result = await collection.DeleteOneAsync(x => x.id == id);
      if (result.DeletedCount > 0)
      {
        return true;
      }
      return false;
    }
  }
}
