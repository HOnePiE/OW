using MongoDB.Bson.Serialization.Attributes;

namespace astn_course.Model
{
  [BsonIgnoreExtraElements]
  public class MajorModel
  {
    [BsonId]
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    public bool active { get; set; }
    public long date_create { get; set; }

  }
}
