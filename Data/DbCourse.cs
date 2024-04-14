using astn_course.Model;
using MongoDB.Driver;
using System.Data;

namespace astn_course.Data
{
	public class DbCourse
	{
		public static string _collection = "courses";
		public static async Task<List<CourseModel>> GetAll()
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<CourseModel>(_collection);
			var result = collection.FindAsync(_ => true).Result.ToList();
			return result;
		}

		public static async Task<CourseModel> GetById(string id)
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<CourseModel>(_collection);
			var result = collection.FindAsync(x => x.id == id).Result.FirstOrDefault();
			return result;
		}

		public static async Task Create(CourseModel coursemodel)
		{
			if (string.IsNullOrEmpty(coursemodel.id))
			{
				coursemodel.id = Mongo.RandomId();
			}
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<CourseModel>(_collection);
			await collection.InsertOneAsync(coursemodel);
		}

		public static async Task<List<CourseModel>> GetAllByCategory(List<CourseModel> listCousres, string categoryId)
		{
			return listCousres.Where(x => x.category_id == categoryId).ToList();
		}

		public static async Task<List<CourseModel>> GetAllByMajor(List<CourseModel> listCousres, string majorId)
		{
			return listCousres.Where(x => x.major_id == majorId).ToList();
		}


		public static async Task<CourseModel> Update(CourseModel model)
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<CourseModel>(_collection);
			await collection.ReplaceOneAsync(x => x.id == model.id, model);
			return model;

		}

		public static async Task<bool> Delete(string id)
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<CourseModel>(_collection);
			var result = await collection.DeleteOneAsync(x => x.id == id);
			if (result.DeletedCount > 0)
			{
				return true;
			}
			return false;
		}

		public static async Task <bool> CheckKey(string key){
      var db = Mongo.DbConnect(Mongo._database);
      var collection = db.GetCollection<CourseModel>(_collection);
      var result = collection.FindAsync(x => x.id == key).Result.FirstOrDefault();
      if (result != null)
      {
        return true;
      }
      return false;
    }


	}
}
