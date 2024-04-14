using astn_course.Model;
using MongoDB.Driver;

namespace astn_course.Data
{
    public class DbCourseAssignment
    {
        public static string _collection = "course_assignments";
        public static async Task<List<CourseAssignmentModel>> GetAll()
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<CourseAssignmentModel>(_collection);
            var result = collection.Find(_ => true).ToList();
            return result;
        }

        public static async void Create(CourseAssignmentModel courseAssignmentModel)
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<CourseAssignmentModel>(_collection);
            await collection.InsertOneAsync(courseAssignmentModel);
        }

        public static async Task<bool> Update(CourseAssignmentModel courseAssignmentModel)
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<CourseAssignmentModel>(_collection);
            var result = await collection.ReplaceOneAsync(x => x.id == courseAssignmentModel.id, courseAssignmentModel);
            if (result.IsAcknowledged && result.MatchedCount > 0)
            {
                return true;
            }
            return false;
        }

        public static async Task<bool> Delete(string id)
        {
            var db = Mongo.DbConnect(Mongo._database);
            var collection = db.GetCollection<CourseAssignmentModel>(_collection);
            var result = await collection.DeleteOneAsync(x => x.id == id);
            if (result.DeletedCount > 0)
            {
                return true;
            }
            return false;
        }
    }
}
