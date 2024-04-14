using MongoDB.Bson.Serialization.Attributes;

namespace astn_course.Model
{
	[BsonIgnoreExtraElements]
	public class LessonModel
	{
		[BsonId]
		public string id { get; set; }
		public string name { get; set; }
		public int type { get; set; }
		public string time { get; set; }
		public string video { get; set; }
		public string description { get; set; }
		public List<string> listFile { get; set; } = new();
		public int pos { get; set; }	
		public bool active { get; set; }	
		public long date_create { get; set; }
    public string creator { get; set; }
		public string course { get; set; }
  }
}
