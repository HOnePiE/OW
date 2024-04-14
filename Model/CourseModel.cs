using MongoDB.Bson.Serialization.Attributes;

namespace astn_course.Model
{
	[BsonIgnoreExtraElements]
	public class CourseModel
	{
		[BsonId]
		public string id { get; set; }
		public string name { get; set; }
		public string image { get; set; }
		public string category_id { get; set; }
		public string major_id { get; set; }
		public string description { get; set; }
		public string time { get; set; }
		public int learner { get; set; }
		public long date_create { get; set; }
		public bool active { get; set; }
		public string instructor { get; set; }
		public string creator { get; set; }
		public int level { get; set; }
		public string key { get; set; }

		public bool is_delete { get; set; }
		public List<string> members { get; set; } = new();
		public List<string> lesson { get; set; } = new();
	}

}
