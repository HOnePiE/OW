using astn_course.Model;
using MongoDB.Driver;

namespace astn_course.Data
{
  public class DbLearned
  {
    public static string _collection = "learneds";
    public static async Task<List<LearnedModel>> GetAll()
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LearnedModel>(_collection);
      var result = collection.Find(_ => true).ToList();
      return result;
    }

    public static async Task<LearnedModel> GetById(string id)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LearnedModel>(_collection);
      var result = collection.Find(x => x.course == id).FirstOrDefault();
      return result;
    }

    public static async Task Create(LearnedModel learnedModel)
    {
      if (string.IsNullOrEmpty(learnedModel.id))
      {
        learnedModel.id = Mongo.RandomId();
      }
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LearnedModel>(_collection);
      await collection.InsertOneAsync(learnedModel);
    }

    public static async Task<bool> Update(LearnedModel learnedModel)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LearnedModel>(_collection);
      var result = await collection.ReplaceOneAsync(x => x.id == learnedModel.id, learnedModel);
      if (result.IsAcknowledged && result.MatchedCount > 0)
      {
        return true;
      }
      return false;
    }

    public static async Task<bool> Delete(string id)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LearnedModel>(_collection);
      var result = await collection.DeleteOneAsync(x => x.id == id);
      if (result.DeletedCount > 0)
      {
        return true;
      }
      return false;
    }
  }
}
