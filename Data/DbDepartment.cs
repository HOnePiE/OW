using astn_course.Model;
using MongoDB.Driver;

namespace astn_course.Data
{
    public class DbDepartment
    {
        public static string _collection = "deparments";
        public static async Task<List<DepartmentModel>> GetAll()
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<DepartmentModel>(_collection);
            var result = collection.Find(_ => true).ToList();
            return result;
        }

        public static async void Create(DepartmentModel departmentModel)
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<DepartmentModel>(_collection);
            await collection.InsertOneAsync(departmentModel);
        }

        public static async Task<bool> Update(DepartmentModel departmentModel)
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<DepartmentModel>(_collection);
            var result = await collection.ReplaceOneAsync(x => x.id == departmentModel.id, departmentModel);
            if (result.IsAcknowledged && result.MatchedCount > 0)
            {
                return true;
            }
            return false;
        }

        public static async Task<bool> Delete(string id)
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<DepartmentModel>(_collection);
            var result = await collection.DeleteOneAsync(x => x.id == id);
            if (result.DeletedCount > 0)
            {
                return true;
            }
            return false;
        }
    }
}
