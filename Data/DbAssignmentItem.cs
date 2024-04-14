using astn_course.Model;
using MongoDB.Driver;

namespace astn_course.Data
{
    public class DbAssignmentItem
    {
        public static string _collection = "assignment_items";
        public static async Task<List<AssignmentItemModel>> GetAll()
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<AssignmentItemModel>(_collection);
            var result = collection.Find(_ => true).ToList();
            return result;
        }

        public static async void Create(AssignmentItemModel assignmentItemModel)
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<AssignmentItemModel>(_collection);
            await collection.InsertOneAsync(assignmentItemModel);
        }

        public static async Task<bool> Update(AssignmentItemModel assignmentItemModel)
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<AssignmentItemModel>(_collection);
            var result = await collection.ReplaceOneAsync(x => x.id == assignmentItemModel.id, assignmentItemModel);
            if (result.IsAcknowledged && result.MatchedCount > 0)
            {
                return true;
            }
            return false;
        }

        public static async Task<bool> Delete(string id)
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<AssignmentItemModel>(_collection);
            var result = await collection.DeleteOneAsync(x => x.id == id);
            if (result.DeletedCount > 0)
            {
                return true;
            }
            return false;
        }
    }
}
