using MongoDB.Bson.Serialization.Attributes;

namespace astn_course.Model
{
	[BsonIgnoreExtraElements]
	public class StaticModel
	{
		public int id { get; set; }

		public string id_string { get; set; }

		public string name { get; set; }

		public string icon { get; set; }

		public string color { get; set; }

		public string description { get; set; }

		public bool isDefault { get; set; }
	}
}
