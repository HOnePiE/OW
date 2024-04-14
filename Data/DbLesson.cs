using astn_course.Model;
using MongoDB.Driver;
namespace astn_course.Data
{
  public class DbLesson
  {
    public static string _collection = "lessons";
    public static async Task<List<LessonModel>> GetAll()
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LessonModel>(_collection);
      var result = collection.Find(_ => true).ToList();
      return result;
    }

    public static async Task<List<LessonModel>> GetAllByCourse(string id)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LessonModel>(_collection);
      var result = collection.Find(x => x.course == id).ToList();
      return result;
    }

    public static async Task<LessonModel> Create(LessonModel lessonmodel)
    {
      if (string.IsNullOrEmpty(lessonmodel.id))
      {
        lessonmodel.id = Mongo.RandomId();
      }
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LessonModel>(_collection);
      await collection.InsertOneAsync(lessonmodel);
      return lessonmodel;
    }

    public static async Task<bool> Update(LessonModel lessonmodel)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LessonModel>(_collection);
      var result = await collection.ReplaceOneAsync(x => x.id == lessonmodel.id, lessonmodel);
      if (result.IsAcknowledged && result.MatchedCount > 0)
      {
        return true;
      }
      return false;
    }

    public static async Task<bool> Delete(string id)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<LessonModel>(_collection);
      var result = await collection.DeleteOneAsync(x => x.id == id);
      if (result.DeletedCount > 0)
      {
        return true;
      }
      return false;
    }


  }
}
