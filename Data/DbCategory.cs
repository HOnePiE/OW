using astn_course.Model;
using MongoDB.Driver;

namespace astn_course.Data
{
  // loai khoa hoc
  public class DbCategory
  {
    public static string _collection = "categorys";
    public static async Task<List<CategoryModel>> GetAll()
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<CategoryModel>(_collection);
      var result = collection.Find(_ => true).ToList();
      return result;
    }

    public static async Task Create(CategoryModel categorymodel)
    {
      if (string.IsNullOrEmpty(categorymodel.id))
      {
        categorymodel.id = Mongo.RandomId();
      }
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<CategoryModel>(_collection);
      await collection.InsertOneAsync(categorymodel);
    }

    public static async Task<bool> Update(CategoryModel categorymdoel)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<CategoryModel>(_collection);
      var result = await collection.ReplaceOneAsync(x => x.id == categorymdoel.id, categorymdoel);
      if (result.IsAcknowledged && result.MatchedCount > 0)
      {
        return true;
      }
      return false;
    }

    public static async Task<bool> Delete(string id)
    {
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<CategoryModel>(_collection);
      var result = await collection.DeleteOneAsync(x => x.id == id);
      if (result.DeletedCount > 0)
      {
        return true;
      }
      return false;
    }
  }
}
