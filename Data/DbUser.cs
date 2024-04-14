using astn_course.Handled;
using astn_course.Model;
using MongoDB.Driver;
namespace astn_course.Data
{
	public class DbUser
	{
		public static string _collection = "users";
		public static async Task<List<UserModel>> GetAll()
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<UserModel>(_collection);
			var result = collection.Find(_ => true).ToList();
			return result;
		}

		public static async Task<List<UserModel>> GetByRole(int role)
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<UserModel>(_collection);
			var result = collection.FindAsync( x =>  x.role == role).Result.ToList();
			return result;
		}

		public static async Task<UserModel> GetById(string id)
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<UserModel>(_collection);
			var result = collection.Find(x => x.id == id).FirstOrDefault();
			return result;
		}



		public static async Task<UserModel> Create(UserModel usermodel)
		{
			if(string.IsNullOrEmpty(usermodel.id)){
				usermodel.id = Mongo.RandomId();
			}
			usermodel.email = usermodel.email.Trim().ToLower();
			usermodel.password = Handled.Shared.CreateMD5(usermodel.password);
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<UserModel>(_collection);
			await collection.InsertOneAsync(usermodel);
			return usermodel;
		}

		public static async Task<UserModel> Login(UserModel user)
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<UserModel>(_collection);
			var result = await collection.FindAsync(x => x.email == user.email && x.password == user.password).Result.FirstOrDefaultAsync();
			return result;
		}

		public static async Task<List<UserModel>> GetAllByRole(List<UserModel> listusers, int role)
		{
			return listusers.Where(x => x.role == role).ToList();
		}

		public static async Task<UserModel> Update(UserModel usermodel)
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<UserModel>(_collection);
			// nếu không tìm thấy bản ghi thì không thêm mới trường đó, nếu IsUpsert bằng true thì nó sẽ thêm mới
			var option = new ReplaceOptions { IsUpsert = false };
			await collection.ReplaceOneAsync(x => x.id == usermodel.id, usermodel);
			return usermodel;
		}

		public static async Task<bool> Delete(string id)
		{
			var _db = Mongo.DbConnect(Mongo._database);
			var collection = _db.GetCollection<UserModel>(_collection);
			var result = await collection.DeleteOneAsync(x => x.id == id);

			if (result.DeletedCount > 0)
			{
				return true;
			}
			else
				return false;
		}

		public static async Task<UserModel> GetByEmail(string email)
		{
			var db = Mongo.DbConnect(Mongo._database);
			var collection = db.GetCollection<UserModel>(_collection);
			var result = collection.Find(x => x.email == email).FirstOrDefault();
			return result;
		}

		public static async Task<UserModel> Login(string email, string pass)
		{
			var user = await GetByEmail(email);
			if (user != null)
			{
				var password = Handled.Shared.CreateMD5(pass);
				if (user.password == password)
				{
					return user;
				}
			}
			return null;
		}






  }
}
